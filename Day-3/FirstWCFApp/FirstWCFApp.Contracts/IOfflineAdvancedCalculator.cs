using System.ServiceModel;

namespace FirstWCFApp.Contracts
{
    [ServiceContract]
    public interface IOfflineAdvancedCalculator
    {
        [OperationContract(IsOneWay = true, Name = "Calculate")]
        void Process(CalculatorInput Input);
    }
}