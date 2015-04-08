using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CP.WcfDemo.Contracts;

namespace CP.WcfDemo.Services
{
    /// <summary>
    /// Reference to http://www.cnblogs.com/ShadowLoki/archive/2012/08/30/2663931.html
    /// </summary>
    public class Publisher
    {
        private static readonly Lazy<Publisher> instance = new Lazy<Publisher>(() => new Publisher());

        /// <summary>
        /// Callback channel list
        /// </summary>
        private HashSet<ICallback> callbackChannelList = new HashSet<ICallback>();

        public static Publisher Instance
        {
            get { return instance.Value; }
        }

        protected Publisher()
        {
        }

        public void Register(ICallback callbackChannel)
        {
            if (callbackChannelList.Add(callbackChannel))
            {
                Console.WriteLine("Server - New channel added.");
            }
        }

        public void UnRegister(ICallback callbackChannel)
        {
            if (callbackChannelList.Remove(callbackChannel))
            {
                Console.WriteLine("Server - Channel removed.");
            }
        }

        /// <summary>
        /// Broadcast message.
        /// </summary>
        /// <param name="message"></param>
        public void NotifyMessage(string message)
        {
            if (callbackChannelList.Count > 0)
            {
                // temp variable to avoid changes to channel list during processing.
                ICallback[] callbackChannels = callbackChannelList.ToArray();

                foreach (var channel in callbackChannels)
                {
                    try
                    {
                        channel.RespondToNotification(message);
                    }
                    catch
                    {
                        // handle the error channel.
                        callbackChannelList.Remove(channel);
                    }
                }
            }
        }
    }
}
