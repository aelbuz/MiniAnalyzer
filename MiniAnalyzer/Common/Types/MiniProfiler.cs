using System.Runtime.Serialization;

namespace Common.Types
{
    [DataContract]
    public class MiniProfiler
    {
        [DataMember(Order = 1)]
        public Guid Id { get; set; }

        [DataMember(Order = 2)]
        public string? Name { get; set; }

        [DataMember(Order = 3)]
        public DateTime Started { get; set; }

        [DataMember(Order = 4)]
        public decimal DurationMilliseconds { get; set; }

        [DataMember(Order = 5, IsRequired = false)]
        public string? MachineName { get; set; }

        [DataMember(Order = 6, IsRequired = false)]
        public Dictionary<string, string>? CustomLinks { get; set; }

        [DataMember(Order = 7, IsRequired = false)]
        public Timing? Root { get; set; }

        [DataMember(Order = 8, IsRequired = false)]
        public ClientTimings? ClientTimings { get; set; }

        [DataMember(Order = 9, IsRequired = false)]
        public string? User { get; set; }

        [DataMember(Order = 10, IsRequired = false)]
        public bool HasUserViewed { get; set; }
    }
}
