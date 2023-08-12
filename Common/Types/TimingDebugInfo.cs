using System.Runtime.Serialization;

namespace Common.Types
{
    /// <summary>
    /// Contains properties of the MiniProfiler.TimingDebugInfo class.
    /// </summary>
    /// <remarks>
    /// Debug info for a timing, only present when <c>MiniProfiler.Options.EnableDebugMode</c> is set in options.
    /// <para/>
    /// Documented from:
    /// https://github.com/MiniProfiler/dotnet/blob/main/src/MiniProfiler.Shared/TimingDebugInfo.cs
    /// </remarks>
    [DataContract]
    public class TimingDebugInfo
    {
        /// <summary>
        /// An (already-encoded) HTML representation of the call stack.
        /// </summary>
        [DataMember(Order = 1, IsRequired = false)]
        public string? RichHtmlStack { get; set; }

        /// <summary>
        /// The index of the stack frame that common frames with parent start at
        /// (e.g. happened in the parent timing, before this).
        /// </summary>
        [DataMember(Order = 2, IsRequired = false)]
        public int? CommonStackStart { get; set; }
    }
}
