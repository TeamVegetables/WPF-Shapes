using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Shapes;
using WPF_Shapes.Commands;

namespace WPF_Shapes.DAL
{
    public class DataContext
    {
        public ShapesManager Manager { get; }

        public ICommand DrawPentagonCommand { get; }

        public DataContext()
        {
            Manager = new ShapesManager();
            DrawPentagonCommand = new DrawPentagonCommand(this);
        }
    }
}