using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using Views.Common;

namespace MiniAnalyzer.Tree.Detail
{
    /// <summary>
    /// Defines functionalities of the custom links view-model.
    /// </summary>
    public class CustomLinksViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomLinksViewModel"/> class.
        /// </summary>
        public CustomLinksViewModel()
        {
            CustomLinks = new ObservableCollection<CustomLink>();
        }

        /// <summary>
        /// Loads the content with given custom link dictionary asynchronously.
        /// </summary>
        /// <param name="customLinks">A dictionary that contains the custom links.</param>
        /// <returns>A task.</returns>
        public async Task LoadContentAsync(Dictionary<string, string>? customLinks)
        {
            if (customLinks == null)
            {
                Visibility = Visibility.Collapsed;
            }
            else
            {
                await LoadContentCoreAsync(customLinks);

                Visibility = Visibility.Visible;
            }
        }

        #region Visibility Property

        private Visibility visibility;

        /// <summary>
        /// Gets the visibility state of this view-model.
        /// </summary>
        public Visibility Visibility
        {
            get => visibility;
            private set
            {
                if (value != visibility)
                {
                    visibility = value;
                    OnPropertyChanged(nameof(Visibility));
                }
            }
        }

        #endregion 

        /// <summary>
        /// Gets the custom link collection (MiniProfiler property).
        /// </summary>
        public ObservableCollection<CustomLink> CustomLinks { get; private set; }

        private async Task LoadContentCoreAsync(Dictionary<string, string> customLinks)
        {
            await Application.Current.Dispatcher.BeginInvoke(() =>
            {
                CustomLinks.Clear();

                foreach (var customLink in customLinks)
                {
                    CustomLinks.Add(new CustomLink(customLink.Key, customLink.Value));
                }
            });
        }
    }
}
