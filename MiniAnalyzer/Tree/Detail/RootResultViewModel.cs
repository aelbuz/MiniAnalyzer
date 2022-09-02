using Common.Types;
using System.Threading.Tasks;
using System.Windows;
using Views.Common;

namespace MiniAnalyzer.Tree.Detail
{
    public class RootResultViewModel : ViewModelBase
    {
        public RootResultViewModel()
        {
            Visibility = Visibility.Collapsed;

            CustomLinks = new CustomLinksViewModel();
            ClientTimings = new ClientTimingsViewModel();
            TimeChart = new TimeChartView();
        }

        public async Task LoadContentAsync(MiniProfiler profilerResult)
        {
            await LoadContentCoreAsync(profilerResult);
        }

        private async Task LoadContentCoreAsync(MiniProfiler profilerResult)
        {
            await Task.Run(async () =>
            {
                Id = profilerResult.Id.ToString();
                Name = profilerResult.Name;
                Started = profilerResult.Started.ToString();
                DurationMilliseconds = profilerResult.DurationMilliseconds;
                MachineName = profilerResult.MachineName;
                User = profilerResult.User;

                await CustomLinks.LoadContentAsync(profilerResult.CustomLinks);
                await ClientTimings.LoadContentAsync(profilerResult.ClientTimings);

                if (profilerResult.Root != null)
                {
                    await TimeChart.UpdateTimesAsync(profilerResult.Root);
                }

                Visibility = Visibility.Visible;
            });
        }

        #region Id Property

        private string? id;

        public string? Id
        {
            get => id;
            private set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        #endregion

        #region Name Property

        private string? name;

        public string? Name
        {
            get => name;
            private set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        #endregion

        #region Started Property

        private string? started;

        public string? Started
        {
            get => started;
            private set
            {
                if (value != started)
                {
                    started = value;
                    OnPropertyChanged(nameof(Started));
                }
            }
        }

        #endregion

        #region DurationMilliseconds Property

        private decimal durationMilliseconds;

        public decimal DurationMilliseconds
        {
            get => durationMilliseconds;
            private set
            {
                if (value != durationMilliseconds)
                {
                    durationMilliseconds = value;
                    OnPropertyChanged(nameof(DurationMilliseconds));
                }
            }
        }

        #endregion

        #region MachineName Property

        private string? machineName;

        public string? MachineName
        {
            get => machineName;
            private set
            {
                if (value != machineName)
                {
                    machineName = value;
                    OnPropertyChanged(nameof(MachineName));
                }
            }
        }

        #endregion

        #region User Property

        private string? user;

        public string? User
        {
            get => user;
            private set
            {
                if (value != user)
                {
                    user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        #endregion

        #region Visibility Property

        private Visibility visibility;

        public Visibility Visibility
        {
            get => visibility;
            internal set
            {
                if (value != visibility)
                {
                    visibility = value;
                    OnPropertyChanged(nameof(Visibility));
                }
            }
        }

        #endregion

        public CustomLinksViewModel CustomLinks { get; private set; }

        public ClientTimingsViewModel ClientTimings { get; private set; }

        public TimeChartView TimeChart { get; private set; }
    }
}
