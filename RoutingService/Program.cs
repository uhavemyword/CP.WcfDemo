namespace CP.WcfDemo.RoutingService
{
    using System;
    using System.ServiceModel;
    using System.ServiceProcess;

    public class Program
    {
        private static ServiceHost _routerHost;

        public static void Main(string[] args)
        {
            if ((args != null && args.Length == 1 && (args[0] == "-console" || args[0] == "/console")) || System.Environment.UserInteractive)
            {
                // run as console app
                Console.Run();
            }
            else
            {
                // run as windows service
                ServiceBase[] servicesToRun;
                servicesToRun = new ServiceBase[] { new Service() };
                ServiceBase.Run(servicesToRun);
            }
        }

        public static void StartServices()
        {
            try
            {
                System.Console.WriteLine("MyRoutingService - starting...");

                _routerHost = new ServiceHost(typeof(System.ServiceModel.Routing.RoutingService));
                //_routerHost.Opened += delegate { _log.Info("MyRoutingService is ready."); };
                _routerHost.Open();
                System.Console.WriteLine(string.Format("MyRoutingService on machine {0} STARTED!", Environment.MachineName));

                foreach (var channelDispatchers in _routerHost.ChannelDispatchers)
                {
                    System.Console.WriteLine("MyRoutingService listening on host '{0}' port '{1}' ({2})", channelDispatchers.Listener.Uri.Host, channelDispatchers.Listener.Uri.Port, channelDispatchers.Listener.Uri.ToString());
                }
            }
            catch (Exception ex)
            {
                string error = "Unhandled fatal application exception occured during service initialization.";
                System.Console.WriteLine(error, ex);
                throw;
            }
        }

        public static void StopServices()
        {
            System.Console.WriteLine("MyRoutingService - stopping...");
            _routerHost.Close();
            System.Console.WriteLine(string.Format("MyRoutingService on machine {0} STOPPED!", Environment.MachineName));
        }
    }
}