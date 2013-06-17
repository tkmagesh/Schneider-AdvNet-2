namespace FirstWCFApp.WsdlClient.ServiceProxies
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