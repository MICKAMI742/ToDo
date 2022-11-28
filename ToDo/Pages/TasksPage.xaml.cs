using System;
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

        //public List<Tasks> tasks = new List<Tasks>();
        public List<Tasks> tasks { get; set; } = new List<Tasks>();
        public void ReadTasksFromFile()
        {
            string path = @"C:\Users\kleme\source\repos\ToDo\ToDo\Tasks\Tasks.txt";
            Tasks task = new Tasks();

            List<string> lines = File.ReadAllLines(path).ToList();

            foreach (var item in lines)
            {
                string[] items = item.Split(';');
                task.Name = items[0];
                task.Description = items[1];
                task.IsDone = Convert.ToBoolean(items[2]);
                tasks.Add(task);
            }
        }
    }
}
