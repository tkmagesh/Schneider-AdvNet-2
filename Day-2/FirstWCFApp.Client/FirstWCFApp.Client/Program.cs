using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using FirstWCFApp.Contracts;

namespace FirstWCFApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var channelFactory = new ChannelFactory<ICalculator>(new BasicHttpBinding());
            var calculator = channelFactory.CreateChannel(new EndpointAddress("http://localhost:8888/SchneiderServices/CalculatorService"));
            Console.ReadLine();
            Console.WriteLine(calculator.Add(100,200));
            Console.ReadLine();
            Console.WriteLine(calculator.Subtract(100,200));
            Console.ReadLine();
            Console.WriteLine(calculator.Divide(100,20));
            Console.ReadLine();
            Console.WriteLine(calculator.Multiply(100,200));
            Console.ReadLine();
        }
    }
}
