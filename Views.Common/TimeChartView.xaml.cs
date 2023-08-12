using Common.Types;
using MiniAnalyzer.Tree.Detail;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Views.Common
{
    /// <summary>
    /// Defines a time chart that shows the given time values.
    /// </summary>
    public partial class TimeChartView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeChartView"/>.
        /// </summary>
        public TimeChartView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates the chart's times with given timing model asynchronously.
        /// </summary>
        /// <param name="timing">Timing model.</param>
        /// <returns>A task.</returns>
        public async Task UpdateTimesAsync(Timing timing)
        {
            await Application.Current.Dispatcher.BeginInvoke(() =>
            {
                var items = UpdateItems(timing);
                if (items != null)
                {
                    UpdateGrid(items);
                    Visibility = Visibility.Visible;
                }
            });
        }

        private IEnumerable<TimeChartItem>? UpdateItems(Timing timing)
        {
            var items = new List<TimeChartItem>();

            if (timing.Children == null && timing.CustomTimings == null)
            {
                Visibility = Visibility.Collapsed;
                return null;
            }

            if (timing.Children != null)
            {
                foreach (var child in timing.Children)
                {
                    if (timing.DurationMilliseconds.HasValue && child.DurationMilliseconds.HasValue)
                    {
                        double value = 100.0 / (double)timing.DurationMilliseconds.Value * (double)child.DurationMilliseconds.Value;

                        items.Add(new TimeChartItem
                        {
                            Background = ColorHelper.GetNextColor(),
                            DurationMilliseconds = child.DurationMilliseconds.Value,
                            Id = child.Id,
                            Name = child.Name,
                            Value = value,
                        });
                    }
                }
            }

            if (timing.CustomTimings != null)
            {
                foreach (var customTimings in timing.CustomTimings)
                {
                    foreach (var customTiming in customTimings.Value)
                    {
                        if (timing.DurationMilliseconds.HasValue && customTiming.DurationMilliseconds.HasValue)
                        {
                            double value = 100.0 / (double)timing.DurationMilliseconds.Value * (double)customTiming.DurationMilliseconds.Value;

                            items.Add(new TimeChartItem
                            {
                                Background = ColorHelper.GetNextColor(),
                                DurationMilliseconds = customTiming.DurationMilliseconds.Value,
                                Id = customTiming.Id,
                                Name = customTimings.Key,
                                Value = value,
                            });
                        }
                    }
                }
            }

            return items;
        }

        private void UpdateGrid(IEnumerable<TimeChartItem> items)
        {
            grid.Children.Clear();
            grid.ColumnDefinitions.Clear();

            foreach (var item in items)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(item.Value, GridUnitType.Star)
                });

                grid.Children.Add(new Label
                {
                    Background = item.Background,
                    Content = string.Format("{0} ms", item.DurationMilliseconds),
                    Height = grid.Height,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Padding = new Thickness(0),
                    ToolTip = new TextBlock
                    {
                        Text = string.Format("{0} - ({1} ms)", item.Name, item.DurationMilliseconds),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                    },
                    VerticalContentAlignment = VerticalAlignment.Center,
                });
            }

            if (grid.Children.Count == grid.ColumnDefinitions.Count)
            {
                for (int i = 0; i < grid.Children.Count; i++)
                {
                    grid.Children[i].SetValue(Grid.ColumnProperty, i);
                }
            }
        }
    }
}
