using Common.Types;
using System.Threading.Tasks;
using System.Windows;
using Views.Common;

namespace MiniAnalyzer.Tree.Detail
{
    public class CustomTimingResultViewModel : ViewModelBase
    {
        public CustomTimingResultViewModel()
        {
            Visibility = Visibility.Collapsed;
        }

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
