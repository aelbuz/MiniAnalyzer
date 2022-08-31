using System.Runtime.Serialization;

namespace Common.Types
{
    [DataContract]
    public class TimingDebugInfo
    {
        [DataMember(Order = 1, IsRequired = false)]
        public string? RichHtmlStack { get; set; }

        [DataMember(Order = 2, IsRequired = false)]
        public int? CommonStackStart { get; set; }
    }
}
