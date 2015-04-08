using CP.WcfDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace CP.WcfDemo.ConsoleHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var simpleServiceHost = new ServiceHost(typeof(SimpleService));
            var duplexServiceHost = new ServiceHost(typeof(DulplexService));
            try
            {
                simpleServiceHost.Opened += delegate { Console.WriteLine("SimpleService is ready！"); };
                duplexServiceHost.Opened += delegate { Console.WriteLine("DulplexService is ready！"); };

                simpleServiceHost.Open();
                duplexServiceHost.Open();
                Console.Read();
                simpleServiceHost.Close();
                duplexServiceHost.Close();
            }
            catch (Exception)
            {
                simpleServiceHost.Abort();
                duplexServiceHost.Abort();
            }
        }
    }
}
