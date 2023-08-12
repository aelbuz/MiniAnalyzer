namespace MiniAnalyzer
{
    /// <summary>
    /// Defines load types of a JSON content.
    /// </summary>
    public enum JsonLoadType
    {
        /// <summary>
        /// Load a new JSON content (and ignore the previous JSON content).
        /// </summary>
        Load,

        /// <summary>
        /// Append a JSON content onto the previous JSON content.
        /// </summary>
        Append,
    }
}
