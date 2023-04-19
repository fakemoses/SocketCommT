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
        private readonly Thread clientThread;

        public FormClient()
        {
            InitializeComponent();
        }

        private void bexit_Click(object sender, EventArgs e)
        {

        }

        private void bsend_Click(object sender, EventArgs e)
        {

        }

        private void UpdateStatus(string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateStatus), status);
                return;
            }

            // Update the GUI here
            textBox1.AppendText(status);

        }

        private void onEnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //event sumbit message to server
                //check if empty or just spaces
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    //do something
                }else
                {
                    textBox2.Text = "";
                }

                
            }
        }
    }
}
