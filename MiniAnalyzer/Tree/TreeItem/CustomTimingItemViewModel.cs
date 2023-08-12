using Common.Types;

namespace MiniAnalyzer.Tree.TreeItem
{
    /// <summary>
    /// Defines functionalities of a custom timing item view-model.
    /// </summary>
    public class CustomTimingItemViewModel : TreeItemViewModelBase
    {
        private const string CustomTimingName = "Custom Timing";

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomTimingItemViewModel"/> class.
        /// </summary>
        /// <param name="key">Custom timing key.</param>
        /// <param name="model">Custom timing model.</param>
        public CustomTimingItemViewModel(string key, CustomTiming model)
            : base(string.Format("{0} ({1})", key, CustomTimingName), model.DurationMilliseconds)
        {
            Key = key;
            Model = model;
        }

        /// <summary>
        /// Gets the custom timing key.
        /// </summary>
        internal string Key { get; private set; }

        /// <summary>
        /// Gets the model of this item view-model.
        /// </summary>
        internal CustomTiming Model { get; private set; }
    }
}
