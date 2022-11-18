﻿using System;
using System.Collections.Generic;
using System.IO;
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

namespace ToDo.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("C:\\Users\\kleme\\source\\repos\\ToDo\\ToDo\\Tasks\\Tasks.txt", append: true);
            Tasks task = new Tasks();
            task.Name = _title.Text;
            task.Description = _description.Text;
            task.IsDone = false;
            sw.WriteLine(task.Name + " " + task.Description + " " + task.IsDone.ToString());
            sw.Close();
        }
    }
}
