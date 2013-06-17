using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using FirstWCFApp.Contracts;
using FirstWCFApp.Implementations;

namespace FirstWCFApp.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceHost = new ServiceHost(typeof (CalculatorService));
           /* serviceHost.Description.Behaviors.Add(new ServiceMetadataBehavior()
                {
                    HttpGetEnabled = true,
                    HttpGetUrl = new Uri("http://localhost:9090/Metadata")
                });
            serviceHost.AddServiceEndpoint(typeof(ICalculator), new BasicHttpBinding(), "http://localhost:9090/SchneiderServices/CalculatorService") ;*/
            serviceHost.Opened += (sender, eventArgs) =>
                {
                    Console.WriteLine("Service running... hit ENTER to shutdown");
                    foreach (var endpoint in serviceHost.Description.Endpoints)
                    {
                        Console.WriteLine("{0},{1},{2}", endpoint.Contract.Name
                            ,endpoint.Binding.Name
                            ,endpoint.Address.Uri.ToString());
                    }
                    Console.ReadLine();
                    serviceHost.Close();
                };
            serviceHost.Closed += (sender, eventArgs) =>
                {
                    Console.WriteLine("Service shutdown...");
                    Console.ReadLine();
                };
            serviceHost.Open();
        }
    }
}
