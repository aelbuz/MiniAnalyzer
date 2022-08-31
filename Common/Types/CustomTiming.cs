using System.Runtime.Serialization;

namespace Common.Types
{
    [DataContract]
    public class CustomTiming
    {
        [DataMember(Order = 1)]
        public Guid Id { get; set; }

        [DataMember(Order = 2, IsRequired = false)]
        public string? CommandString { get; set; }

        [DataMember(Order = 3, IsRequired = false)]
        public string? ExecuteType { get; set; }

        [DataMember(Order = 4, IsRequired = false)]
        public string? StackTraceSnippet { get; set; }

        [DataMember(Order = 5)]
        public decimal StartMilliseconds { get; set; }

        [DataMember(Order = 6, IsRequired = false)]
        public decimal? DurationMilliseconds { get; set; }

        [DataMember(Order = 7, IsRequired = false)]
        public decimal? FirstFetchDurationMilliseconds { get; set; }

        [DataMember(Order = 8)]
        public bool Errored { get; set; }
    }
}
