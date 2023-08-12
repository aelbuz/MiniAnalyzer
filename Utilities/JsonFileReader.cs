namespace Utilities
{
    /// <summary>
    /// Contains static methods for reading JSON files.
    /// </summary>
    public static class JsonFileReader
    {
        /// <summary>
        /// Reads the JSON file from the given file path.
        /// </summary>
        /// <param name="filePath">Path of the JSON file.</param>
        /// <returns>A string that contains the content of the JSON file in the given file path.</returns>
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

        /// <summary>
        /// Reads the line separated JSON file from the given file path.
        /// </summary>
        /// <param name="filePath">Path of the JSON file.</param>
        /// <returns>An array of strings that contains the content of the JSON file in the given file path.</returns>
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
