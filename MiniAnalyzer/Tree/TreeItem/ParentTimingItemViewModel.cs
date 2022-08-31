using Common.Types;
using System.Collections.Generic;

namespace MiniAnalyzer.Tree.TreeItem
{
    public class ParentTimingItemViewModel : TreeItemViewModelBase
    {
        public ParentTimingItemViewModel(Timing model)
            : base(model.Name, model.DurationMilliseconds)
        {
            Model = model;

            var children = new List<TreeItemViewModelBase>();

            if (model.Children != null)
            {
                foreach (var child in model.Children)
                {
                    if (child.Children == null)
                    {
                        children.Add(new LeafTimingItemViewModel(child));
                    }
                    else
                    {
                        children.Add(new ParentTimingItemViewModel(child));
                    }
                }
            }

            if (model.CustomTimings != null)
            {
                foreach (var child in model.CustomTimings)
                {
                    foreach (var customTiming in child.Value)
                    {
                        children.Add(new CustomTimingItemViewModel(child.Key, customTiming));
                    }
                }
            }

            Children = children;
        }

        public IEnumerable<TreeItemViewModelBase> Children { get; set; }

        internal Timing Model { get; private set; }
    }
}
