using SocketCommT.client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketCommT.form
{
    public partial class FormClient : Form
    {
        private const int serverPort = 6000;
        private const string serverIp = "127.0.0.1";
        private Client client;

        public FormClient()
        {
            InitializeComponent();
            client = new Client(serverIp, serverPort);
            client.MessageReceived += UpdateStatus;
            client.Connect();
        }

        private void bexit_Click(object sender, EventArgs e)
        {

        }

        private void bsend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                client.SendMessage(textBox2.Text);
                textBox2.Text = "";
            }
            else
            {
                textBox2.Text = "";
            }
        }

        private void onEnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //event sumbit message to server
                //check if empty or just spaces
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    client.SendMessage(textBox2.Text);
                    textBox2.Text= "";
                }
                else
                {
                    textBox2.Text = "";
                }

                
            }
        }
        private void UpdateStatus(object sender, string message)
        {
                Invoke(new Action(() => AddMessageToChatHistory(message)));
        }

        private void AddMessageToChatHistory(string message)
        {
            textBox1.AppendText(message + Environment.NewLine);
        }
    }
}
