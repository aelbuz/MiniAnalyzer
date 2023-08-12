namespace MiniAnalyzer.Tree.Detail
{
    /// <summary>
    /// Defines properties of a custom link (MiniProfiler property).
    /// </summary>
    public class CustomLink
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomLink"/> class.
        /// </summary>
        /// <param name="name">Custom link name.</param>
        /// <param name="url">Custom link URL.</param>
        public CustomLink(string name, string url)
        {
            Name = name;
            URL = url;
        }

        /// <summary>
        /// Gets or sets the custom link name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the custom link URL.
        /// </summary>
        public string URL { get; set; }
    }
}
