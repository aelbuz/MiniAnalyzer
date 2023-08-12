using System.Runtime.Serialization;

namespace Common.Types
{
    /// <summary>
    /// Contains properties of the MiniProfiler.ClientTimings class.
    /// </summary>
    /// <remarks>
    /// Times collected from the client.
    /// <para/>
    /// Documented from:
    /// https://github.com/MiniProfiler/dotnet/blob/main/src/MiniProfiler.Shared/ClientTimings.cs
    /// </remarks>
    [DataContract]
    public class ClientTimings
    {
        /// <summary>
        /// Gets or sets the redirect count.
        /// </summary>
        [DataMember(Order = 1)]
        public int RedirectCount { get; set; }

        /// <summary>
        /// Gets or sets the list of client side timings.
        /// </summary>
        [DataMember(Order = 2, IsRequired = false)]
        public List<ClientTiming>? Timings { get; set; }
    }
}
