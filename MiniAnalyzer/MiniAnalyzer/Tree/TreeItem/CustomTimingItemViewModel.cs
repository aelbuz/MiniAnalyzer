using Common.Types;

namespace MiniAnalyzer.Tree.TreeItem
{
    public class CustomTimingItemViewModel : TreeItemViewModelBase
    {
        private const string CustomTimingName = "Custom Timing";

        public CustomTimingItemViewModel(string key, CustomTiming model)
            : base(string.Format("{0} ({1})", key, CustomTimingName), model.DurationMilliseconds)
        {
            Key = key;
            Model = model;
        }

        internal string Key { get; private set; }

        internal CustomTiming Model { get; private set; }
    }
}
