using System.Runtime.Serialization;

namespace Common.Types
{
    [DataContract]
    public class Timing
    {
        [DataMember(Order = 1)]
        public Guid Id { get; set; }

        [DataMember(Order = 2)]
        public string? Name { get; set; }

        [DataMember(Order = 3)]
        public decimal? DurationMilliseconds { get; set; }

        [DataMember(Order = 4)]
        public decimal StartMilliseconds { get; set; }

        [DataMember(Order = 5, IsRequired = false)]
        public List<Timing>? Children { get; set; }

        [DataMember(Order = 6, IsRequired = false)]
        public Dictionary<string, List<CustomTiming>>? CustomTimings { get; set; }

        [DataMember(Order = 7, IsRequired = false)]
        public TimingDebugInfo? DebugInfo { get; set; }
    }
}
