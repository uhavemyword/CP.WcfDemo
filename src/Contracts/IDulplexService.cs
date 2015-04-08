using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CP.WcfDemo.Contracts
{
    [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface IDulplexService
    {
        [OperationContract(IsOneWay = true)]
        void Add(double x, double y);

        [OperationContract]
        void Subscribe();

        [OperationContract]
        void UnSubscribe();
    }
}
