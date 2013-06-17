using System.Runtime.Serialization;

namespace FirstWCFApp.Contracts
{
    [DataContract]
    public class DivideByZeroDetails
    {
        [DataMember]
        public int Number1 { get; set; }
        
        [DataMember]
        public int Number2 { get; set; }
        
        [DataMember]
        public string Operation { get; set; }
        
        [DataMember]
        public string Message { get; set; }
    }
}