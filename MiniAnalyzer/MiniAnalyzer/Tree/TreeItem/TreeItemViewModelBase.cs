using System.Globalization;

namespace MiniAnalyzer.Tree.TreeItem
{
    public class TreeItemViewModelBase
    {
        public TreeItemViewModelBase(string? name, decimal? durationMilliseconds)
        {
            Header = string.Format(CultureInfo.InvariantCulture, "{0} - ({1} ms)", name, durationMilliseconds);
        }

        public string? Header { get; private set; }
    }
}
