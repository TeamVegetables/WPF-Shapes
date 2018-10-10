using System.Windows.Media;
using WPF_Shapes.BLL.Enum;

namespace WPF_Shapes.BLL
{
    public class DrawSettings
    {
        public SolidColorBrush FillColorBrush { get; set; }

        public SolidColorBrush StrokeColorBrush { get; set; }

        public int StrokeThickness { get; set; }

        public static Mode SelectedMode { get; set; }

        public DrawSettings()
        {
            FillColorBrush = Brushes.Chartreuse;
            StrokeColorBrush = Brushes.Gold;
            StrokeThickness = 2;
        }
    }
}