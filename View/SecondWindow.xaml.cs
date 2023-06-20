using SunClounds.Model;
using System.Windows;

namespace SunClounds
{
    public partial class SecondWindow : Window
    {
        private Diagram_view graph;
        public SecondWindow()
        {
            InitializeComponent();
            graph = new Diagram_view(PlotView, 0);
            PlotView.Plot.YLabel("Температура");
        }
        private void CloseButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void MinimizeButton(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void ResizeButton(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                WindowState = WindowState = WindowState.Maximized;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlotView.Plot.Clear();
            PlotView.Plot.YLabel("Температура");
            graph = new Diagram_view(PlotView,0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PlotView.Plot.Clear();
            PlotView.Plot.YLabel("Ощущается как");
            graph = new Diagram_view(PlotView, 1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PlotView.Plot.Clear();
            PlotView.Plot.YLabel("Давление");
            graph = new Diagram_view(PlotView, 2);
        }
    }
}
