using System.Data.SQLite;
using System;
using System.Collections;
using System.Net.Sockets;
using System.Text;

namespace HW1
{
    public class DBAPI
    {
        private int user_idx;
        private string user_pass;
        private int receiver;
        private SQLiteConnection conn;
        private SQLiteCommand query;
        private int result;
        private SQLiteDataReader read;
        private SQLiteDataAdapter adapt;
        private ArrayList records;
        public delegate void receive_message(NetworkStream net, int user_idx);

        private receive_message receive;

        public DBAPI()
        {
            if(!System.IO.File.Exists("/home/bacchus/messenger_db.sqlite"))
            {
                SQLiteConnection.CreateFile("/home/bacchus/messenger_db.sqlite");
            }

            conn = new SQLiteConnection("Data Source=/home/bacchus/messenger_db.sqlite;Version=3;");
            conn.Open();

            query = new SQLiteCommand(conn);
            query.CommandText = System.IO.File.ReadAllText(@"schema.sql");
            result = query.ExecuteNonQuery();

            records = new ArrayList();
            receive = new receive_message(receive_func);
        }
        
        public void receive_func(NetworkStream net, int user_idx)
        {
            records.Clear();

            string sql = "select sender,message,created_at from messages where receiver=" + user_idx + " union select receiver, message, created_at from messages where sender=" + user_idx + " order by created_at asc;";
            string message;
            byte[] raw_message;

            print_query(sql);
            query.CommandText = sql;
            read = query.ExecuteReader();

            if(!read.HasRows)
            {
                raw_message = Encoding.ASCII.GetBytes("No_message");
                sendsize(net, raw_message.Length);
                net.Write(raw_message);

                read.Close();
                return;
            }
            else
            {
                raw_message = Encoding.ASCII.GetBytes("message");
                sendsize(net, raw_message.Length);
                net.Write(raw_message);
            }

            while(read.Read())
            {
                message = read["sender"].ToString() + "|" + read["message"].ToString() + "---" + read["created_at"];
                raw_message = Encoding.ASCII.GetBytes(message);

                try
                {
                    sendsize(net, raw_message.Length);
                    net.Write(raw_message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
            }

            raw_message = Encoding.ASCII.GetBytes("End");
            sendsize(net, raw_message.Length);
            net.Write(raw_message);

            read.Close();
            return;
        }


        public int DB_adduser(string id, string pass)
        {
            string sql = "insert into users (ID, pass, state) values('" + id + "','" + pass + "', 'offline');";
            query.CommandText = sql;
            print_query(sql);
            query.ExecuteNonQuery();

            return -3;
        }

        public int DB_deluser(string id)
        {
            string sql = "delete from users where ID='" + id + "';";
            query.CommandText = sql;
            print_query(sql);
            result = query.ExecuteNonQuery();

            return result;
        }

        public int DB_getuser(string id)
        {
            int user_idx;

            string sql = "select user_idx from users where ID='" + id + "';";
            query.CommandText = sql;
            print_query(sql);
            read = query.ExecuteReader();

            if (read.Read())
            {
                user_idx = int.Parse(read["user_idx"].ToString());
                read.Close();
                return user_idx;
            }
            else
            {
                read.Close();
                return -1;
            }
        }

        public string DB_getuser(int id)
        {
            string user_id;

            string sql = "select ID from users where user_idx=" + id + ";";
            query.CommandText = sql;
            print_query(sql);
            read = query.ExecuteReader();

            if (read.Read())
            {
                user_id = read["ID"].ToString();
                read.Close();
                return user_id;
            }
            else
            {
                read.Close();
                return "NOUSER";
            }
        }

        public int signin(string id, string pass)
        {
            records.Clear();

            int user_idx = -1;
            string sql = "select user_idx from users where ID='" + id + "' AND pass='" + pass + "';";
            print_query(sql);
            query.CommandText = sql;
            read = query.ExecuteReader();

            while(read.Read())
            {
                user_idx = int.Parse(read["user_idx"].ToString());
                records.Add(user_idx);
            }

            read.Close();

            Console.WriteLine(records.Count);

            if(records.Count == 1)
            {
                sql = "update users set state='online' where ID='" + id + "';";
                print_query(sql);
                query.CommandText = sql;
                try
                {
                    query.ExecuteNonQuery();
                }
                catch (System.InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                return user_idx;
            }
            else
                return -1;
        }

        public int signout(int user_idx)
        {
            string sql = "update users set state='offline' where user_idx='" + user_idx + "';";
            query.CommandText = sql;
            print_query(sql);
            result = query.ExecuteNonQuery();

            return result;
        }

        public int send_message(int user_idx, string receiver, string message)
        {
            string sql = "select user_idx from users where ID= '"+ receiver +"';";
            int receiver_idx = -1;

            query.CommandText = sql;
            print_query(sql);
            read = query.ExecuteReader();

            while(read.Read())
            {
                receiver_idx = int.Parse(read["user_idx"].ToString());
            }

            read.Close();

            sql = "insert into messages (sender, receiver, message) values(" + user_idx + "," + receiver_idx + ",'" + message + "');";
            print_query(sql);
            query.CommandText = sql;
            result = query.ExecuteNonQuery();

            return receiver_idx;
        }

        public int receive_messages(NetworkStream net, int sender, int receiver)
        {
            int userA = -1, userB = -1;

            records.Clear();

            userA = sender;
            userB = receiver;

            string sql = "select sender,message,created_at from messages where (sender=" + userA + " or sender=" + userB + ") and (receiver=" + userA + " or receiver=" + userB + ") order by created_at asc;";
            string message;
            byte[] raw_message;
            print_query(sql);

            query.CommandText = sql;
            read = query.ExecuteReader();

            if (!read.HasRows)
            {
                raw_message = Encoding.ASCII.GetBytes("No_message");
                sendsize(net, raw_message.Length);
                net.Write(raw_message);

                read.Close();
                return -1;
            }
            else
            {
                raw_message = Encoding.ASCII.GetBytes("message");
                sendsize(net, raw_message.Length);
                net.Write(raw_message);
            }

            while (read.Read())
            {
                message = read["sender"].ToString() + "|" + read["message"].ToString() + "---" + read["created_at"];
                raw_message = Encoding.ASCII.GetBytes(message);

                try
                {
                    sendsize(net, raw_message.Length);
                    net.Write(raw_message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
            }

            raw_message = Encoding.ASCII.GetBytes("End");
            sendsize(net, raw_message.Length);
            net.Write(raw_message);

            read.Close();
            return userA;

        }

        public int add_pending_friend(int user_idx, int friend_idx)
        {
            string sql = "insert into friends (userA, userB) values(" + user_idx + "," + friend_idx + ");";
            print_query(sql);

            query.CommandText = sql;
            result = query.ExecuteNonQuery();

            return result;
        }

        public ArrayList get_pending_friend(int user_idx)
        {
            records.Clear();

            string sql = "select userA from friends where userB=" + user_idx + " and activated=false;";
            int friend_idx;

            query.CommandText = sql;
            print_query(sql);
            read = query.ExecuteReader();

            while (read.Read())
            {
                friend_idx = int.Parse(read["userA"].ToString());
                records.Add(friend_idx);
            }

            read.Close();

            return records;
        }

        public int activate_friend(int user_idx, int friend_idx)
        {
            string sql = "update friends set activated=true where userA=" + friend_idx + " and userB=" + user_idx + ";";

            query.CommandText = sql;
            print_query(sql);
            result = query.ExecuteNonQuery();

            return result;
        }

        public int decline_friend(int user_idx, int friend_idx)
        {
            string sql = "delete from friends where userA=" + friend_idx + " and userB=" + user_idx + ";";

            query.CommandText = sql;
            print_query(sql);
            result = query.ExecuteNonQuery();

            return result;
        }

        public ArrayList get_friends(int user_idx)
        {
            records.Clear();

            string sql = "select ID, state from users where user_idx in (select userB from friends where userA=" + user_idx + " and activated=true union select userA from friends where userB=" + user_idx + " and activated=true);";

            query.CommandText = sql;
            print_query(sql);
            read = query.ExecuteReader();

            while(read.Read())
            {
                records.Add(read["ID"].ToString() + ":" + read["state"]);
            }

            read.Close();

            return records;
        }

        private int sendsize(NetworkStream stream, int size)
        {
            byte[] raw_size = BitConverter.GetBytes(size);

            stream.Write(raw_size, 0, 4);

            return size;
        }

        private void print_query(string Q)
        {
            Console.WriteLine("Query: " + Q);
        }
    }
}