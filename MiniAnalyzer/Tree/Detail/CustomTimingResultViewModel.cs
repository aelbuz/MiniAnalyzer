using Common.Types;
using System.Threading.Tasks;
using System.Windows;
using Views.Common;

namespace MiniAnalyzer.Tree.Detail
{
    /// <summary>
    /// Defines functionalities of the custom timing result view-model.
    /// </summary>
    public class CustomTimingResultViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomTimingResultViewModel"/> class.
        /// </summary>
        public CustomTimingResultViewModel()
        {
            Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Loads the content with given custom timing key and model asynchronously.
        /// </summary>
        /// <param name="customTimingKey">Custom timing key.</param>
        /// <param name="customTiming">Custom timing model.</param>
        /// <returns>A task.</returns>
        public async Task LoadContentAsync(string customTimingKey, CustomTiming customTiming)
        {
            await LoadContentCoreAsync(customTimingKey, customTiming);
        }

        private async Task LoadContentCoreAsync(string customTimingKey, CustomTiming customTiming)
        {
            await Task.Run(() =>
            {
                Id = customTiming.Id.ToString();
                CustomTimingKey = customTimingKey;
                ExecuteType = customTiming.ExecuteType;
                DurationMilliseconds = customTiming.DurationMilliseconds;
                StartMilliseconds = customTiming.StartMilliseconds;
                FirstFetchDurationMilliseconds = customTiming.FirstFetchDurationMilliseconds;
                CommandString = customTiming.CommandString;
                StackTraceSnippet = customTiming.StackTraceSnippet;
                Errored = customTiming.Errored;

                Visibility = Visibility.Visible;
            });
        }

        #region Id Property

        private string? id;

        /// <summary>
        /// Gets the unique identifier of this custom timing (MiniProfiler property).
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

        #region CustomTimingKey Property

        private string? customTimingKey;

        /// <summary>
        /// Gets the custom timing key/type (MiniProfiler property).
        /// </summary>
        public string? CustomTimingKey
        {
            get => customTimingKey;
            private set
            {
                if (value != customTimingKey)
                {
                    customTimingKey = value;
                    OnPropertyChanged(nameof(CustomTimingKey));
                }
            }
        }

        #endregion

        #region ExecuteType Property

        private string? executeType;

        /// <summary>
        /// Gets the short name describing what kind of custom timing this is (MiniProfiler property).
        /// </summary>
        public string? ExecuteType
        {
            get => executeType;
            private set
            {
                if (value != executeType)
                {
                    executeType = value;
                    OnPropertyChanged(nameof(ExecuteType));
                }
            }
        }

        #endregion 

        #region DurationMilliseconds Property

        private decimal? durationMilliseconds;

        /// <summary>
        /// Gets the value of how long this custom command statement took to execute (MiniProfiler property).
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
        /// Gets the offset from main profiler start that this custom command began (MiniProfiler property).
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

        #region FirstFetchDurationMilliseconds Property

        private decimal? firstFetchDurationMilliseconds;

        /// <summary>
        /// Gets the value of how long this timing took to come back initially from the remote server,
        /// before all data is fetched and command is completed (MiniProfiler property).
        /// </summary>
        public decimal? FirstFetchDurationMilliseconds
        {
            get => firstFetchDurationMilliseconds;
            private set
            {
                if (value != firstFetchDurationMilliseconds)
                {
                    firstFetchDurationMilliseconds = value;
                    OnPropertyChanged(nameof(FirstFetchDurationMilliseconds));
                }
            }
        }

        #endregion

        #region CommandString Property

        private string? commandString;

        /// <summary>
        /// Gets the command that was executed (MiniProfiler property).
        /// </summary>
        public string? CommandString
        {
            get => commandString;
            private set
            {
                if (value != commandString)
                {
                    commandString = value;
                    OnPropertyChanged(nameof(CommandString));
                }
            }
        }

        #endregion

        #region StackTraceSnippet Property

        private string? stackTraceSnippet;

        /// <summary>
        /// Gets the value where in the calling code that this custom timing was executed (MiniProfiler property).
        /// </summary>
        public string? StackTraceSnippet
        {
            get => stackTraceSnippet;
            private set
            {
                if (value != stackTraceSnippet)
                {
                    stackTraceSnippet = value;
                    OnPropertyChanged(nameof(StackTraceSnippet));
                }
            }
        }

        #endregion

        #region Errored Property

        private bool errored;

        /// <summary>
        /// Gets the value indicating whether this operation errored (MiniProfiler property).
        /// </summary>
        public bool Errored
        {
            get => errored;
            private set
            {
                if (value != errored)
                {
                    errored = value;
                    OnPropertyChanged(nameof(Errored));
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
    }
}
