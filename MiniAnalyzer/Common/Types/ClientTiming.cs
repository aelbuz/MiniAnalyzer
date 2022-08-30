using System.Runtime.Serialization;

namespace Common.Types
{
    [DataContract]
    public class ClientTiming
    {
        [DataMember(Order = 1)]
        public string? Name { get; set; }

        [DataMember(Order = 2)]
        public decimal Start { get; set; }

        [DataMember(Order = 3)]
        public decimal Duration { get; set; }
    }
}
