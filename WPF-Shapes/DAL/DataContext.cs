using System.Windows.Controls;
using System.Windows.Input;
using WPF_Shapes.BLL;
using WPF_Shapes.BLL.Commands;

namespace WPF_Shapes.DAL
{
    /// <summary>
    /// Represents data context.
    /// </summary>
    public class DataContext
    {
        /// <summary>
        /// Gets manager of shapes.
        /// </summary>
        public ShapesManager Manager { get; }

        public Canvas Canvas { get; }

        /// <summary>
        /// Gets UI settings.
        /// </summary>
        public DrawSettings Settings { get; }

        /// <summary>
        /// Gets command that draw pentagon.
        /// </summary>
        public ICommand DrawPentagonCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// </summary>
        public DataContext(Canvas canvas)
        {
            Canvas = canvas;
            Manager = new ShapesManager();
            Settings = new DrawSettings();
            DrawPentagonCommand = new DrawPentagonCommand(this);
        }
    }
}