using System.Runtime.Serialization;

namespace Common.Types
{
    /// <summary>
    /// Contains properties of the MiniProfiler.ClientTiming class.
    /// </summary>
    /// <remarks>
    /// A client timing probe.
    /// <para/>
    /// Documented from:
    /// https://github.com/MiniProfiler/dotnet/blob/main/src/MiniProfiler.Shared/ClientTiming.cs
    /// </remarks>
    [DataContract]
    public class ClientTiming
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Order = 1)]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        [DataMember(Order = 2)]
        public decimal Start { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        [DataMember(Order = 3)]
        public decimal Duration { get; set; }
    }
}
