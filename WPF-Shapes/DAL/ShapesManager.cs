using System.Collections.Generic;
using System.Windows.Shapes;

namespace WPF_Shapes.DAL
{
    /// <summary>
    /// Class container that has dictionary key - name of shape, value - shape.
    /// </summary>
    public class ShapesManager
    {
        /// <summary>
        /// Dictionary key - name of shape, value - shape.
        /// </summary>
        public Dictionary<string, Shape> Shapes { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapesManager"/> class.
        /// </summary>
        public ShapesManager()
        {
            Shapes = new Dictionary<string, Shape>();
        }

        /// <summary>
        /// Add element to dictionary.
        /// </summary>
        /// <param name="shape">The shape.</param>
        /// <param name="name">Name of shape.</param>
        public void Add(Shape shape, string name)
        {
            Shapes.Add(name, shape);
        }

        /// <summary>
        /// Clear dictionary
        /// </summary>
        public void Clear()
        {
            Shapes.Clear();
        }
    }
}