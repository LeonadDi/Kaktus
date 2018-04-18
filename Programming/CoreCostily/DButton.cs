using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DTamachi_wpf.Programming.CoreCostily
{
    public class DButton: Button
    {
        public DButton()
        {
            FontSize = 15;
            Foreground = Brushes.Black;
            BorderBrush = Brushes.DarkGray;
            Background = Brushes.LightGray;
            Margin = new Thickness(0, 3, 0, 3);
            BorderThickness = new Thickness(5, 2, 5, 2);
        }

        

    }
}
