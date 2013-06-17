﻿using System.Runtime.Serialization;

namespace FirstWCFApp.Contracts
{
    [DataContract]
    public class CalculatorInput
    {
        [DataMember]
        public int Number1 { get; set; }

        [DataMember]
        public int Number2 { get; set; }

        [DataMember]
        public string Operation { get; set; }
    }
}