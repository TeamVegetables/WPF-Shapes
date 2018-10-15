using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPF_Shapes.BLL.Adapters
{
    [Serializable]
    public class PolygonInfo
    {
        /// <summary>
        /// Represents information about polygon
        /// </summary>
        public PolygonInfo(Polygon polygon)
        {
            Points = new List<Tuple<double, double>>();
            Init(polygon);
        }
        
        public List<Tuple<double, double>> Points { get; private set; }

        public Brush Stroke { get; set; }

        public double  StrokeThickness { get; set; }

        public Brush Fill { get; set; }
        /// <summary>
        /// Converts to polygon
        /// </summary>
        /// <returns></returns>
        public Polygon ConvertToPolygon()
        {
            var polygon = new Polygon();
            foreach (var point in Points)
            {
                polygon.Points.Add(new Point(point.Item1, point.Item2));
            }

            polygon.Stroke = Stroke;
            polygon.StrokeThickness = StrokeThickness;
            polygon.Fill = Fill;
            return polygon;
        }
        /// <summary>
        /// Initialize a new instance 
        /// </summary>
        private void Init(Polygon polygon)
        {
            foreach (var point in polygon.Points)
            {
                Points.Add(new Tuple<double, double>(point.X, point.Y));
            }

            Stroke = polygon.Stroke;
            StrokeThickness = polygon.StrokeThickness;
            Fill = polygon.Fill;
        }
    }
}
