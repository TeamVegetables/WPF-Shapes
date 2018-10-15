using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using Microsoft.Win32;
using WPF_Shapes.DAL;

namespace WPF_Shapes.Pages.File
{
    /// <summary>
    /// Interaction logic for File.xaml
    /// </summary>
    public partial class File : UserControl
    {
        public File()
        {
            InitializeComponent();
        }

        private void OpenButton_OnClick(object sender, RoutedEventArgs e)
        {
            Dictionary<string, Shape> shapes = null;
            var openFile = new OpenFileDialog();
            if (openFile.ShowDialog().HasValue)
            {
                shapes = SerializationManager.DeserializePentagons(openFile.FileName);
            }
            foreach (var shape in shapes)
            {
                DrawingBoard.DrawingBoard.CurrentContext.Manager.Shapes.Add(shape.Key, shape.Value);
            }
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog().HasValue)
            {
                SerializationManager.SerializePentagons(saveFile.FileName, DrawingBoard.DrawingBoard.CurrentContext.Manager.Shapes);
            }

        }
    }
}
