using CP.WcfDemo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CP.WcfDemo.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class DulplexService : IDulplexService
    {
        private static int _index = 0;

        public DulplexService()
        {
            Console.WriteLine("DulplexService {0} created!", ++_index);
        }
        public void Add(double x, double y)
        {
            Publisher.Instance.NotifyMessage(string.Format("Server - method Add({0},{1}) get called.", x, y));
            double result = x + y;
            ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            callback.DisplayResult(result);
        }

        public void Subscribe()
        {
            Publisher.Instance.Register(OperationContext.Current.GetCallbackChannel<ICallback>());
        }

        public void UnSubscribe()
        {
            Publisher.Instance.UnRegister(OperationContext.Current.GetCallbackChannel<ICallback>());
        }
    }
}
