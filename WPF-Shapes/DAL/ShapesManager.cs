using System.Collections.Generic;
using System.Windows.Shapes;

namespace WPF_Shapes.DAL
{
    public class ShapesManager
    {
        public Dictionary<string, Shape> Shapes { get; }

        public ShapesManager()
        {
            Shapes = new Dictionary<string, Shape>();
        }

        public void Add(Shape shape, string name)
        {
            Shapes.Add(name, shape);
        }
    }
}