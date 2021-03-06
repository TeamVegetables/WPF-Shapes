﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WPF_Shapes.BLL.Enum;
using WPF_Shapes.DAL;

namespace WPF_Shapes.BLL.Commands
{
    public class DrawPentagonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        
        private readonly PointCollection _pointCollection;

        private readonly DataContext _dataContext;

        private int _shapeCount;

        private int _count;

        private Point? _dragStart;

        private Canvas _canvas;

        /// <summary>
        /// Command which draw pentagon
        /// </summary>
        /// <param name="dataContext">Class DataContext</param>
        public DrawPentagonCommand(DataContext dataContext)
        {
            _pointCollection = new PointCollection();
            _dataContext = dataContext;
        }

        /// <summary>
        /// bool function to check drawing ability
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return DrawSettings.SelectedMode == Mode.Drawing;
        }

        /// <summary>
        /// function which display Pentagon on canvas and add pentagon to data context
        /// </summary>
        public void Execute(object parameter)
        {
            var grid = parameter as Grid;
            _canvas = (Canvas)((Border)((ScrollViewer)grid?.Children[6])?.Content)?.Child;
            //_shapeCount = _dataContext.Manager.Shapes.Count;
            _pointCollection.Add(Mouse.GetPosition(_canvas));
            ++_count;
            if (_count == 5)
            {
                var listBox = (ListBox)((StackPanel)grid?.Children[5])?.Children[0];
                var name = $"Pentagon{++_shapeCount}";
                var polygon = new Polygon
                {
                    Points = _pointCollection.Clone(),
                    Stroke = _dataContext.Settings.StrokeColorBrush,
                    StrokeThickness = _dataContext.Settings.StrokeThickness,
                    Fill = _dataContext.Settings.FillColorBrush
                };
                EnableDrag(polygon);
                _canvas?.Children.Add(polygon);
                _pointCollection.Clear();
                _count = 0;
                _dataContext.Manager.Add(polygon, name);
                listBox?.Items.Refresh();
            }
        }
        /// <summary>
        /// function which is responsible for the movement of shapes
        /// </summary>
        /// <param name="element">pentagon</param>
        private void EnableDrag(UIElement element)
        {
            element.MouseDown += OnMouseDown;
            element.MouseMove += OnMouseMove;
            element.MouseUp += OnMouseUp;
        }
        /// <summary>
        /// function which reports holding mouse clicks
        /// </summary>

        private void OnMouseDown(object sender, MouseButtonEventArgs args)
        {
            if (DrawSettings.SelectedMode == Mode.Moving)
            {
                var element = (UIElement)sender;
                _dragStart = args.GetPosition(element);
                element.CaptureMouse();
            }
        }
        /// <summary>
        /// function which reports stop holding mouse clicks
        /// </summary>
        private void OnMouseUp(object sender, MouseButtonEventArgs args)
        {
            if (DrawSettings.SelectedMode == Mode.Moving)
            {
                var element = (UIElement)sender;
                _dragStart = null;
                element.ReleaseMouseCapture();
            }
        }
        /// <summary>
        /// function which reports moving mouse on the canvas
        /// </summary>
        private void OnMouseMove(object sender, MouseEventArgs args)
        {
            if (DrawSettings.SelectedMode == Mode.Moving)
            {
                if (_dragStart != null && args.LeftButton == MouseButtonState.Pressed)
                {
                    var element = (UIElement)sender;
                    var p2 = args.GetPosition(_canvas);
                    Canvas.SetLeft(element, p2.X - _dragStart.Value.X);
                    Canvas.SetTop(element, p2.Y - _dragStart.Value.Y);
                }
            }
        }
    }
}