using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPFColorPickerLib;
using WPF_Shapes.BLL;
using WPF_Shapes.BLL.Enum;
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
            DrawSettings.SelectedMode = (Mode)Enum.Parse(typeof(Mode), ((ComboBoxItem)ModeComboBox.SelectedItem).Content.ToString());
        }

        private void ChangeFillColorButton_OnClick(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext as DataContext;
            ColorDialog colorDialog = new ColorDialog(dataContext.Settings.FillColorBrush.Color);
            if ((bool) colorDialog.ShowDialog())
            {
                dataContext.Settings.FillColorBrush = new SolidColorBrush(colorDialog.SelectedColor);
                FillColorRect.Fill = new SolidColorBrush(colorDialog.SelectedColor);
            }

        }

        private void ChangeStrokeColorButton_OnClick(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext as DataContext;
            ColorDialog colorDialog = new ColorDialog(dataContext.Settings.StrokeColorBrush.Color);
            if ((bool)colorDialog.ShowDialog())
            {
                dataContext.Settings.StrokeColorBrush = new SolidColorBrush(colorDialog.SelectedColor);
                StrokeColorRect.Fill = new SolidColorBrush(colorDialog.SelectedColor);
            }
        }

        private void ClearButton_OnClick(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext as DataContext;
            dataContext.Manager.Clear();
            Canvas.Children.Clear();
            ShapesListBox.Items.Refresh();
        }

        private void ModeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DrawSettings.SelectedMode = (Mode)Enum.Parse(typeof(Mode), ((ComboBoxItem)ModeComboBox.SelectedItem).Content.ToString());
        }
    }
}