using System.Runtime.Serialization;

namespace Common.Types
{
    [DataContract]
    public class ClientTimings
    {
        [DataMember(Order = 1)]
        public int RedirectCount { get; set; }

        [DataMember(Order = 2, IsRequired = false)]
        public List<ClientTiming>? Timings { get; set; }
    }
}
