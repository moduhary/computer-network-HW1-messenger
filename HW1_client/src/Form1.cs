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
using System.Net;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private TcpClient Conn;
        private NetworkStream Clientstream;
        public string user_name;

        public Form1()
        {
            InitializeComponent();
            this.Text = "HW1 chat program";
            Conn = new TcpClient();
            int status = 0;

            while (status >= 0)
            {
                try
                {
                    Conn.Connect(IPAddress.Parse("147.46.241.102"), 20364);
                    break;
                }
                catch (Exception e)
                {
                    DialogResult result;
                    result = MessageBox.Show("Error Connecting to server", "Socket Exception occured", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    switch (result)
                    {
                        case DialogResult.Retry:
                            continue;

                        case DialogResult.Cancel:
                            status = -1;
                            Conn.Close();
                            break;

                        default:
                            status = -1;
                            Conn.Close();
                            break;
                    }
                }
            }

            if (status == -1)
                Application.Exit();

            Clientstream = Conn.GetStream();
        }

        private void Signin_button_Click(object sender, EventArgs e)
        {
            int receive_size = 0;
            int send_size = 0;

            byte[] raw_message;
            string message;

            byte[] raw_receive = new byte[4];
            string message_rec;

            DialogResult result;

            try
            {
                if(Clientstream.Read(raw_receive, 0, 4) == 0)
                {
                    result = MessageBox.Show("Error Connecting to server", "Socket Exception occured 1", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Conn.Close();
                    Clientstream.Close();

                    Application.Exit();
                }

                receive_size = BitConverter.ToInt32(raw_receive, 0);
                raw_receive = new byte[receive_size];
                Clientstream.Read(raw_receive, 0, receive_size);

                message_rec = Encoding.ASCII.GetString(raw_receive);

                Console.WriteLine(message_rec);

                if (message_rec != "Init")
                {
                    result = MessageBox.Show("Bad Server Response", message_rec, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Conn.Close();
                    Clientstream.Close();

                    Application.Exit();
                }
            }
            catch (Exception excep)
            {
                result = MessageBox.Show("Error Connecting to server", "Socket Exception occured 2", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Conn.Close();
                Clientstream.Close();

                Application.Exit();
            }

            message = "Signin" + " " + ID_text.Text + " " + Password_text.Text + "\n";
            raw_message = Encoding.ASCII.GetBytes(message);

            try
            {
                sendsize(Clientstream, raw_message.Length);
                Clientstream.Write(raw_message, 0, raw_message.Length);

                receive_size =  getsize(Clientstream);
                raw_receive = new byte[receive_size];
                Clientstream.Read(raw_receive, 0, receive_size);
            }
            catch (Exception excep)
            {
                result = MessageBox.Show("Error Reading from server", "Socket Exception occured 3", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Conn.Close();
                Clientstream.Close();

                Application.Exit();
            }

            message_rec = Encoding.ASCII.GetString(raw_receive);

            if(message_rec == "Signin")
            {
                Form2 chatform = new Form2(Clientstream);
                this.Visible = false;
                user_name = ID_text.Text;
                chatform.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ID_text_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Conn.Close();
            Clientstream.Close();
            Application.Exit();
        }

        private void Signup_button_Click(object sender, EventArgs e)
        {
            Form4 signup = new Form4(Clientstream);
            signup.Show();
        }

        private void Password_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_label_Click(object sender, EventArgs e)
        {

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
    }
}
