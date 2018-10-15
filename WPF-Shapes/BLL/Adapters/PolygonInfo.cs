using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace WPF_Shapes.BLL.Adapters
{
    [Serializable]
    public class PolygonInfo
    {
        public PolygonInfo(Polygon polygon)
        {
            Points = new List<Tuple<double, double>>();
            Init(polygon);
        }

        public List<Tuple<double, double>> Points { get; private set; }

        public Polygon ConvertToPolygon()
        {
            var polygon = new Polygon();
            foreach (var point in Points)
            {
                polygon.Points.Add(new Point(point.Item1, point.Item2));
            }

            return polygon;
        }

        private void Init(Polygon polygon)
        {
            foreach (var point in polygon.Points)
            {
                Points.Add(new Tuple<double, double>(point.X, point.Y));
            }
        }
    }
}
