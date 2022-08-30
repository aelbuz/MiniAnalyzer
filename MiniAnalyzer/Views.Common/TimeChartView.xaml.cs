using Common.Types;
using MiniAnalyzer.Tree.Detail;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Views.Common
{
    /// <summary>
    /// Interaction logic for TimeChartView.xaml
    /// </summary>
    public partial class TimeChartView : UserControl
    {
        public TimeChartView()
        {
            InitializeComponent();
        }

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
                        items.Add(new TimeChartItem
                        {
                            Background = ColorHelper.GetNextColor(),
                            DurationMilliseconds = child.DurationMilliseconds.Value,
                            Id = child.Id,
                            Name = child.Name,
                            Value = (double)(100.0 / (double)timing.DurationMilliseconds.Value * (double)child.DurationMilliseconds.Value),
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
                            items.Add(new TimeChartItem
                            {
                                Background = ColorHelper.GetNextColor(),
                                DurationMilliseconds = customTiming.DurationMilliseconds.Value,
                                Id = customTiming.Id,
                                Name = customTimings.Key,
                                Value = (double)(100.0 / (double)timing.DurationMilliseconds.Value * (double)customTiming.DurationMilliseconds.Value),
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
