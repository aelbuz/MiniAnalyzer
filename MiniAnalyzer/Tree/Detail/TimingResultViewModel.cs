﻿using Common.Types;
using System.Threading.Tasks;
using System.Windows;
using Views.Common;

namespace MiniAnalyzer.Tree.Detail
{
    public class TimingResultViewModel : ViewModelBase
    {
        public TimingResultViewModel()
        {
            Visibility = Visibility.Collapsed;

            TimeChart = new TimeChartView();
        }

        public async Task LoadContentAsync(Timing timing)
        {
            await LoadContentCoreAsync(timing);
        }

        private async Task LoadContentCoreAsync(Timing timing)
        {
            await Task.Run(async () =>
            {
                Id = timing.Id.ToString();
                Name = timing.Name;
                DurationMilliseconds = timing.DurationMilliseconds;
                StartMilliseconds = timing.StartMilliseconds;
                RichHtmlStack = timing.DebugInfo?.RichHtmlStack;
                CommonStackStart = timing.DebugInfo?.CommonStackStart;

                await TimeChart.UpdateTimesAsync(timing);

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

        #region RichHtmlStack Property

        private string? richHtmlStack;

        public string? RichHtmlStack
        {
            get => richHtmlStack;
            private set
            {
                if (value != richHtmlStack)
                {
                    richHtmlStack = value;
                    OnPropertyChanged(nameof(RichHtmlStack));
                }
            }
        }

        #endregion

        #region CommonStackStart Property

        private int? commonStackStart;

        public int? CommonStackStart
        {
            get => commonStackStart;
            private set
            {
                if (value != commonStackStart)
                {
                    commonStackStart = value;
                    OnPropertyChanged(nameof(CommonStackStart));
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

        public TimeChartView TimeChart { get; private set; }
    }
}
