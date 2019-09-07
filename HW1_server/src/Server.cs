using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;
using System.Collections;

namespace HW1
{
    class Program
    {
        private static DBAPI serverapi;

        static void Main(string[] args)
        {
            serverapi = new DBAPI();

            TcpListener Server = new TcpListener(IPAddress.Any,20364);
            Server.Start();

            while(true) 
            {            
                try {
                    TcpClient Client;
                    Client = Server.AcceptTcpClient();

                    ThreadPool.QueueUserWorkItem(Connection, Client);
                }
                catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }
            }

        }

        public static void Connection(object clientobject)
        {
            TcpClient Client = (TcpClient)clientobject;
            int user_idx = -1;

            try
            {
                NetworkStream stream = Client.GetStream();

                while (user_idx < 0)
                {
                    user_idx = Sign_in(stream);

                    if (user_idx == -2)
                    {
                        return;
                    }
                }

                onchat(stream, user_idx);
                signout(stream, user_idx);

                stream.Close();
                Client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if(user_idx > 0)
                    serverapi.signout(user_idx);
            }

            return;
        }

        public static int Sign_in(NetworkStream stream)
        {
            byte[] raw_message = Encoding.ASCII.GetBytes("Init");
            byte[] raw_message2;
            byte[] received_message;
            string translated_message = "";
            string[] arg = null;
            int i, receive_size = 0, signin_result = -1;

            ArrayList message_arguments = new ArrayList();
            Console.WriteLine("Signin/Signup Phase...");

            try
            {
                sendsize(stream, raw_message.Length);
                stream.Write(raw_message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }

            while (true)
            {
                try
                {
                    receive_size = getsize(stream);
                    received_message = new byte[receive_size];
                    if (stream.Read(received_message) == 0)
                    {
                        return -2;
                    }
                    translated_message = Encoding.ASCII.GetString(received_message);
                    arg = translated_message.Split(' ');
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                for (i = 0; i < arg.Length; i++)
                {
                    message_arguments.Add(arg[i]);
                }

                Console.WriteLine(translated_message);

                if (arg[0] == "getuser")
                {
                    raw_message2 = Encoding.ASCII.GetBytes("useridx: " + serverapi.DB_getuser(arg[1]));
                    Console.WriteLine(Encoding.ASCII.GetString(raw_message2));

                    sendsize(stream, raw_message2.Length);
                    stream.Write(raw_message2);

                    continue;
                }

                if (arg[0] == "Signin")
                    signin_result = serverapi.signin(arg[1], arg[2].TrimEnd('\n', '\r'));
                else if (arg[0] == "Signup")
                {
                    signin_result = serverapi.DB_adduser(arg[1], arg[2]);
                }

                string debug;

                switch (signin_result)
                {
                    case -3:
                        debug = "Signup_result: user_id: " + arg[1] + " Success";
                        break;

                    case -1:
                        debug = "Signin_result: user_id: " + arg[1] + " Failed - Check Password";
                        break;

                    default:
                        debug = "Signin_result: user_id: " + arg[1] + " Success";
                        break;
                }

                Console.WriteLine(debug);

                if (signin_result >= 0)
                {
                    raw_message = Encoding.ASCII.GetBytes("Signin");

                    sendsize(stream, raw_message.Length);
                    stream.Write(raw_message);

                    break;
                }
                else if (signin_result == -3)
                {
                    raw_message = Encoding.ASCII.GetBytes("Signup");
                    sendsize(stream, raw_message.Length);
                    stream.Write(raw_message);

                    break;
                }
                else
                {
                    raw_message = Encoding.ASCII.GetBytes("Fail");
                    sendsize(stream, raw_message.Length);
                    stream.Write(raw_message);

                    break;
                }
            }

            Console.WriteLine("End of Phase Signin/Signup...");
            Console.WriteLine();
            return signin_result;
        }

        public static void onchat(NetworkStream stream, int user_idx)
        {
            byte[] raw_message = null;
            byte[] received_message;
            string translated_message, chat ="";
            string[] arg;

            int receive_size, request_num = 0;
            string message, debug;

            ArrayList list = new ArrayList();

            Console.WriteLine("Phase On chatting...");

            while(true)
            {
                request_num++;
                receive_size = getsize(stream);
                received_message = new byte[receive_size];

                Console.WriteLine("Start of request {0}", request_num);

                try
                {
                    if (stream.Read(received_message, 0, receive_size) == 0)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                translated_message = Encoding.ASCII.GetString(received_message);
                arg = translated_message.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine("Received message: " + translated_message);

                if (arg[0] == "send")
                {
                    for(int i = 2; i < arg.Length; i++)
                    {
                        chat += arg[i] + " ";
                    }

                    int receiver_idx = serverapi.send_message(user_idx, arg[1], chat);
                    raw_message = Encoding.ASCII.GetBytes("send " + receiver_idx);
                    sendsize(stream, raw_message.Length);
                    stream.Write(raw_message);
                }
                else if(arg[0] == "getuser")
                {
                    raw_message = Encoding.ASCII.GetBytes("useridx: " + serverapi.DB_getuser(arg[1]));
                    sendsize(stream, raw_message.Length);
                    stream.Write(raw_message);
                }
                else if (arg[0] == "friend_list")
                {
                    int idx = 0;
                    list = serverapi.get_friends(user_idx);

                    message = "friend_list:";

                    while (idx < list.Count)
                    {
                        message += " " + list[idx].ToString();
                        idx++;
                    }

                    raw_message = Encoding.ASCII.GetBytes(message);
                    sendsize(stream, raw_message.Length);
                    stream.Write(raw_message);
                }                    
                else if (arg[0] == "receive")
                {
                    serverapi.receive_func(stream, user_idx);
                }
                else if (arg[0] == "getmessage")
                {
                    serverapi.receive_messages(stream, int.Parse(arg[1]), user_idx);
                }
                else if (arg[0] == "get_pending_request")
                {
                    int idx = 0;
                    string user_id = "";
                    list = serverapi.get_pending_friend(user_idx);

                    message = "pending_list: ";

                    while (idx < list.Count)
                    {
                        user_id = serverapi.DB_getuser(int.Parse(list[idx].ToString()));

                        if(user_id != "NOUSER")
                            message += " " + user_id;
                        idx++;
                    }

                    raw_message = Encoding.ASCII.GetBytes(message);
                    sendsize(stream, raw_message.Length);
                    stream.Write(raw_message);
                }
                else if (arg[0] == "friend_request")
                {
                    serverapi.add_pending_friend(user_idx,serverapi.DB_getuser(arg[1]));
                    raw_message = Encoding.ASCII.GetBytes("friend_request");
                    sendsize(stream, raw_message.Length);
                    stream.Write(raw_message);
                }
                else if (arg[0] == "friend_accept")
                {
                    int user_id = -1;
                    user_id = serverapi.DB_getuser(arg[1]);

                    if (user_id != -1)
                        serverapi.activate_friend(user_idx, user_id);

                    raw_message = Encoding.ASCII.GetBytes("friend_accept");

                    sendsize(stream, raw_message.Length);
                    stream.Write(raw_message);
                }
                else if (arg[0] == "friend_decline")
                {
                    serverapi.decline_friend(user_idx, serverapi.DB_getuser(arg[1]));
                    raw_message = Encoding.ASCII.GetBytes("friend_decline");
                    sendsize(stream, raw_message.Length);
                    stream.Write(raw_message);
                }
                else if (arg[0] == "signout")
                {
                    break;
                }

                Console.WriteLine("Send message: " + Encoding.ASCII.GetString(raw_message));
                Console.WriteLine("End of request {0}", request_num);
            }

            Console.WriteLine("End of Phase Onchat...");
            Console.WriteLine();
            return;
        }

        public static void signout(NetworkStream net, int user_idx)
        {
            byte[] message = Encoding.ASCII.GetBytes("Signout");

            Console.WriteLine("Phase Signout");

            serverapi.signout(user_idx);
            Console.WriteLine("Signout user_idx: {0}", user_idx);

            sendsize(net, message.Length);
            net.Write(message);

            Console.WriteLine("End of Phase Signout");

            return;
        }

        private static int sendsize(NetworkStream stream, int size)
        {
            byte[] raw_size = BitConverter.GetBytes(size);

            stream.Write(raw_size, 0, 4);

            return size;
        }

        private static int getsize(NetworkStream stream)
        {
            int size;
            byte[] raw_size = new byte[4];

            stream.Read(raw_size, 0, 4);

            size = BitConverter.ToInt32(raw_size, 0);

            return size;
        }
    }
}
