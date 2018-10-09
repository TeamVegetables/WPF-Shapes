using System.Windows.Controls;
using WPF_Shapes.DAL;

namespace WPF_Shapes.Pages.DrawingBoard
{
    /// <summary>
    /// Interaction logic for DrawingBoard.xaml
    /// </summary>
    public partial class DrawingBoard : UserControl
    {
        public DrawingBoard()
        {
            InitializeComponent();
            DataContext = new DataContext();
        }
    }
}