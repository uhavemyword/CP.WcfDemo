using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CP.WcfDemo.Contracts;

namespace CP.WcfDemo.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class SimpleService : ISimpleService
    {
        private static int _index = 0;

        public SimpleService()
        {
            Console.WriteLine("SimpleService {0} created!", ++_index);
        }

        public string GetData(int value)
        {
            return string.Format("Server - You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            composite.StringValue += string.Format("Server - The BoolValue is {0}.", composite.BoolValue);
            return composite;
        }
    }
}
