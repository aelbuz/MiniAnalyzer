using System.Globalization;

namespace MiniAnalyzer.Tree.TreeItem
{
    /// <summary>
    /// Defines base functionalities of an item view-model.
    /// </summary>
    public class TreeItemViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TreeItemViewModelBase"/> class.
        /// </summary>
        /// <param name="name">Name of the item view-model.</param>
        /// <param name="durationMilliseconds">Duration of the result.</param>
        public TreeItemViewModelBase(string? name, decimal? durationMilliseconds)
        {
            Header = string.Format(CultureInfo.InvariantCulture, "{0} - ({1} ms)", name, durationMilliseconds);
        }

        /// <summary>
        /// Gets the header of this item view-model.
        /// </summary>
        public string? Header { get; private set; }
    }
}
