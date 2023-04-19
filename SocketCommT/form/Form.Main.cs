using SocketCommT.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketCommT
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void bserver_Click(object sender, EventArgs e)
        {
            Hide();
            FormServer formServer = new FormServer(this);
            formServer.Show();
        }

        private void bclient_Click(object sender, EventArgs e)
        {
            Hide();
            FormClient formClient = new FormClient();
            formClient.Show();
        }
    }
}
