using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace FirstWCFApp.Contracts
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        int Add(int number1, int number2);
        
        [OperationContract]
        int Subtract(int number1, int number2);
        
        [OperationContract]
        [FaultContract(typeof(DivideByZeroDetails))]
        int Divide(int number1, int number2);
        
        [OperationContract]
        int Multiply(int number1, int number2);
    }
}
