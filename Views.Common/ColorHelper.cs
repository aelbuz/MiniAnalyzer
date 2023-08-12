using System.Windows.Media;

namespace Views.Common
{
    /// <summary>
    /// Contains static helper methods for colors.
    /// </summary>
    public static class ColorHelper
    {
        private static int colorIndex = -1;

        private static readonly Brush[] colors = new[]
        {
            Brushes.Chartreuse,
            Brushes.Cyan,
            Brushes.DarkOrange,
            Brushes.DarkTurquoise,
            Brushes.Gainsboro,
            Brushes.Gold,
            Brushes.LightBlue,
            Brushes.LightCoral,
            Brushes.LightGreen,
            Brushes.LightSkyBlue,
            Brushes.Moccasin,
            Brushes.PaleGreen,
            Brushes.PaleTurquoise,
            Brushes.PeachPuff,
            Brushes.PowderBlue,
            Brushes.SandyBrown,
            Brushes.SpringGreen,
            Brushes.Violet,
        };

        /// <summary>
        /// Gets the next color as <see cref="Brush"/> from the previously defined color set.
        /// </summary>
        /// <returns>Color as <see cref="Brush"/>.</returns>
        public static Brush GetNextColor()
        {
            colorIndex = (colorIndex + 1) % colors.Length;
            return colors[colorIndex];
        }
    }
}
