using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private NetworkStream client;
        internal string user_name;

        public Form3(NetworkStream stream)
        {
            InitializeComponent();
            client = stream;
            this.Text = "Friend request manage";
            friends_request.Items.Clear();
        }

        private void friends_request_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            byte[] raw_message = Encoding.ASCII.GetBytes("get_pending_request");
            byte[] raw_receive;

            string[] receive;

            int receive_size;

            friends_request.Items.Clear();

            sendsize(client, raw_message.Length);
            client.Write(raw_message, 0, raw_message.Length);

            receive_size = getsize(client);
            raw_receive = new byte[receive_size];
            client.Read(raw_receive, 0, receive_size);

            receive = Encoding.ASCII.GetString(raw_receive).Split(' ');

            if (receive[0] == "pending_list:")
            {
                for (int i = 1; i < receive.Length; i++)
                    friends_request.Items.Add(receive[i], CheckState.Unchecked);
            }

            if(friends_request.Items.Count == 0)
            {
                MessageBox.Show("No pending requests", "pending request search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            friends_request.Show();
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

        private void Accept_Button_Click(object sender, EventArgs e)
        {
            string message = "";
            byte[] raw_message;

            string receive = "";
            byte[] raw_receive;
            int receive_size;

            foreach(string user_id in friends_request.CheckedItems)
            {
                message = "friend_accept " + user_id;
                raw_message = Encoding.ASCII.GetBytes(message);

                sendsize(client, raw_message.Length);
                client.Write(raw_message, 0, raw_message.Length);

                receive_size = getsize(client);
                raw_receive = new byte[receive_size];
                client.Read(raw_receive, 0, receive_size);

                if (receive == "friend_accept")
                    MessageBox.Show("Friend accepted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Form3_Load(sender, e);
        }

        private void Decline_Button_Click(object sender, EventArgs e)
        {
            string message = "";
            byte[] raw_message;

            string receive = "";
            byte[] raw_receive;
            int receive_size;

            foreach (string user_idx in friends_request.CheckedItems)
            {
                message = "friend_decline " + user_idx;
                raw_message = Encoding.ASCII.GetBytes(message);

                sendsize(client, raw_message.Length);
                client.Write(raw_message, 0, raw_message.Length);

                receive_size = getsize(client);
                raw_receive = new byte[receive_size];
                client.Read(raw_receive, 0, receive_size);

                if (receive == "friend_decline")
                    MessageBox.Show("Friend declined", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Form3_Load(sender, e);
        }

        private void Newrequest_Button_Click(object sender, EventArgs e)
        {
            Form5 request_form = new Form5(client);
            request_form.Show();
        }
    }
}
