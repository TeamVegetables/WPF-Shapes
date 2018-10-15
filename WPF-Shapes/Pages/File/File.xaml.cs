using System;
using System.Windows;
using System.Windows.Controls;
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
            var openFile = new OpenFileDialog();
            if (openFile.ShowDialog().Value)
            {
                FileManager.Load(openFile.FileName, DrawingBoard.DrawingBoard.CurrentContext.Manager.Shapes);
            }
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            var saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog().Value)
            {
                FileManager.Save(saveFile.FileName, DrawingBoard.DrawingBoard.CurrentContext.Manager.Shapes);
            }
        }
    }
}
