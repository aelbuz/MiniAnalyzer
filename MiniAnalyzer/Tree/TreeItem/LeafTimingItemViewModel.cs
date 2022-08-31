using Common.Types;

namespace MiniAnalyzer.Tree.TreeItem
{
    public class LeafTimingItemViewModel : TreeItemViewModelBase
    {
        public LeafTimingItemViewModel(Timing model)
            : base(model.Name, model.DurationMilliseconds)
        {
            Model = model;
        }

        internal Timing Model { get; private set; }
    }
}
