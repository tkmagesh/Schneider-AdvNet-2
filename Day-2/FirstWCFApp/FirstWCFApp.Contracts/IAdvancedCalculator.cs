using System.ServiceModel;

namespace FirstWCFApp.Contracts
{
    [ServiceContract]
    public interface IAdvancedCalculator
    {
        [OperationContract]
        CalculatorOutput Process(CalculatorInput Input);
    }
}