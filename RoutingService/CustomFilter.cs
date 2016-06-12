namespace CP.WcfDemo.RoutingService
{
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;

    public class CustomFilter : MessageFilter
    {
        private static int _counter;
        private static Dictionary<string, int> _clientFilterMapping = new Dictionary<string, int>(); //Key: Client address, Value: Filter index

        private int _currentIndex;

        public CustomFilter(string filterData)
        {
            _currentIndex = _counter++;
        }

        public override bool Match(Message message)
        {
            var endpointProperty = message.Properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            string clientAddress = string.Format("{0}:{1}", endpointProperty.Address, endpointProperty.Port);
            //var context = OperationContext.Current.EndpointDispatcher.EndpointAddress;

            if (!_clientFilterMapping.ContainsKey(clientAddress))
            {
                var connectionCount = new Dictionary<int, int>();
                for (int i = 0; i < _counter; i++)
                {
                    connectionCount[i] = _clientFilterMapping.Count(x => x.Value == i);
                }
                var fewestContectedIndex = connectionCount.OrderBy(x => x.Value).First().Key;
                _clientFilterMapping[clientAddress] = fewestContectedIndex;
                System.Console.WriteLine("Client:{0} will connect to Service {1}", clientAddress, fewestContectedIndex);
            }

            return _clientFilterMapping[clientAddress] == _currentIndex;
        }

        public override bool Match(MessageBuffer buffer)
        {
            return Match(buffer.CreateMessage());
        }
    }
}