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
        public static DataContext CurrentContext { get; set; }
        /// <summary>
        /// Initializating drawing board
        /// </summary>
        public DrawingBoard()
        {
            InitializeComponent();
            CurrentContext = new DataContext(Canvas);
            DataContext = CurrentContext;
            DrawSettings.SelectedMode = (Mode)Enum.Parse(typeof(Mode), ((ComboBoxItem)ModeComboBox.SelectedItem).Content.ToString());
        }
        /// <summary>
        /// Change color button
        /// </summary>
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
        /// <summary>
        /// Change stroke color
        /// </summary>
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
        /// <summary>
        /// Clear canvas and data context 
        /// </summary>
        private void ClearButton_OnClick(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext as DataContext;
            dataContext.Manager.Clear();
            Canvas.Children.Clear();
            ShapesListBox.Items.Refresh();
        }
        /// <summary>
        /// Mode drawing and mowing
        /// </summary>
        private void ModeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DrawSettings.SelectedMode = (Mode)Enum.Parse(typeof(Mode), ((ComboBoxItem)ModeComboBox.SelectedItem).Content.ToString());
        }
    }
}