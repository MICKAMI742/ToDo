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
using System.Windows.Shapes;

namespace ToDo.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy EditTasksWindow.xaml
    /// </summary>
    public partial class EditTasksWindow : Window
    {
        public EditTasksWindow()
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
            var myTask = myListView.SelectedIndex;
            try
            {
                tasks[myTask].IsDone = true;
                StreamWriter sw = new StreamWriter(@"C:\Users\kleme\source\repos\ToDo\ToDo\Tasks\Tasks.txt");
                foreach (var task in tasks)
                {
                    if (task.IsDone != true)
                    {
                        sw.WriteLine(task.Id.ToString() + ";" + task.Name + ";" + task.Description + ";" + task.IsDone.ToString());
                    }
                }
                sw.Close();
            }
            catch
            {
                MessageBox.Show("Nie wybrano żadnego zadania", "Błąd");
            }
        }

        private void ShowDescription_Click(object sender, RoutedEventArgs e)
        {
            var myTask = myListView.SelectedIndex;
            try
            {
                MessageBox.Show(tasks[myTask].Description, "Opis zadania");
            }
            catch
            {
                MessageBox.Show("Nie wyświetlono zawartości, ponieważ nie wybrano żadnego zadania", "Błąd");
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var myTask = myListView.SelectedIndex;
            try
            {
                StreamWriter sw = new StreamWriter(@"C:\Users\kleme\source\repos\ToDo\ToDo\Tasks\Tasks.txt");
                if (_title.Text != "")
                {
                    tasks[myTask].Name = _title.Text;
                    tasks[myTask].Description = _description.Text;
                }
                foreach (var task in tasks)
                {
                    if (task.IsDone != true)
                    {
                        sw.WriteLine(task.Id.ToString() + ";" + task.Name + ";" + task.Description + ";" + task.IsDone.ToString());
                    }
                }
                sw.Close();
            }
            catch
            {

                {
                    MessageBox.Show("Nie wybrano żadnego zadania", "Błąd");
                }
            }
        }
    }
}