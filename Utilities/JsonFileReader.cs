namespace Utilities
{
    public static class JsonFileReader
    {
        public static string? ReadJsonFile(string filePath)
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath);
                return jsonContent;
            }
            catch
            {
                return null;
            }
        }

        public static string[]? ReadLineSeparatedJsonFile(string filePath)
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath);
                var jsonLines = jsonContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);

                return jsonLines;
            }
            catch
            {
                return null;
            }
        }
    }
}
