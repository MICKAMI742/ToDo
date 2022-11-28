using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ToDo.Pages;

namespace ToDo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        double panelWidth;
        bool hidden;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,0,0,0);
            timer.Tick += Timer_Tick;

            panelWidth = slidePanel.Width;
        }
        // sliding panel logic
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (hidden)
            {
                slidePanel.Width += 1;
                mainContainer.Width -= 1;
                if (slidePanel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                slidePanel.Width -= 1;
                mainContainer.Width += 1;
                if (slidePanel.Width <= 40)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }

        private void ButtonTasks_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new TasksPage();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddPage();
        }

        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void PanelHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
