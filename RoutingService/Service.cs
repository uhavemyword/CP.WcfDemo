namespace CP.WcfDemo.RoutingService
{
    using System;
    using System.ServiceProcess;

    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //request additional time for a pending operation, to prevent the Service Control Manager (SCM) from marking the service as not responding.
            this.RequestAdditionalTime(60000);

            try
            {
                Program.StartServices();
            }
            catch
            {
                Environment.Exit(-1);
            }
        }

        protected override void OnStop()
        {
            Program.StopServices();
        }
    }
}