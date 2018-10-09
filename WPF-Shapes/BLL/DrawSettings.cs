using System.Windows.Media;

namespace WPF_Shapes.BLL
{
    public class DrawSettings
    {
        public SolidColorBrush FillColorBrush { get; set; }

        public SolidColorBrush StrokeColorBrush { get; set; }

        public int StrokeThickness { get; set; }

        public DrawSettings()
        {
            FillColorBrush = Brushes.Chartreuse;
            StrokeColorBrush = Brushes.Gold;
            StrokeThickness = 2;
        }
    }
}