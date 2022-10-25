using Microsoft.EntityFrameworkCore;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TimeTracker.Models;

namespace TimeTracker
{
    /// <summary>
    /// Interaction logic for ProjectListWindow.xaml
    /// </summary>
    public partial class ProjectListWindow : Window
    {
        public ProjectListWindow()
        {
            InitializeComponent();

            using var db = new TimeTrackerContext();
            //db.Add(new Project { DepartmentId = 1, Title = "A Test Project", AllocatedHours = 10, Created = DateTime.Now });
            //db.Add(new Project { DepartmentId = 1, Title = "Another Department 1 Test Project", AllocatedHours = 5, Created = DateTime.Now });
            //db.Add(new Project { DepartmentId = 2, Title = "A Second Test Project", AllocatedHours = 10, Created = DateTime.Now });
            //db.SaveChanges();

            lvProjects.ItemsSource = db.Projects.Include(db2 => db2.Department).ToList();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Edit_ClickAction(object sender, RoutedEventArgs e)
        {
            var project = lvProjects.SelectedItem as Project;

            if (lvProjects != null)
            {
                ProjectEditForm pef = new ProjectEditForm(project.Id);
                pef.Show();
            }
        }

    }
}
