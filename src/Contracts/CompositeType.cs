using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CP.WcfDemo.Contracts
{
    // Use a data contract as illustrated in the sample below to add composite types to service operations
    [DataContract]
    public partial class CompositeType
    {
        [DataMember]
        public bool BoolValue { get; set; }

        [DataMember]
        public string StringValue { get; set; }
    }
}
