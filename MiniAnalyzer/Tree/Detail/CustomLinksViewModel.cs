using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using Views.Common;

namespace MiniAnalyzer.Tree.Detail
{
    public class CustomLinksViewModel : ViewModelBase
    {
        public CustomLinksViewModel()
        {
            CustomLinks = new ObservableCollection<CustomLink>();
        }

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

        #region Visibility Property

        private Visibility visibility;

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

        public ObservableCollection<CustomLink> CustomLinks { get; private set; }
    }
}
