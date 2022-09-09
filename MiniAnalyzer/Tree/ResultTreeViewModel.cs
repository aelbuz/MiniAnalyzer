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
            if (Items.Count > 0)
            {
                Items.Clear();
            }

            var items = await CreateItemsAsync(profilerResult);

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        public async Task LoadTreeAsync(IEnumerable<MiniProfiler> profilerResults)
        {
            if (Items.Count > 0)
            {
                Items.Clear();
            }

            foreach (var profilerResult in profilerResults)
            {
                var items = await CreateItemsAsync(profilerResult);

                foreach (var item in items)
                {
                    Items.Add(item);
                }
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
