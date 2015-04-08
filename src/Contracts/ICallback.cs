using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace CP.WcfDemo.Contracts
{
    [ServiceContract]
    public interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void DisplayResult(double result);

        [OperationContract(IsOneWay = true)]
        void RespondToNotification(string message);
    }
}
