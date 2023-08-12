using System.Runtime.Serialization;

namespace Common.Types
{
    /// <summary>
    /// Contains properties of the MiniProfiler class.
    /// </summary>
    /// <remarks>
    /// A single MiniProfiler can be used to represent any number of steps/levels in a call-graph, via Step().
    /// <para/>
    /// Documented from:
    /// https://github.com/MiniProfiler/dotnet/blob/main/src/MiniProfiler.Shared/MiniProfiler.cs
    /// </remarks>
    [DataContract]
    public class MiniProfiler
    {
        /// <summary>
        /// Gets or sets the profiler id.
        /// Identifies this Profiler so it may be stored/cached.
        /// </summary>
        [DataMember(Order = 1)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a display name for this profiling session.
        /// </summary>
        [DataMember(Order = 2)]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets when this profiler was instantiated, in UTC time.
        /// </summary>
        [DataMember(Order = 3)]
        public DateTime Started { get; set; }

        /// <summary>
        /// Gets the milliseconds, to one decimal place, that this MiniProfiler ran.
        /// </summary>
        [DataMember(Order = 4)]
        public decimal DurationMilliseconds { get; set; }

        /// <summary>
        /// Gets or sets where this profiler was run.
        /// </summary>
        [DataMember(Order = 5, IsRequired = false)]
        public string? MachineName { get; set; }

        /// <summary>
        /// Keys are names, values are URLs, allowing additional links to be added to a profiler result,
        /// e.g. perhaps a deeper diagnostic page for the current request.
        /// </summary>
        [DataMember(Order = 6, IsRequired = false)]
        public Dictionary<string, string>? CustomLinks { get; set; }

        /// <summary>
        /// Gets or sets the root timing.
        /// The first timing that is created and started when this profiler is instantiated.
        /// All other timings will be children of this one.
        /// </summary>
        [DataMember(Order = 7, IsRequired = false)]
        public Timing? Root { get; set; }

        /// <summary>
        /// Gets or sets timings collected from the client.
        /// </summary>
        [DataMember(Order = 8, IsRequired = false)]
        public ClientTimings? ClientTimings { get; set; }

        /// <summary>
        /// Gets or sets a string identifying the user/client that is profiling this request.
        /// </summary>
        [DataMember(Order = 9, IsRequired = false)]
        public string? User { get; set; }

        /// <summary>
        /// Returns <c>true</c> when this MiniProfiler has been viewed by the <see cref="User"/> that recorded it.
        /// </summary>
        [DataMember(Order = 10, IsRequired = false)]
        public bool HasUserViewed { get; set; }
    }
}
