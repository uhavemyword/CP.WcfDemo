using CP.WcfDemo.ConsoleClient.DulplexServiceReference;
using CP.WcfDemo.ConsoleClient.SimpleServiceReference;
using CP.WcfDemo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace CP.WcfDemo.ConsoleClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var simpleServiceClient = new SimpleServiceClient();
            var simpleServiceCustomClient = new SimpleServiceCustomProxy(new BasicHttpBinding(), new System.ServiceModel.EndpointAddress(@"http://localhost:8123/SimpleService/"));
            var dulplexServiceClient = new DulplexServiceClient(new System.ServiceModel.InstanceContext(new DulplexServiceCallback()));
            var dulplexServiceClient2 = new DulplexServiceClient(new System.ServiceModel.InstanceContext(new DulplexServiceCallback()));
            try
            {
                Console.WriteLine("Client - Start.");
                Console.WriteLine(simpleServiceClient.GetData(5));
                Console.WriteLine(simpleServiceCustomClient.GetData(2));
                var obj = new Contracts.CompositeType();
                obj.BoolValue = true;
                obj.StringValue = "hello";
                var obj1 = simpleServiceCustomClient.GetDataUsingDataContract(obj);
                var obj2 = simpleServiceClient.GetDataUsingDataContract(obj);
                simpleServiceClient.Close();

                dulplexServiceClient.Subscribe();
                dulplexServiceClient2.Subscribe();
                dulplexServiceClient2.Subscribe();
                dulplexServiceClient2.UnSubscribe();
                dulplexServiceClient2.UnSubscribe();
                dulplexServiceClient2.UnSubscribe();
                dulplexServiceClient2.Close();
                dulplexServiceClient.Add(7, 8);
                //dulplexServiceClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                simpleServiceClient.Abort();
                dulplexServiceClient.Abort();
            }
            Console.Read();
        }
    }
}
