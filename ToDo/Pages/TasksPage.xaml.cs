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
            DataContext = this;
            ReadTasksFromFile();
        }

        public List<Tasks> tasks { get; set; } = new List<Tasks>();
        public void ReadTasksFromFile()
        {
            string path = @"C:\Users\kleme\source\repos\ToDo\ToDo\Tasks\Tasks.txt";

            List<string> lines = File.ReadAllLines(path).ToList();

            foreach (var item in lines)
            {
                string[] items = item.Split(';');
                Tasks task = new Tasks()
                {
                    Id = Convert.ToInt32(items[0]),
                    Name = items[1],
                    Description = items[2],
                    IsDone = Convert.ToBoolean(items[3]),
                };
                if (task.IsDone == false)
                {
                    tasks.Add(task);
                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void ShowDescription_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
