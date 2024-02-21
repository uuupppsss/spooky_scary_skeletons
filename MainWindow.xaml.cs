using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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


namespace spooky_scary_skeletons
{
    public class TaskModel
    {
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsUrgent { get; set; }
        public string Status { get; set; }
        public DateTime Completedate { get; set; }
    }

    public class TaskManager
    {
        private List<TaskModel> tasks;
        public TaskManager() 
        {
            string json = File.ReadAllText("tasks.json"); //загрузка задачи
            tasks = JsonSerializer.Deserialize<List<TaskModel>>(json);


        }
        public void SaveTasks() //сохранение задач 
        {
            string json= JsonSerializer.Serialize(tasks);
            File.WriteAllText("tasks.json", json);
        }
   
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TaskManager taskManager;

        public MainWindow()
        {
            taskManager = new TaskManager();
            InitializeComponent();

        }

       
    }

}
