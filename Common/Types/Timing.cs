using System.Runtime.Serialization;

namespace Common.Types
{
    /// <summary>
    /// Contains properties of the MiniProfiler.Timing class.
    /// </summary>
    /// <remarks>
    /// An individual profiling step that can contain child steps.
    /// <para/>
    /// Documented from:
    /// https://github.com/MiniProfiler/dotnet/blob/main/src/MiniProfiler.Shared/Timing.cs
    /// </remarks>
    [DataContract]
    public class Timing
    {
        /// <summary>
        /// Gets or sets unique identifier for this timing; set during construction.
        /// </summary>
        [DataMember(Order = 1)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets text displayed when this Timing is rendered.
        /// </summary>
        [DataMember(Order = 2)]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets how long this Timing step took in ms; includes any <see cref="Children"/> Timings' durations.
        /// </summary>
        [DataMember(Order = 3)]
        public decimal? DurationMilliseconds { get; set; }

        /// <summary>
        /// Gets or sets the offset from the start of profiling.
        /// </summary>
        [DataMember(Order = 4)]
        public decimal StartMilliseconds { get; set; }

        /// <summary>
        /// Gets or sets all sub-steps that occur within this Timing step.
        /// </summary>
        [DataMember(Order = 5, IsRequired = false)]
        public List<Timing>? Children { get; set; }

        /// <summary>
        /// <see cref="CustomTiming"/> lists keyed by their type, e.g. "sql", "memcache", "redis", "http".
        /// </summary>
        [DataMember(Order = 6, IsRequired = false)]
        public Dictionary<string, List<CustomTiming>>? CustomTimings { get; set; }

        /// <summary>
        /// Present only when <c>MiniProfiler.Options.EnableDebugMode</c> is <c>true</c>,
        /// additional step info in-memory only.
        /// </summary>
        [DataMember(Order = 7, IsRequired = false)]
        public TimingDebugInfo? DebugInfo { get; set; }
    }
}
