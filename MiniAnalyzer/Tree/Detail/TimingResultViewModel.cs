using Common.Types;
using System.Threading.Tasks;
using System.Windows;
using Views.Common;

namespace MiniAnalyzer.Tree.Detail
{
    /// <summary>
    /// Defines functionalities of the timing result view-model.
    /// </summary>
    public class TimingResultViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimingResultViewModel"/> class.
        /// </summary>
        public TimingResultViewModel()
        {
            Visibility = Visibility.Collapsed;

            TimingDebugInfo = new TimingDebugInfoViewModel();
            TimeChart = new TimeChartView();
        }

        /// <summary>
        /// Loads the content with given timing model asynchronously.
        /// </summary>
        /// <param name="timing">Timing model.</param>
        /// <returns>A task.</returns>
        public async Task LoadContentAsync(Timing timing)
        {
            await LoadContentCoreAsync(timing);
        }

        #region Id Property

        private string? id;

        /// <summary>
        /// Gets the unique identifier of this timing (MiniProfiler property).
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
        /// Gets the timing name (MiniProfiler property).
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

        #region DurationMilliseconds Property

        private decimal? durationMilliseconds;

        /// <summary>
        /// Gets the value of how long this timing step took (MiniProfiler property).
        /// </summary>
        public decimal? DurationMilliseconds
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

        #region StartMilliseconds Property

        private decimal startMilliseconds;

        /// <summary>
        /// Gets the offset from the start of profiling (MiniProfiler property).
        /// </summary>
        public decimal StartMilliseconds
        {
            get => startMilliseconds;
            private set
            {
                if (value != startMilliseconds)
                {
                    startMilliseconds = value;
                    OnPropertyChanged(nameof(StartMilliseconds));
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
        /// Gets the timing debug info view-model.
        /// </summary>
        public TimingDebugInfoViewModel TimingDebugInfo { get; private set; }

        /// <summary>
        /// Gets the time chart of this result.
        /// </summary>
        public TimeChartView TimeChart { get; private set; }

        private async Task LoadContentCoreAsync(Timing timing)
        {
            await Task.Run(async () =>
            {
                Id = timing.Id.ToString();
                Name = timing.Name;
                DurationMilliseconds = timing.DurationMilliseconds;
                StartMilliseconds = timing.StartMilliseconds;

                await TimingDebugInfo.LoadContentAsync(timing.DebugInfo);
                await TimeChart.UpdateTimesAsync(timing);

                Visibility = Visibility.Visible;
            });
        }
    }
}
