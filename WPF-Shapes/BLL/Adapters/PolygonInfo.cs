using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WPF_Shapes.BLL.Enum;
using WPF_Shapes.Pages.DrawingBoard;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;
using Point = System.Windows.Point;

namespace WPF_Shapes.BLL.Adapters
{
    [Serializable]
    public class PolygonInfo
    {
        /// <summary>
        /// Contains Information about polygon
        /// </summary>
        /// <param name="polygon"></param>
        public PolygonInfo(Polygon polygon)
        {
            Points = new List<Tuple<double, double>>();
            Init(polygon);
        }

        public string Stroke { get; set; }

        [NonSerialized]
        private Point? _dragStart;

        public double StrokeThickness { get; set; }

        public string Fill { get; set; }

        public List<Tuple<double, double>> Points { get; }
        /// <summary>
        /// Function which convert to polygon
        /// </summary>
        public Polygon ConvertToPolygon()
        {
            var polygon = new Polygon
            {
                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Stroke)),
                StrokeThickness = StrokeThickness,
                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(Fill))
            };
            foreach (var point in Points)
            {
                polygon.Points.Add(new Point(point.Item1, point.Item2));
            }
            EnableDrag(polygon);
            return polygon;
        }
        /// <summary>
        /// Initialize new object
        /// </summary>
        private void Init(Polygon polygon)
        {
            Fill = polygon.Fill.ToString();
            Stroke = polygon.Stroke.ToString();
            StrokeThickness = polygon.StrokeThickness;
            foreach (var point in polygon.Points)
            {
                Points.Add(new Tuple<double, double>(point.X, point.Y));
            }

        }

        /// <summary>
        /// function which is responsible for the movement of shapes
        /// </summary>
        /// <param name="element">pentagon</param>
        private void EnableDrag(UIElement element)
        {
            element.MouseDown += OnMouseDown;
            element.MouseMove += OnMouseMove;
            element.MouseUp += OnMouseUp;
        }
        /// <summary>
        /// function which reports holding mouse clicks
        /// </summary>

        private void OnMouseDown(object sender, MouseButtonEventArgs args)
        {
            if (DrawSettings.SelectedMode == Mode.Moving)
            {
                var element = (UIElement)sender;
                _dragStart = args.GetPosition(element);
                element.CaptureMouse();
            }
        }
        /// <summary>
        /// function which reports stop holding mouse clicks
        /// </summary>
        private void OnMouseUp(object sender, MouseButtonEventArgs args)
        {
            if (DrawSettings.SelectedMode == Mode.Moving)
            {
                var element = (UIElement)sender;
                _dragStart = null;
                element.ReleaseMouseCapture();
            }
        }
        /// <summary>
        /// function which reports moving mouse on the canvas
        /// </summary>
        private void OnMouseMove(object sender, MouseEventArgs args)
        {
            if (DrawSettings.SelectedMode == Mode.Moving)
            {
                if (_dragStart != null && args.LeftButton == MouseButtonState.Pressed)
                {
                    var element = (UIElement)sender;
                    var p2 = args.GetPosition(DrawingBoard.CurrentContext.Canvas);
                    Canvas.SetLeft(element, p2.X - _dragStart.Value.X);
                    Canvas.SetTop(element, p2.Y - _dragStart.Value.Y);
                }
            }
        }
    }
}
