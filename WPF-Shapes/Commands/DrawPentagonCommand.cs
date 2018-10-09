using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WPF_Shapes.BLL;
using WPF_Shapes.DAL;

namespace WPF_Shapes.Commands
{
    public class DrawPentagonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        
        private readonly PointCollection _pointCollection;

        private readonly DataContext _dataContext;

        private int _shapeCount;

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
            var grid = parameter as Grid;
            var canvas = (Canvas)((ScrollViewer)grid?.Children[4])?.Content;
            _pointCollection.Add(Mouse.GetPosition(canvas));
            ++_count;
            if (_count == 5)
            {
                var listBox = (ListBox)((StackPanel)grid?.Children[3])?.Children[0];
                var name = $"Pentagon{++_shapeCount}";
                var polygon = new Polygon
                {
                    Points = _pointCollection.Clone(),
                    Stroke = _dataContext.Settings.StrokeColorBrush,
                    StrokeThickness = _dataContext.Settings.StrokeThickness,
                    Fill = _dataContext.Settings.FillColorBrush
                };
                canvas?.Children.Add(polygon);
                _pointCollection.Clear();
                _count = 0;
                _dataContext.Manager.Add(polygon, name);
                listBox?.Items.Refresh();
            }
        }
    }
}