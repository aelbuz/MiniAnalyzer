using Common.Types;
using MiniAnalyzer.Tree.TreeItem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Views.Common;

namespace MiniAnalyzer.Tree
{
    /// <summary>
    /// Defines functionalities of the result tree view-model.
    /// </summary>
    public class ResultTreeViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultTreeViewModel"/> class.
        /// </summary>
        public ResultTreeViewModel()
        {
            Items = new ObservableCollection<TreeItemViewModelBase>();
        }

        /// <summary>
        /// Gets the items of the tree.
        /// </summary>
        public ObservableCollection<TreeItemViewModelBase> Items { get; private set; }

        #region SelectedItem Property

        private TreeItemViewModelBase? selectedItem;

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        public TreeItemViewModelBase? SelectedItem
        {
            get => selectedItem;
            internal set
            {
                if (value != selectedItem)
                {
                    selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        #endregion

        /// <summary>
        /// Occurs when the selected item has changed on the tree.
        /// </summary>
        public event EventHandler<TreeItemViewModelBase>? OnSelectedItemChanged;

        /// <summary>
        /// Loads the tree with given profiler result and JSON load type asynchronously.
        /// </summary>
        /// <param name="profilerResult">Profiler result.</param>
        /// <param name="loadType">JSON load type.</param>
        /// <returns>A task.</returns>
        public async Task LoadTreeAsync(MiniProfiler profilerResult, JsonLoadType loadType)
        {
            if (loadType == JsonLoadType.Load)
            {
                ClearItems();
            }

            await AddItemsAsync(profilerResult);
        }

        /// <summary>
        /// Loads the tree with given a list of profiler result asynchronously.
        /// </summary>
        /// <param name="profilerResults"></param>
        /// <returns>A task.</returns>
        public async Task LoadTreeAsync(IEnumerable<MiniProfiler> profilerResults)
        {
            ClearItems();

            foreach (var profilerResult in profilerResults)
            {
                await AddItemsAsync(profilerResult);
            }
        }

        private void ClearItems()
        {
            if (Items.Count > 0)
            {
                Items.Clear();
            }
        }

        private async Task AddItemsAsync(MiniProfiler profilerResult)
        {
            var items = await CreateItemsAsync(profilerResult);

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        private static async Task<IEnumerable<TreeItemViewModelBase>> CreateItemsAsync(MiniProfiler profilerResult)
        {
            var items = new List<TreeItemViewModelBase>();

            await Task.Run(() =>
            {
                items.Add(new RootItemViewModel(profilerResult));
            });

            return items;
        }

        /// <inheritdoc/>
        public override void OnPropertyChanged(string propertyName)
        {
            if (propertyName == nameof(SelectedItem) && SelectedItem != null)
            {
                OnSelectedItemChanged?.Invoke(this, SelectedItem);
            }

            base.OnPropertyChanged(propertyName);
        }
    }
}
