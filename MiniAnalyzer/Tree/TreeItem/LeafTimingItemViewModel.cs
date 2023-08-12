using Common.Types;

namespace MiniAnalyzer.Tree.TreeItem
{
    /// <summary>
    /// Defines functionalities of a leaf timing item view-model.
    /// </summary>
    public class LeafTimingItemViewModel : TreeItemViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeafTimingItemViewModel"/> class.
        /// </summary>
        /// <param name="model">Timing model.</param>
        public LeafTimingItemViewModel(Timing model)
            : base(model.Name, model.DurationMilliseconds)
        {
            Model = model;
        }

        /// <summary>
        /// Gets the model of this item view-model.
        /// </summary>
        internal Timing Model { get; private set; }
    }
}
