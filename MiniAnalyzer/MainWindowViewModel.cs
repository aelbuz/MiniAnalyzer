using Common.Types;
using MiniAnalyzer.Tree;
using MiniAnalyzer.Tree.Detail;
using MiniAnalyzer.Tree.TreeItem;
using System;
using System.Collections.Generic;
using System.Linq;
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
            LoadLineSeparatedJsonFileCommand = new RelayCommand(async () => await GetLineSeparatedJsonTextAsync());
            LoadJsonTextCommand = new RelayCommand<JsonLoadType>(async (loadType) => await GetJsonTextAsync(loadType));

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
                TimingResult.Visibility = Visibility.Collapsed;
                CustomTimingResult.Visibility = Visibility.Collapsed;

                await RootResult.LoadContentAsync(rootResult.Model);
            }
            else
            {
                if (e is CustomTimingItemViewModel customTimingResult)
                {
                    RootResult.Visibility = Visibility.Collapsed;
                    TimingResult.Visibility = Visibility.Collapsed;

                    await CustomTimingResult.LoadContentAsync(customTimingResult.Key, customTimingResult.Model);

                    return;
                }

                RootResult.Visibility = Visibility.Collapsed;
                CustomTimingResult.Visibility = Visibility.Collapsed;

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

        public ICommand LoadLineSeparatedJsonFileCommand { get; private set; }

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

        private JsonContentType? loadType;

        public JsonContentType? LoadType
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
            string openFileDialogFilter = string.Format("JSON File|*{0}", FileConstants.JsonFileExtension);
            string openFileDialogTitle = "Load JSON File";
            string filePath = string.Empty;

            if (FileDialogHelper.ShowOpenFileDialog(openFileDialogFilter, openFileDialogTitle, ref filePath))
            {
                await ReadJsonFileAsync(filePath);
            }
        }

        internal async Task ReadJsonFileAsync(string filePath)
        {
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                string? jsonContent = JsonFileReader.ReadJsonFile(filePath);
                bool success = await LoadJsonAsync(jsonContent, JsonLoadType.Load);

                if (success)
                {
                    LoadType = JsonContentType.File;
                    JsonFileName = filePath;
                }
            }
        }

        private async Task<bool> LoadJsonAsync(string? jsonContent, JsonLoadType loadType)
        {
            var miniProfiler = await Task.Run(() => JsonDeserializer.DeserializeAsMiniProfiler(jsonContent));
            if (miniProfiler != null)
            {
                HideAllDetailsView();
                await LoadContentAsync(miniProfiler, loadType);
                return true;
            }
            else
            {
                MessageBoxHelper.ShowMessageBox(MessageBoxMessage.InvalidJsonContent);
                return false;
            }
        }

        private async Task GetLineSeparatedJsonTextAsync()
        {
            string openFileDialogFilter = string.Format("Line Separated JSON File|*{0}|Text File|*{1}",
                                                        FileConstants.JsonFileExtension, FileConstants.TextFileExtension);
            string openFileDialogTitle = "Load Line Separated JSON File";
            string filePath = string.Empty;

            if (FileDialogHelper.ShowOpenFileDialog(openFileDialogFilter, openFileDialogTitle, ref filePath))
            {
                await ReadLineSeparatedJsonFileAsync(filePath);
            }
        }

        private async Task ReadLineSeparatedJsonFileAsync(string filePath)
        {
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                var jsonLines = JsonFileReader.ReadLineSeparatedJsonFile(filePath);
                bool success = await LoadLineSeparatedJsonAsync(jsonLines);

                if (success)
                {
                    LoadType = JsonContentType.File;
                    JsonFileName = filePath;
                }
            }
        }

        private async Task<bool> LoadLineSeparatedJsonAsync(string[]? jsonLines)
        {
            var deserializedProfilers = await Task.Run(() => JsonDeserializer.DeserializeAsMiniProfiler(jsonLines));
            if (deserializedProfilers == null)
            {
                MessageBoxHelper.ShowMessageBox(MessageBoxMessage.InvalidLineSeparatedJsonContent);
                return false;
            }

            HideAllDetailsView();
            await LoadContentAsync(deserializedProfilers);

            if (deserializedProfilers.Count() != jsonLines.Length)
            {
                MessageBoxHelper.ShowMessageBox(MessageBoxMessage.InvalidJsonLines);
            }

            return true;
        }

        private async Task GetJsonTextAsync(JsonLoadType loadType)
        {
            string title = loadType == JsonLoadType.Load ? "Load JSON Text" : "Append JSON Text";

            using (var multilineTextBox = new MultilineTextBoxViewModel(title))
            {
                if (!multilineTextBox.IsCanceled)
                {
                    string? jsonContent = multilineTextBox.Text;
                    bool success = await LoadJsonAsync(jsonContent, loadType);

                    if (success)
                    {
                        LoadType = JsonContentType.Text;
                        JsonFileName = string.Empty;
                    }
                }
            }
        }

        private async Task LoadContentAsync(MiniProfiler miniProfiler, JsonLoadType loadType)
        {
            IsLoaded = false;
            await ResultTree.LoadTreeAsync(miniProfiler, loadType);
        }

        private async Task LoadContentAsync(IEnumerable<MiniProfiler> miniProfilers)
        {
            IsLoaded = false;
            await ResultTree.LoadTreeAsync(miniProfilers);
        }

        private void HideAllDetailsView()
        {
            RootResult.Visibility = Visibility.Collapsed;
            TimingResult.Visibility = Visibility.Collapsed;
            CustomTimingResult.Visibility = Visibility.Collapsed;
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
