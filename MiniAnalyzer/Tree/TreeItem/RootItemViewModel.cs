using Common.Types;
using System.Collections.Generic;

namespace MiniAnalyzer.Tree.TreeItem
{
    /// <summary>
    /// Defines functionalities of the root timing item view-model.
    /// This is the main item view-model at the top of the tree.
    /// </summary>
    public class RootItemViewModel : TreeItemViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RootItemViewModel"/> class.
        /// </summary>
        /// <param name="profilerResult">Profiler result model.</param>
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

        /// <summary>
        /// Gets the children tree items of this view-model.
        /// </summary>
        public IEnumerable<TreeItemViewModelBase> Children { get; private set; }

        /// <summary>
        /// Gets the model of this item view-model.
        /// </summary>
        internal MiniProfiler Model { get; private set; }
    }
}
