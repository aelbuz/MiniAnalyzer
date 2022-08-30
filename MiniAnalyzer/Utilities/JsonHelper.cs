using Common.Types;
using System.Text.Json;

namespace Utilities
{
    public class JsonHelper
    {
        public static MiniProfiler? DeserializeAsMiniProfiler(string miniProfilerJson)
        {
            try
            {
                var miniProfiler = JsonSerializer.Deserialize<MiniProfiler>(miniProfilerJson);
                return miniProfiler;
            }
            catch
            {
                return null;
            }
        }

        public static Timing? DeserializeAsTiming(string timingJson)
        {
            try
            {
                var timing = JsonSerializer.Deserialize<Timing>(timingJson);
                return timing;
            }
            catch
            {
                return null;
            }
        }
    }
}
