using System.Runtime.Serialization;

namespace Common.Types
{
    /// <summary>
    /// Contains properties of the MiniProfiler.CustomTiming class.
    /// </summary>
    /// <remarks>
    /// A custom timing that usually represents a Remote Procedure Call, allowing better
    /// visibility into these longer-running calls.
    /// <para/>
    /// Documented from:
    /// https://github.com/MiniProfiler/dotnet/blob/main/src/MiniProfiler.Shared/CustomTiming.cs
    /// </remarks>
    [DataContract]
    public class CustomTiming
    {
        /// <summary>
        /// Unique identifier for this <see cref="CustomTiming"/>.
        /// </summary>
        [DataMember(Order = 1)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the command that was executed, e.g. "select * from Table" or "INCR my:redis:key".
        /// </summary>
        [DataMember(Order = 2, IsRequired = false)]
        public string? CommandString { get; set; }

        /// <summary>
        /// Short name describing what kind of custom timing this is, e.g. "Get", "Query", "Fetch".
        /// </summary>
        [DataMember(Order = 3, IsRequired = false)]
        public string? ExecuteType { get; set; }

        /// <summary>
        /// Gets or sets roughly where in the calling code that this custom timing was executed.
        /// </summary>
        [DataMember(Order = 4, IsRequired = false)]
        public string? StackTraceSnippet { get; set; }

        /// <summary>
        /// Gets or sets the offset from main <c>MiniProfiler</c> start that this custom command began.
        /// </summary>
        [DataMember(Order = 5)]
        public decimal StartMilliseconds { get; set; }

        /// <summary>
        /// Gets or sets how long this custom command statement took to execute.
        /// </summary>
        [DataMember(Order = 6, IsRequired = false)]
        public decimal? DurationMilliseconds { get; set; }

        /// <summary>
        /// OPTIONAL - how long this timing took to come back initially from the remote server,
        /// before all data is fetched and command is completed.
        /// </summary>
        [DataMember(Order = 7, IsRequired = false)]
        public decimal? FirstFetchDurationMilliseconds { get; set; }

        /// <summary>
        /// Whether this operation errored.
        /// </summary>
        [DataMember(Order = 8)]
        public bool Errored { get; set; }
    }
}
