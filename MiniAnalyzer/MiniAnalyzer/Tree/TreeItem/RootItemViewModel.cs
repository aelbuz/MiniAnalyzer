using Common.Types;
using System.Collections.Generic;

namespace MiniAnalyzer.Tree.TreeItem
{
    public class RootItemViewModel : TreeItemViewModelBase
    {
        public RootItemViewModel(MiniProfiler profilerResult)
            : base(profilerResult.Name, profilerResult.DurationMilliseconds)
        {
            Model = profilerResult;

            var children = new List<TreeItemViewModelBase>();

            if (profilerResult.Root != null)
            {
                if (profilerResult.Root.Children != null)
                {
                    foreach (var child in profilerResult.Root.Children)
                    {
                        children.Add(new ParentTimingItemViewModel(child));
                    }
                }

                if (profilerResult.Root.CustomTimings != null)
                {
                    foreach (var child in profilerResult.Root.CustomTimings)
                    {
                        foreach (var customTiming in child.Value)
                        {
                            children.Add(new CustomTimingItemViewModel(child.Key, customTiming));
                        }
                    }
                }
            }

            Children = children;
        }

        public IEnumerable<TreeItemViewModelBase> Children { get; set; }

        internal MiniProfiler Model { get; private set; }
    }
}
