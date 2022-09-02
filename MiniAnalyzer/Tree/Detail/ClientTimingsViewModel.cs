using Common.Types;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using Views.Common;

namespace MiniAnalyzer.Tree.Detail
{
    public class ClientTimingsViewModel : ViewModelBase
    {
        public ClientTimingsViewModel()
        {
            ClientTimings = new ObservableCollection<ClientTiming>();
        }

        public async Task LoadContentAsync(ClientTimings? clientTimings)
        {
            if (clientTimings == null)
            {
                Visibility = Visibility.Collapsed;
            }
            else
            {
                await LoadContentCoreAsync(clientTimings);

                Visibility = Visibility.Visible;
            }
        }

        private async Task LoadContentCoreAsync(ClientTimings clientTimings)
        {
            RedirectCount = clientTimings.RedirectCount;

            await Application.Current.Dispatcher.BeginInvoke(() =>
            {
                ClientTimings.Clear();

                if (clientTimings.Timings != null)
                {
                    foreach (var clientTiming in clientTimings.Timings)
                    {
                        ClientTimings.Add(new ClientTiming
                        {
                            Duration = clientTiming.Duration,
                            Name = clientTiming.Name,
                            Start = clientTiming.Start
                        });
                    }
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

        #region RedirectCount Property

        private int? redirectCount;

        public int? RedirectCount
        {
            get => redirectCount;
            private set
            {
                if (value != redirectCount)
                {
                    redirectCount = value;
                    OnPropertyChanged(nameof(RedirectCount));
                }
            }
        }

        #endregion 

        public ObservableCollection<ClientTiming> ClientTimings { get; private set; }
    }
}
