using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using WPF_Shapes.DAL;
using WPF_Shapes.DAL.Extensions;

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
            var openFile = new OpenFileDialog();
            if (openFile.ShowDialog().Value)
            {
                var shapes =  SerializationManager.DeserializePentagons(openFile.FileName);
                foreach (var shape in shapes)
                {
                    DrawingBoard.DrawingBoard.CurrentContext.Manager.Shapes.Add(shape.Key, shape.Value);
                }
            }
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog().Value)
            {
                SerializationManager.SerializePentagons(saveFile.FileName, DrawingBoard.DrawingBoard.CurrentContext.Manager.Shapes);
            }
        }
    }
}
