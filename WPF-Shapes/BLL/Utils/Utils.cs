using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_Shapes.BLL.Utils
{
    public static class Utils
    {
        //public static Nullable<Point> dragStart = null;

        //public static void OnMouseDown(object sender, MouseButtonEventArgs args)
        //{
        //    var element = (UIElement) sender;
        //    dragStart = args.GetPosition(element);
        //    element.CaptureMouse();
        //}

        //public static void OnMouseUp(object sender, MouseButtonEventArgs args)
        //{
        //    var element = (UIElement) sender;
        //    dragStart = null;
        //    element.ReleaseMouseCapture();
        //}

        //public static void OnMouseMove(object sender, MouseButtonEventArgs args)
        //{
        //    if (dragStart != null && args.LeftButton == MouseButtonState.Pressed)
        //    {
        //        var element = (UIElement) sender;
        //        var p2 = args.GetPosition(c);
        //        Canvas.SetLeft(element, p2.X - dragStart.Value.X);
        //        Canvas.SetTop(element, p2.Y - dragStart.Value.Y);
        //    }
        //}
    }
}
