using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using ChatAppServer.Services;

namespace ChatAppWindowsService
{
    public partial class ChatService : ServiceBase
    {
        public ChatService()
        {
            InitializeComponent();
        }

        private ServiceHost host; 
        protected override void OnStart(string[] args)
        {
            host = new ServiceHost(typeof(ChatServer));
            host.Open();

        }

        protected override void OnStop()
        {
            host.Close();
        }
    }
}
