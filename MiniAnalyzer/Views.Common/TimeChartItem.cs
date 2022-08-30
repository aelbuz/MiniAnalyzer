using System;
using System.Windows.Media;

namespace MiniAnalyzer.Tree.Detail
{
    public class TimeChartItem
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public double Value { get; set; }

        public decimal DurationMilliseconds { get; set; }

        public Brush? Background { get; set; }
    }
}
