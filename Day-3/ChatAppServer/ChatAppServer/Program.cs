using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ChatAppServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof (ChatServer));
            host.Opened += (sender, eventArgs) =>
                {
                    foreach (var endpoint in host.Description.Endpoints)
                    {
                        Console.WriteLine("{0},{1},{2}", endpoint.Address, endpoint.Binding.Name, endpoint.Contract.Name);
                    }
                    Console.WriteLine("Service running.. hit ENTER to shutdown");
                    Console.ReadLine();
                };
            host.Closed += (sender, eventArgs) =>
                {
                    Console.WriteLine("Service shutdown...");
                };
            host.Open();
         
        }
    }
}
