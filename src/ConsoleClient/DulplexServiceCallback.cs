using CP.WcfDemo.ConsoleClient.DulplexServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CP.WcfDemo.ConsoleClient
{
    public class DulplexServiceCallback : IDulplexServiceCallback
    {
        public void DisplayResult(double result)
        {
            Console.WriteLine("Client - Display result: {0}", result);
        }

        public void RespondToNotification(string message)
        {
            Console.WriteLine("Client - Respond To Publisher's Notification: " + message);
        }
    }
}
