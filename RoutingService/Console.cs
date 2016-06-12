namespace CP.WcfDemo.RoutingService
{
    using System.Threading;

    public static class Console
    {
        public static void Run()
        {
            System.Console.WriteLine("====== Run as console app ======");

            try
            {
                Program.StartServices();
            }
            catch
            {
                System.Console.WriteLine("====== The service could not be started. ======");
                System.Console.WriteLine("Press any key to exit . . .");
                System.Console.ReadKey(true);
                System.Environment.Exit(-1);
            }

            System.Console.WriteLine("Press 'Q' to quit.");

            while (System.Console.Read() != (int)'Q')
            {
                Thread.Sleep(1000);
            }

            Program.StopServices();
        }
    }
}