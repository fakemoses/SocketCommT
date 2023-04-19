using SocketcommT.server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocketCommT;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SocketCommT.form
{
    public partial class FormServer : Form
    {
        private Server serv;
        private readonly Form mainForm;
        private readonly Thread serverThread;

        public FormServer(Form mainForm)
        {
            InitializeComponent();
            serverThread = new Thread(StartServer);
            serverThread.Start();
            this.mainForm = mainForm;
        }

        private void StartServer()
        {
            // Start the server here
            serv = new Server(6000, textBox1);
            serv.Start();
        }

        private void bexit_Click(object sender, EventArgs e)
        {
            serv.Stop();
            serverThread.Join();
            Close();
            mainForm.Show();
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

        
    }
}
