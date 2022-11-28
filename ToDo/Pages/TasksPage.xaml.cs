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
    /// Logika interakcji dla klasy TasksPage.xaml
    /// </summary>
    public partial class TasksPage : Page
    {
        public TasksPage()
        {
            InitializeComponent();
            ReadTasksFromFile();
        }

        public void ReadTasksFromFile()
        {
            StreamReader sr = new StreamReader("C:\\Users\\kleme\\source\\repos\\ToDo\\ToDo\\Tasks\\Tasks.txt");
            List<Tasks> tasks = new List<Tasks>();
            while (!sr.EndOfStream)
            {

            }
        }
    }
}
