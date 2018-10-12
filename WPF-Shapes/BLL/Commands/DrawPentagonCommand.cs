using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WPF_Shapes.BLL.Enum;
using WPF_Shapes.DAL;

namespace WPF_Shapes.BLL.Commands
{
    public class DrawPentagonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        
        private readonly PointCollection _pointCollection;

        private readonly DataContext _dataContext;

        private int _shapeCount;

        private int _count;

        private Point? dragStart = null;

        private Canvas _canvas;

        public DrawPentagonCommand(DataContext dataContext)
        {
            _pointCollection = new PointCollection();
            _dataContext = dataContext;
        }

        public bool CanExecute(object parameter)
        {
            return DrawSettings.SelectedMode == Mode.Drawing;
        }

        public void Execute(object parameter)
        {
            var grid = parameter as Grid;
            _canvas = (Canvas)((Border)((ScrollViewer)grid?.Children[6])?.Content)?.Child;
            _pointCollection.Add(Mouse.GetPosition(_canvas));
            ++_count;
            if (_count == 5)
            {
                var listBox = (ListBox)((StackPanel)grid?.Children[5])?.Children[0];
                var name = $"Pentagon{++_shapeCount}";
                var polygon = new Polygon
                {
                    Points = _pointCollection.Clone(),
                    Stroke = _dataContext.Settings.StrokeColorBrush,
                    StrokeThickness = _dataContext.Settings.StrokeThickness,
                    Fill = _dataContext.Settings.FillColorBrush
                };
                EnableDrag(polygon);
                _canvas?.Children.Add(polygon);
                _pointCollection.Clear();
                _count = 0;
                _dataContext.Manager.Add(polygon, name);
                listBox?.Items.Refresh();
            }
        }

        private void EnableDrag(UIElement element)
        {
            element.MouseDown += OnMouseDown;
            element.MouseMove += OnMouseMove;
            element.MouseUp += OnMouseUp;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs args)
        {
            var element = (UIElement)sender;
            dragStart = args.GetPosition(element);
            element.CaptureMouse();
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs args)
        {
            var element = (UIElement)sender;
            dragStart = null;
            element.ReleaseMouseCapture();
        }

        private void OnMouseMove(object sender, MouseEventArgs args)
        {
            if (dragStart != null && args.LeftButton == MouseButtonState.Pressed)
            {
                var element = (UIElement)sender;
                var p2 = args.GetPosition(_canvas);
                Canvas.SetLeft(element, p2.X - dragStart.Value.X);
                Canvas.SetTop(element, p2.Y - dragStart.Value.Y);
            }
        }
    }
}