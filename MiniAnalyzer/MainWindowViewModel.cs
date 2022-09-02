using Common.Types;
using Microsoft.Win32;
using MiniAnalyzer.Tree;
using MiniAnalyzer.Tree.TreeItem;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Utilities;
using Views.Common;

namespace MiniAnalyzer
{
    public class MainWindowViewModel : ViewModelBase, IDisposable
    {
        public MainWindowViewModel()
        {
            IsLoaded = true;
            LoadJsonFileCommand = new RelayCommand(async () => await OpenJsonFileAsync());
            LoadJsonTextCommand = new RelayCommand(async () => await GetJsonTextAsync());

            ResultTree = new ResultTreeViewModel();
            ResultTree.OnSelectedItemChanged += ResultTree_OnSelectedItemChanged;

            RootResult = new RootResultViewModel();
            TimingResult = new TimingResultViewModel();
            CustomTimingResult = new CustomTimingResultViewModel();
        }

        private async void ResultTree_OnSelectedItemChanged(object? sender, TreeItemViewModelBase e)
        {
            if (e is RootItemViewModel rootResult)
            {
                TimingResult.IsVisible = Visibility.Collapsed;
                CustomTimingResult.IsVisible = Visibility.Collapsed;

                await RootResult.LoadContentAsync(rootResult.Model);
            }
            else
            {
                if (e is CustomTimingItemViewModel customTimingResult)
                {
                    RootResult.IsVisible = Visibility.Collapsed;
                    TimingResult.IsVisible = Visibility.Collapsed;

                    await CustomTimingResult.LoadContentAsync(customTimingResult.Key, customTimingResult.Model);

                    return;
                }

                RootResult.IsVisible = Visibility.Collapsed;
                CustomTimingResult.IsVisible = Visibility.Collapsed;

                Timing? timingModel = null;
                if (e is ParentTimingItemViewModel parentResult)
                {
                    timingModel = parentResult.Model;
                }
                else if (e is LeafTimingItemViewModel leafTimingResult)
                {
                    timingModel = leafTimingResult.Model;
                }

                if (timingModel != null)
                {
                    await TimingResult.LoadContentAsync(timingModel);
                }
            }
        }

        public ICommand LoadJsonFileCommand { get; private set; }

        public ICommand LoadJsonTextCommand { get; private set; }

        #region IsLoaded Property

        private bool isLoaded;

        public bool IsLoaded
        {
            get => isLoaded;
            private set
            {
                if (isLoaded != value)
                {
                    isLoaded = value;
                    OnPropertyChanged(nameof(IsLoaded));
                }
            }
        }

        #endregion

        #region LoadType Property

        private JsonLoadType? loadType;

        public JsonLoadType? LoadType
        {
            get => loadType;
            private set
            {
                if (value != loadType)
                {
                    loadType = value;
                    OnPropertyChanged(nameof(LoadType));
                }
            }
        }

        #endregion

        #region JsonFileName Property

        private string? jsonFileName;

        public string? JsonFileName
        {
            get => jsonFileName;
            private set
            {
                if (value != jsonFileName)
                {
                    jsonFileName = value;
                    OnPropertyChanged(nameof(JsonFileName));
                }
            }
        }

        #endregion 

        public ResultTreeViewModel ResultTree { get; private set; }

        public RootResultViewModel RootResult { get; private set; }

        public TimingResultViewModel TimingResult { get; private set; }

        public CustomTimingResultViewModel CustomTimingResult { get; private set; }

        private async Task OpenJsonFileAsync()
        {
            var openFileDialog = new OpenFileDialog()
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = string.Format("JSON File|*{0}", FileConstants.JsonExtension),
                Multiselect = false,
                Title = "Load JSON File"
            };

            if (openFileDialog.ShowDialog() ?? false)
            {
                string filePath = openFileDialog.FileName;
                await LoadJsonFileAsync(filePath);
            }
        }

        internal async Task LoadJsonFileAsync(string filePath)
        {
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                bool success = await LoadJsonAsync(jsonContent);

                if (success)
                {
                    LoadType = JsonLoadType.File;
                    JsonFileName = filePath;
                }
            }
        }

        private async Task<bool> LoadJsonAsync(string? jsonContent)
        {
            MiniProfiler? miniProfiler = null;

            if (!string.IsNullOrWhiteSpace(jsonContent))
            {
                miniProfiler = await Task.Run(() => JsonHelper.DeserializeAsMiniProfiler(jsonContent));
            }

            if (miniProfiler != null)
            {
                HideAllDetailsView();
                await LoadContentAsync(miniProfiler);
                return true;
            }
            else
            {
                MessageBox.Show(Application.Current.MainWindow, "Given JSON content is not valid.", "JSON Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private async Task GetJsonTextAsync()
        {
            using (var multilineTextBox = new MultilineTextBoxViewModel("Load JSON Text"))
            {
                if (!multilineTextBox.IsCanceled)
                {
                    string? jsonContent = multilineTextBox.Text;
                    bool success = await LoadJsonAsync(jsonContent);

                    if (success)
                    {
                        LoadType = JsonLoadType.Text;
                        JsonFileName = string.Empty;
                    }
                }
            }
        }

        private async Task LoadContentAsync(MiniProfiler miniProfiler)
        {
            IsLoaded = false;
            await ResultTree.LoadTreeAsync(miniProfiler);
        }

        private void HideAllDetailsView()
        {
            RootResult.IsVisible = Visibility.Collapsed;
            TimingResult.IsVisible = Visibility.Collapsed;
            CustomTimingResult.IsVisible = Visibility.Collapsed;
        }

        #region Dispose Methods

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        protected bool IsDisposed { get; private set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="nongc"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool nongc)
        {
            if (!IsDisposed && nongc)
            {
                ResultTree.OnSelectedItemChanged -= ResultTree_OnSelectedItemChanged;
            }

            IsDisposed = true;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        ~MainWindowViewModel()
        {
            Dispose(false);
        }

        #endregion
    }
}
