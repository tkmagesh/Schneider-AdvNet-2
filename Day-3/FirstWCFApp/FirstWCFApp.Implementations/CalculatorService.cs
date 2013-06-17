using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using FirstWCFApp.Contracts;

namespace FirstWCFApp.Implementations
{
    [ServiceBehavior]
    public class CalculatorService : ICalculator, IAdvancedCalculator, IOfflineAdvancedCalculator
    {
        [OperationBehavior]
        public int Add(int number1, int number2)
        {
            Console.WriteLine("Request received for adding number {0} and {1}",number1,number2);
            return number1 + number2;
        }

        [OperationBehavior]
        public int Subtract(int number1, int number2)
        {
            Console.WriteLine("Request received for subtracting number {1} from {0}", number1, number2);
            return number1 - number2;
        }

        [OperationBehavior]
        public int Divide(int number1, int number2)
        {
            Console.WriteLine("Request received for dividng number {0} by {1}", number1, number2);
            if (number2 == 0)
            {
                var exceptionDetails = new DivideByZeroDetails()
                    {
                        Number1 = number1,
                        Number2 = number2,
                        Operation = "Divide",
                        Message = string.Format("Cannot divide {0} by zero", number1)
                    };
                throw new FaultException<DivideByZeroDetails>(exceptionDetails);
            }
            return number1 / number2;

        }

        

        [OperationBehavior]
        public int Multiply(int number1, int number2)
        {
            Console.WriteLine("Request received for multiplying number {0} and {1}", number1, number2);
            return number1*number2;
        }

        [OperationBehavior]
        public CalculatorOutput Process(CalculatorInput Input)
        {
            var result = 0;
            switch (Input.Operation)
            {
                case "Add" :
                    result = Add(Input.Number1, Input.Number2);
                    break;
                case "Subtract":
                    result = Subtract(Input.Number1, Input.Number2);
                    break;
                case "Multiply":
                    result = Multiply(Input.Number1, Input.Number2);
                    break;
                case "Divide":
                    result = Divide(Input.Number1, Input.Number2);
                    break;
            }
            return new CalculatorOutput()
                {
                    Number1 = Input.Number1,
                    Number2 = Input.Number2,
                    Operation = Input.Operation,
                    Result = result

                };
        }

        [OperationBehavior]
        void IOfflineAdvancedCalculator.Process(CalculatorInput Input)
        {
            Console.WriteLine(Process(Input));
            
        }
    }
}
