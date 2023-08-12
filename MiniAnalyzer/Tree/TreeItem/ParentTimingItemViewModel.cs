using Common.Types;
using System.Collections.Generic;

namespace MiniAnalyzer.Tree.TreeItem
{
    /// <summary>
    /// Defines functionalities of a parent timing item view-model.
    /// </summary>
    public class ParentTimingItemViewModel : TreeItemViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParentTimingItemViewModel"/> class.
        /// </summary>
        /// <param name="model">Timing model.</param>
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

        /// <summary>
        /// Gets the children tree items of this view-model.
        /// </summary>
        public IEnumerable<TreeItemViewModelBase> Children { get; private set; }

        /// <summary>
        /// Gets the model of this item view-model.
        /// </summary>
        internal Timing Model { get; private set; }
    }
}
