using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace ToDo.Pages
{
    public class Tasks
    {
        // reading and setting Id variables
        private static object sync = new object();
        private static int globalCount;
        private string globalCountReader;
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsDone { get; set; }

        // setting Id function
        public int SetID()
        {
            string path = @"C:\Users\kleme\source\repos\ToDo\ToDo\Tasks\GlobalCount.txt";
            globalCountReader = File.ReadAllText(path);
            globalCount = Convert.ToInt32(globalCountReader);
            lock (sync)
            {
                StreamWriter sw = new StreamWriter(@"C:\Users\kleme\source\repos\ToDo\ToDo\Tasks\GlobalCount.txt");
                this.Id = ++globalCount;
                if(globalCount == 20)
                {
                    globalCount= 0;
                }
                sw.WriteLine(globalCount);
                sw.Close();
            }
            return this.Id;
        }
    }
}
