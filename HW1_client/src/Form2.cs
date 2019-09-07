using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Collections;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private NetworkStream client;
        private ArrayList friends;
        private ArrayList[] message_list;
        private ArrayList chat_list;
        private TreeNode online_node;
        private TreeNode offline_node;

        public string user_name;

        public Form2(NetworkStream stream)
        {
            InitializeComponent();
            client = stream;
            message_list = new ArrayList[10];
            friends = new ArrayList();
            chat_list = new ArrayList();
            online_node = new TreeNode("Online", 0, 0);
            offline_node = new TreeNode("Offline", 1, 1);

            Friend_view.Nodes.Add(online_node);
            Friend_view.Nodes.Add(offline_node);

            for(int i = 0; i < 10; i++)
            {
                message_list[i] = new ArrayList();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            byte[] raw_message;
            string message;

            byte[] raw_receive;
            string receive;

            string[] friend_list;
            string[] message_arg;
            string[] friend_state;

            int sender_idx, receive_size = 0;

            chat_list.Clear();
            chatbox.Items.Clear();

            raw_message = Encoding.ASCII.GetBytes("friend_list");

            sendsize(client, raw_message.Length);
            client.Write(raw_message, 0, raw_message.Length);

            receive_size = getsize(client);
            raw_receive = new byte[receive_size];
            client.Read(raw_receive, 0, receive_size);

            receive = Encoding.ASCII.GetString(raw_receive);
            friend_list = receive.Split(' ');

            for(int i = 1; i < friend_list.Length; i++)
            {
                friends.Add(friend_list[i]);
            }

            raw_message = Encoding.ASCII.GetBytes("receive");

            sendsize(client, raw_message.Length);
            client.Write(raw_message, 0, raw_message.Length);

            receive_size = getsize(client);
            raw_receive = new byte[receive_size];
            client.Read(raw_receive, 0, receive_size);

            receive = Encoding.ASCII.GetString(raw_receive);

            if (receive == "No_message")
            {

            }
            else if (receive == "message")
            {
                while (true)
                {
                    receive_size = getsize(client);
                    raw_receive = new byte[receive_size];
                    client.Read(raw_receive, 0, receive_size);

                    receive = Encoding.ASCII.GetString(raw_receive);

                    if(receive == "End")
                    {
                        break;
                    }

                    message_arg = receive.Split('|');

                    sender_idx = int.Parse(message_arg[0]);
                    message_list[sender_idx].Add(message_arg[1]);
                }
            }

            for(int i = 1; i <  friend_list.Length; i++)
            {
                friend_state = friend_list[i].Split(':');

                if (friend_state[1].Contains("online"))
                    online_node.Nodes.Add(friend_state[0]);
                else
                    offline_node.Nodes.Add(friend_state[0]);
            }

            Friend_view.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void requestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] raw_message = Encoding.ASCII.GetBytes("signout");
            byte[] raw_receive = new byte[20];

            int receive_size = 0;

            sendsize(client, raw_message.Length);
            client.Write(raw_message, 0, raw_message.Length);

            receive_size = getsize(client);
            raw_receive = new byte[receive_size];
            client.Read(raw_receive, 0, receive_size);

            client.Close();
            Application.Exit();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Chatbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void chatbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string receiver_id = Friend_view.SelectedNode.Text;
            string message = sendtext.Text;
            string[] receive;

            if(receiver_id == "Online" || receiver_id == "Offline" || receiver_id == "" || receiver_id == null)
            {
                MessageBox.Show("Please select a friend to send message", "receiver required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] raw_message = Encoding.ASCII.GetBytes("send " + receiver_id + " " + message);
            byte[] raw_receive = new byte[50];

            int receiver_idx, receive_size = 0;

            sendsize(client, raw_message.Length);
            client.Write(raw_message, 0, raw_message.Length);

            receive_size = getsize(client);
            raw_receive = new byte[receive_size];
            client.Read(raw_receive, 0, receive_size);

            receive = Encoding.ASCII.GetString(raw_receive).Split(' ');

            if(receive[0] == "send")
            {
                receiver_idx = int.Parse(receive[1]);

                message_list[receiver_idx].Add(message);
                chatbox.Items.Add("You: " + message);
            }

            sendtext.Text = "";
            chatbox.Show();
        }

        private void 친구요청관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 request_manage = new Form3(client);
            request_manage.Show();
        }

        private int sendsize(NetworkStream stream, int size)
        {
            byte[] raw_size = BitConverter.GetBytes(size);

            stream.Write(raw_size, 0, 4);

            return size;
        }

        private int getsize(NetworkStream stream)
        {
            int size;
            byte[] raw_size = new byte[4];

            stream.Read(raw_size, 0, 4);

            size = BitConverter.ToInt32(raw_size, 0);

            return size;
        }

        private void Friend_view_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string user_id = Friend_view.SelectedNode.Text;
            string[] message;
            string receive;
            string[] message_arg;

            int user_idx = -1;
            int sender_idx;
            int receive_size;

            byte[] raw_message = Encoding.ASCII.GetBytes("getuser " + user_id);
            byte[] raw_receive;

            chatbox.Items.Clear();
            chat_list.Clear();

            if (user_id == "Online" || user_id == "Offline")
                return;

            sendsize(client, raw_message.Length);
            client.Write(raw_message, 0, raw_message.Length);

            receive_size = getsize(client);
            raw_receive = new byte[receive_size];
            client.Read(raw_receive, 0, receive_size);

            message = Encoding.ASCII.GetString(raw_receive).Split(' ');

            if (message[0] == "useridx:")
            {
                user_idx = int.Parse(message[1]);
            }

            raw_message = Encoding.ASCII.GetBytes("getmessage " + user_idx);
            sendsize(client, raw_message.Length);
            client.Write(raw_message, 0, raw_message.Length);

            while (true)
            {
                receive_size = getsize(client);
                raw_receive = new byte[receive_size];
                client.Read(raw_receive, 0, receive_size);

                receive = Encoding.ASCII.GetString(raw_receive);

                if (receive == "End" || receive == "No_message")
                    break;
                else if (receive == "message")
                    continue;

                message_arg = receive.Split('|');

                sender_idx = int.Parse(message_arg[0]);

                if (sender_idx == user_idx)
                    chat_list.Add(user_id + ": " + message_arg[1]);
                else
                    chat_list.Add("You: " + message_arg[1]);
            }

            for (int i = 0; i < chat_list.Count; i++)
            {
                chatbox.Items.Add(chat_list[i]);
            }

            chatbox.Show();
        }

        private void updateAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] raw_message;
            byte[] raw_receive;
            string receive;

            string[] friend_list;
            string[] friend_state;

            int receive_size = 0;

            online_node.Nodes.Clear();
            offline_node.Nodes.Clear();

            raw_message = Encoding.ASCII.GetBytes("friend_list");

            sendsize(client, raw_message.Length);
            client.Write(raw_message, 0, raw_message.Length);

            receive_size = getsize(client);
            raw_receive = new byte[receive_size];
            client.Read(raw_receive, 0, receive_size);

            receive = Encoding.ASCII.GetString(raw_receive);
            friend_list = receive.Split(' ');

            for (int i = 1; i < friend_list.Length; i++)
            {
                friends.Add(friend_list[i]);
            }


            for (int i = 1; i < friend_list.Length; i++)
            {
                friend_state = friend_list[i].Split(':');

                if (friend_state[1].Contains("online"))
                    online_node.Nodes.Add(friend_state[0]);
                else
                    offline_node.Nodes.Add(friend_state[0]);
            }

            Friend_view.Show();
        }
    }
}
