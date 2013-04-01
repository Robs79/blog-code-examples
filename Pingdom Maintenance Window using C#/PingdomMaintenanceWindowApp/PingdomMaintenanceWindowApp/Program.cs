using System;

namespace PingdomMaintenanceWindowApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Pingdom Maintenance Window options:");
                Console.WriteLine("");
                Console.WriteLine("start");
                Console.WriteLine("stop");
                Console.WriteLine("");
                Console.WriteLine("e.g. PingdomMaintenanceWindowApp.exe start");
                Console.WriteLine("");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                string command = args[0];

                var maintenanceWindow = new PingdomMaintenanceWindow();

                if(command == "start")
                {
                    Console.WriteLine("Starting maintenance window...");
                    maintenanceWindow.Start();
                } 
                else if (command == "stop")
                {
                    Console.WriteLine("Stopping maintenance window...");
                    maintenanceWindow.Stop();
                }
                else
                {
                    Console.WriteLine("Unknown command: {0}", command);
                    return;
                }

                Console.WriteLine("");
                Console.WriteLine(maintenanceWindow.Message);
            }
        }
    }
}
