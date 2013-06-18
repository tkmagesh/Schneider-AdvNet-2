using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using FirstWCFApp.WsdlClient.ServiceProxies;

namespace FirstWCFApp.WsdlClient
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var calculator = new CalculatorClient("NetTcpBinding_ICalculator");
                Console.ReadLine();
                Console.WriteLine(calculator.Add(100, 200));
                Console.ReadLine();
                Console.WriteLine(calculator.Subtract(100, 0));
                Console.ReadLine();
                Console.WriteLine(calculator.Divide(100, 10));
                Console.ReadLine();

                Console.WriteLine(calculator.Multiply(100, 200));
            }
            catch (FaultException<DivideByZeroDetails> dzd)
            {
                Console.WriteLine(dzd.Detail.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
/*
            var input = new CalculatorInput {Number1 = 100, Number2 = 200, Operation = "Add"};
            var advancedCalculatorClient = new AdvancedCalculatorClient();
            CalculatorOutput calculatorOutput = advancedCalculatorClient.Process(input);
            Console.WriteLine(calculatorOutput);
*/

//            Console.ReadLine();
     /*       var operations = new string[] {"Add", "Subtract", "Multiply", "Divide"};
            var client = new OfflineAdvancedCalculatorClient();
            for (var i = 1; i < 20;i++ )
                client.Calculate(new CalculatorInput()
                    {
                        Number1 = new Random().Next(100),
                        Number2 = new Random().Next(200),
                        Operation = operations[new Random().Next(0,3)]

                    });*/
            Console.WriteLine("Done");
               Console.ReadLine();
        }
    }
}
