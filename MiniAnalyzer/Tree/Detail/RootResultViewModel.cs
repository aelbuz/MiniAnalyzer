using Common.Types;
using System.Threading.Tasks;
using System.Windows;
using Views.Common;

namespace MiniAnalyzer.Tree.Detail
{
    /// <summary>
    /// Defines functionalities of the root result view-model.
    /// </summary>
    public class RootResultViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RootResultViewModel"/> class.
        /// </summary>
        public RootResultViewModel()
        {
            Visibility = Visibility.Collapsed;

            CustomLinks = new CustomLinksViewModel();
            ClientTimings = new ClientTimingsViewModel();
            TimeChart = new TimeChartView();
        }

        /// <summary>
        /// Loads the content with given profiler model asynchronously.
        /// </summary>
        /// <param name="profilerResult">Profiler model.</param>
        /// <returns>A task.</returns>
        public async Task LoadContentAsync(MiniProfiler profilerResult)
        {
            await LoadContentCoreAsync(profilerResult);
        }

        #region Id Property

        private string? id;

        /// <summary>
        /// Gets the profiler ID (MiniProfiler property).
        /// </summary>
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

        /// <summary>
        /// Gets the display name for this profiling session (MiniProfiler property).
        /// </summary>
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

        /// <summary>
        /// Gets the value of when this profiler was instantiated, in UTC time (MiniProfiler property).
        /// </summary>
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

        /// <summary>
        /// Gets the milliseconds, to one decimal place, that this profiler ran (MiniProfiler property).
        /// </summary>
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

        /// <summary>
        /// Gets the machine name where this profiler was run.
        /// </summary>
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

        /// <summary>
        /// Gets a string identifying the user/client that is profiling this request (MiniProfiler property).
        /// </summary>
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

        /// <summary>
        /// Gets or sets the visibility state of this view-model.
        /// </summary>
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

        /// <summary>
        /// Gets the custom links view-model.
        /// </summary>
        public CustomLinksViewModel CustomLinks { get; private set; }

        /// <summary>
        /// Gets the client timings view-model.
        /// </summary>
        public ClientTimingsViewModel ClientTimings { get; private set; }

        /// <summary>
        /// Gets the time chart of this result.
        /// </summary>
        public TimeChartView TimeChart { get; private set; }

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
    }
}
