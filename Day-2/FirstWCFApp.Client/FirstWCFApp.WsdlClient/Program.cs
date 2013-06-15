using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirstWCFApp.WsdlClient.ServiceProxies;

namespace FirstWCFApp.WsdlClient
{
    class Program
    {
        static void Main(string[] args)
        {
/*
            var calculator = new ServiceProxies.CalculatorClient("NetTcpBinding_ICalculator");
            Console.ReadLine();
            Console.WriteLine(calculator.Add(100, 200));
            Console.ReadLine();
            Console.WriteLine(calculator.Subtract(100, 200));
            Console.ReadLine();
            Console.WriteLine(calculator.Divide(100, 20));
            Console.ReadLine();
            Console.WriteLine(calculator.Multiply(100, 200));
            var input = new CalculatorInput {Number1 = 100, Number2 = 200, Operation = "Add"};
            var advancedCalculatorClient = new AdvancedCalculatorClient();
            CalculatorOutput calculatorOutput = advancedCalculatorClient.Process(input);
            Console.WriteLine(calculatorOutput);*/

            Console.ReadLine();
            var operations = new string[] {"Add", "Subtract", "Multiply", "Divide"};
            var client = new OfflineAdvancedCalculatorClient();
            for (var i = 1; i < 20;i++ )
                client.Calculate(new CalculatorInput()
                    {
                        Number1 = new Random().Next(100),
                        Number2 = new Random().Next(200),
                        Operation = operations[new Random().Next(0,3)]

                    });
            Console.WriteLine("Done");
                Console.ReadLine();
        }
    }

    namespace ServiceProxies
    {
        public partial class CalculatorOutput
        {
            public override string ToString()
            {
                return string.Format("Number1 = {0}, Number2 = {1}, Operation = {2}, Result = {3}", Number1, Number2,
                                     Operation, Result);
            }
        }
    }

}
