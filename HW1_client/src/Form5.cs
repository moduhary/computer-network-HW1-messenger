using System;
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
    public partial class Form5 : Form
    {
        private NetworkStream client;
        private string user_name;

        public Form5(NetworkStream stream)
        {
            InitializeComponent();
            client = stream;
            this.Text = "New request";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message;
            byte[] raw_message;

            int user_idx = -1, receive_size = 0;
            string receive;
            string[] args;
            byte[] raw_receive;

            message = "getuser " + friend_box.Text;
            raw_message = Encoding.ASCII.GetBytes(message);

            sendsize(client, raw_message.Length);
            client.Write(raw_message,0,raw_message.Length);

            receive_size = getsize(client);
            raw_receive = new byte[receive_size];
            client.Read(raw_receive, 0, receive_size);

            receive = Encoding.ASCII.GetString(raw_receive);
            args = receive.Split(' ');

            user_idx = int.Parse(args[1]);

            if(user_idx == -1)
            {
                exist_label.Text = "No user";
                MessageBox.Show("No such user found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if(user_name == friend_box.Text)
                {
                    exist_label.Text = "Same";
                    MessageBox.Show("You should put other user's ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                    exist_label.Text = "Exist";
            }

            exist_label.Show();
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

        private void request_button_Click(object sender, EventArgs e)
        {
            string message;
            byte[] raw_message;

            int user_idx = -1, receive_size = 0;
            byte[] raw_receive;

            if (exist_label.Text == "Exist")
            {
                message = "friend_request " + friend_box.Text;
                raw_message = Encoding.ASCII.GetBytes(message);

                sendsize(client, raw_message.Length);
                client.Write(raw_message, 0, raw_message.Length);

                receive_size = getsize(client);
                raw_receive = new byte[receive_size];
                client.Read(raw_receive, 0, receive_size);

                message = Encoding.ASCII.GetString(raw_receive);

                if(message == "friend_request")
                {
                    MessageBox.Show("Success!", "server response", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Error on friend request", "server response", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (exist_label.Text == "No user")
            {
                MessageBox.Show("No such user found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Please find a user first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
