using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;

namespace CP.WcfDemo.WindowsServiceHost
{
    public partial class Service : ServiceBase
    {
        private ServiceHost host1 = null;
        private ServiceHost host2 = null;

        public Service()
        {
            InitializeComponent();
            this.ServiceName = "CP.WcfDemo Service";
        }

        protected override void OnStart(string[] args)
        {
            if (host1 != null && host1.State == CommunicationState.Opened)
            {
                host1.Close();
            }
            if (host2 != null && host2.State == CommunicationState.Opened)
            {
                host2.Close();
            }

            host1 = new ServiceHost(typeof(CP.WcfDemo.Services.SimpleService));
            host1.Open();
            host2 = new ServiceHost(typeof(CP.WcfDemo.Services.DulplexService));
            host2.Open();
        }

        protected override void OnStop()
        {
            if (host1 != null && host1.State == CommunicationState.Opened)
            {
                host1.Close();
                host1 = null;
            }
            if (host2 != null && host2.State == CommunicationState.Opened)
            {
                host2.Close();
                host2 = null;
            }
        }
    }
}
