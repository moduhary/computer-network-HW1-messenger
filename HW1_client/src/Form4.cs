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
    public partial class Form4 : Form
    {
        private NetworkStream client;

        public Form4(NetworkStream stream)
        {
            InitializeComponent();
            client = stream;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string ID = ID_text.Text;
            string password = Password_text.Text;

            string message = "Signup " + ID + " " + password;
            string receive;

            byte[] raw_message = Encoding.ASCII.GetBytes(message);
            byte[] raw_receive = new byte[30];

            int receive_size;

            receive_size = getsize(client);
            raw_receive = new byte[receive_size];
            client.Read(raw_receive, 0, receive_size);

            receive = Encoding.ASCII.GetString(raw_receive);

            if (receive != "Init")
            {
                MessageBox.Show("Fail to talk on server", "server response", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Signup_button_Click(object sender, EventArgs e)
        {
            string ID = ID_text.Text;
            string password = Password_text.Text;

            string message = "Signup " + ID + " " + password;
            string receive;

            byte[] raw_message = Encoding.ASCII.GetBytes(message);
            byte[] raw_receive = new byte[30];

            int receive_size;

            sendsize(client, raw_message.Length);
            client.Write(raw_message, 0, raw_message.Length);

            receive_size = getsize(client);
            raw_receive = new byte[receive_size];
            client.Read(raw_receive, 0, receive_size);

            receive = Encoding.ASCII.GetString(raw_receive);

            if (receive == "Signup")
            {
                MessageBox.Show("Success!", "server response", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error on server", "server response", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ID_text.Text = "";
            Password_text.Text = "";
            Close();
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

        private void duplicate_check_button_Click(object sender, EventArgs e)
        {
            string message;
            byte[] raw_message;

            int user_idx = -1, receive_size = 0;
            string receive;
            string[] args;
            byte[] raw_receive;

            message = "getuser " + ID_text.Text;
            raw_message = Encoding.ASCII.GetBytes(message);

            sendsize(client, raw_message.Length);
            client.Write(raw_message, 0, raw_message.Length);

            receive_size = getsize(client);
            raw_receive = new byte[receive_size];
            client.Read(raw_receive, 0, receive_size);

            receive = Encoding.ASCII.GetString(raw_receive);

            args = receive.Split(' ');

            user_idx = int.Parse(args[1]);

            if (user_idx == -1)
            {
                MessageBox.Show("You can use that ID", "Duplicate Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Duplicate ID found. Please use other ID", "Duplicate Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
