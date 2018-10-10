using System.Windows.Input;
using WPF_Shapes.BLL;
using WPF_Shapes.BLL.Commands;

namespace WPF_Shapes.DAL
{
    public class DataContext
    {
        public ShapesManager Manager { get; }

        public DrawSettings Settings { get; }

        public ICommand DrawPentagonCommand { get; }

        public DataContext()
        {
            Manager = new ShapesManager();
            Settings = new DrawSettings();
            DrawPentagonCommand = new DrawPentagonCommand(this);
        }
    }
}