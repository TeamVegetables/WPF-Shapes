using System.Windows.Media;
using WPF_Shapes.BLL.Enum;

namespace WPF_Shapes.BLL
{
    /// <summary>
    /// Represents UI settings.
    /// </summary>
    public class DrawSettings
    {
        /// <summary>
        /// Gets or sets fill color brush.
        /// </summary>
        public SolidColorBrush FillColorBrush { get; set; }

        /// <summary>
        /// Gets or sets stoke color brush.
        /// </summary>
        public SolidColorBrush StrokeColorBrush { get; set; }

        /// <summary>
        /// Gets or sets stoke thickness.
        /// </summary>
        public int StrokeThickness { get; set; }

        /// <summary>
        /// Gets or sets selected mode.
        /// </summary>
        public static Mode SelectedMode { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawSettings"/> class.
        /// </summary>
        public DrawSettings()
        {
            FillColorBrush = Brushes.Chartreuse;
            StrokeColorBrush = Brushes.Gold;
            StrokeThickness = 2;
        }
    }
}