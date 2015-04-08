using CP.WcfDemo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace CP.WcfDemo.ConsoleClient
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SimpleServiceCustomProxy : ClientBase<ISimpleService>, ISimpleService
    {
        #region ctor
        public SimpleServiceCustomProxy()
        {
        }

        public SimpleServiceCustomProxy(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public SimpleServiceCustomProxy(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public SimpleServiceCustomProxy(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public SimpleServiceCustomProxy(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }
        #endregion

        public string GetData(int value)
        {
            return base.Channel.GetData(value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            return base.Channel.GetDataUsingDataContract(composite);
        }
    }
}
