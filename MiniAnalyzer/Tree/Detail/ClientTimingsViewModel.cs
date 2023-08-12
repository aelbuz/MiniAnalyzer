using Common.Types;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using Views.Common;

namespace MiniAnalyzer.Tree.Detail
{
    /// <summary>
    /// Defines functionalities of the client timings view-model.
    /// </summary>
    public class ClientTimingsViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientTimingsViewModel"/> class.
        /// </summary>
        public ClientTimingsViewModel()
        {
            ClientTimings = new ObservableCollection<ClientTiming>();
        }

        /// <summary>
        /// Loads the content with given client timings model asynchronously.
        /// </summary>
        /// <param name="clientTimings">Client timings model.</param>
        /// <returns>A task.</returns>
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

        #region RedirectCount Property

        private int? redirectCount;

        /// <summary>
        /// Gets the redirect count (MiniProfiler property).
        /// </summary>
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

        /// <summary>
        /// Gets the client timing collection (MiniProfiler property).
        /// </summary>
        public ObservableCollection<ClientTiming> ClientTimings { get; private set; }

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
    }
}
