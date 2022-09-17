using Common.Types;
using MiniAnalyzer.Tree.TreeItem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Views.Common;

namespace MiniAnalyzer.Tree
{
    public class ResultTreeViewModel : ViewModelBase
    {
        public ResultTreeViewModel()
        {
            Items = new ObservableCollection<TreeItemViewModelBase>();
        }

        public async Task LoadTreeAsync(MiniProfiler profilerResult)
        {
            ClearItems();

            await AddItemsAsync(profilerResult);
        }

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

        private async Task<IEnumerable<TreeItemViewModelBase>> CreateItemsAsync(MiniProfiler profilerResult)
        {
            var items = new List<TreeItemViewModelBase>();

            await Task.Run(() =>
            {
                items.Add(new RootItemViewModel(profilerResult));
            });

            return items;
        }

        public ObservableCollection<TreeItemViewModelBase> Items { get; private set; }

        #region SelectedItem Property

        private TreeItemViewModelBase? selectedItem;

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

        public event EventHandler<TreeItemViewModelBase>? OnSelectedItemChanged;

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
