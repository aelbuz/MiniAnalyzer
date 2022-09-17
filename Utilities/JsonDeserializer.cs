using Common.Types;
using System.Text.Json;

namespace Utilities
{
    public class JsonDeserializer
    {
        public static MiniProfiler? DeserializeAsMiniProfiler(string jsonContent)
        {
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

        public static Timing? DeserializeAsTiming(string jsonContent)
        {
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
