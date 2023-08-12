using System;
using System.Windows.Media;

namespace MiniAnalyzer.Tree.Detail
{
    /// <summary>
    /// Defines a result item in the chart.
    /// </summary>
    public class TimeChartItem
    {
        /// <summary>
        /// Gets or sets the result ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the result name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the result value.
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Gets or sets the result duration.
        /// </summary>
        public decimal DurationMilliseconds { get; set; }

        /// <summary>
        /// Gets or sets the result's background color in the chart.
        /// </summary>
        public Brush? Background { get; set; }
    }
}
