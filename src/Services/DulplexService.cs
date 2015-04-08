using CP.WcfDemo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CP.WcfDemo.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class DulplexService : IDulplexService
    {
        public void Add(double x, double y)
        {
            double result = x + y;
            ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            callback.DisplayResult(result);
            Publisher.Instance.NotifyMessage(string.Format("Server - method Add({0},{1}) get called.", x, y));
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
