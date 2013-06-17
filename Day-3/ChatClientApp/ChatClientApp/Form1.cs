using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using ChatClientApp.ServiceProxies;

namespace ChatClientApp
{
    public partial class Form1 : Form, IChatServerCallback
    {
        private ChatServerClient chatServerClient;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var name = txtName.Text;
            chatServerClient = new ServiceProxies.ChatServerClient(new InstanceContext(this));
            chatServerClient.Login(name);
            btnLogin.Enabled = false;
            txtMessage.Enabled = btnSendMessage.Enabled = true;
        }

        public void ReceiveMessage(string message)
        {
            lstMessages.Items.Add(message);
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            var message = txtMessage.Text;
            chatServerClient.SendMessage(message);
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
