using Common.Types;
using System.Text.Json;

namespace Utilities
{
    /// <summary>
    /// Contains static methods for deserializing JSON string to profiler models.
    /// </summary>
    public static class JsonDeserializer
    {
        /// <summary>
        /// Deserializes the given JSON content to <see cref="MiniProfiler"/> model.
        /// </summary>
        /// <param name="jsonContent">JSON content to deserialize.</param>
        /// <returns>
        /// Deserialized <see cref="MiniProfiler"/> model if given <paramref name="jsonContent"/> is valid;
        /// otherwise <c>null</c>.
        /// </returns>
        public static MiniProfiler? DeserializeAsMiniProfiler(string? jsonContent)
        {
            if (string.IsNullOrWhiteSpace(jsonContent))
            {
                return null;
            }

            try
            {
                var miniProfiler = JsonSerializer.Deserialize<MiniProfiler>(jsonContent);
                return miniProfiler;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Deserializes the given JSON content array to an enumerable of <see cref="MiniProfiler"/> models.
        /// </summary>
        /// <param name="jsonContents">An array that contains the JSON contents.</param>
        /// <returns>
        /// An enumerable of deserialized <see cref="MiniProfiler"/> models
        /// if given <paramref name="jsonContents"/> is valid; otherwise <c>null</c>.
        /// </returns>
        public static IEnumerable<MiniProfiler>? DeserializeAsMiniProfiler(string[]? jsonContents)
        {
            if (jsonContents == null)
            {
                return null;
            }

            var miniProfilers = new List<MiniProfiler>();

            foreach (var jsonContent in jsonContents)
            {
                var miniProfiler = DeserializeAsMiniProfiler(jsonContent);
                if (miniProfiler != null)
                {
                    miniProfilers.Add(miniProfiler);
                }
            }

            return miniProfilers.Count > 0 ? miniProfilers : null;
        }

        /// <summary>
        /// Deserializes the given JSON content to <see cref="Timing"/> model.
        /// </summary>
        /// <param name="jsonContent">JSON content to deserialize.</param>
        /// <returns>
        /// Deserialized <see cref="Timing"/> model if given <paramref name="jsonContent"/> is valid;
        /// otherwise <c>null</c>.
        /// </returns>
        public static Timing? DeserializeAsTiming(string? jsonContent)
        {
            if (string.IsNullOrWhiteSpace(jsonContent))
            {
                return null;
            }

            try
            {
                var timing = JsonSerializer.Deserialize<Timing>(jsonContent);
                return timing;
            }
            catch
            {
                return null;
            }
        }
    }
}
