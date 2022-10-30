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
using System.Windows.Shapes;
using TimeTracker.Models;

namespace TimeTracker
{
    /// <summary>
    /// Interaction logic for ProjectAddForm.xaml
    /// </summary>
    public partial class ProjectAddForm : Window
    {
        TimeTrackerContext db = new TimeTrackerContext();

        public ProjectAddForm()
        {
            InitializeComponent();
        }

        private void NewForm_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object Sender, RoutedEventArgs e)
        {
            Project current = new()
            {
                Title = NewForm.Title,
                DepartmentId = NewForm.Department.Id,
                Description = NewForm.Description,
                AllocatedHours = NewForm.AllocatedHours,
                IsCompleted = NewForm.IsCompleted
            };
            db.Add(current);
            db.SaveChanges();

            this.Close();
        }
    }
}
