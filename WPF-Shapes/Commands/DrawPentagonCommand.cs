using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WPF_Shapes.DAL;

namespace WPF_Shapes.Commands
{
    public class DrawPentagonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly PointCollection _pointCollection;

        private readonly DataContext _dataContext;

        private static int shapeCount;

        private int _count;

        public DrawPentagonCommand(DataContext dataContext)
        {
            _pointCollection = new PointCollection();
            _dataContext = dataContext;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var canvas = parameter as Canvas;
            _pointCollection.Add(Mouse.GetPosition(canvas));
            ++_count;
            if (_count == 5)
            {
                string name = $"Pentagon{++shapeCount}";
                var polygon = new Polygon { Points = _pointCollection.Clone() };
                SolidColorBrush myBrush = new SolidColorBrush(Colors.Green);
                polygon.Stroke = Brushes.Red;
                polygon.StrokeThickness = 4;
                polygon.Fill = myBrush;
                canvas.Children.Add(polygon);
                _pointCollection.Clear();
                _count = 0;
                _dataContext.Manager.Add(polygon, name);
            }
        }
    }
}