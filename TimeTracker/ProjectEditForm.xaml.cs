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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TimeTracker.Models;


namespace TimeTracker
{
    /// <summary>
    /// Interaction logic for ProjectEditForm.xaml
    /// </summary>
    public partial class ProjectEditForm : Window
    {
        TimeTrackerContext db = new TimeTrackerContext();
        Project? currentItem;
        private int? CurrentProjectId { get; set; }

        public ProjectEditForm(int? projectId = null)
        {
            InitializeComponent();

            if(projectId == null)
            {
                this.Close();
            }

            CurrentProjectId = projectId;

            

            currentItem = db.Projects.Include(db2 => db2.Department).First(i => i.Id == projectId);

            if(currentItem != null)
            {
                editForm.DataContext = currentItem;
            }
        }

        private void Button_Click(object Sender, RoutedEventArgs e)
        {

            //This isn't updating, just deleting records.  Find out why


            currentItem.Title = editForm.Title;
            currentItem.Department = editForm.Department;
            currentItem.Description = editForm.Description;
            currentItem.AllocatedHours = editForm.AllocatedHours;
            currentItem.IsCompleted = editForm.IsCompleted;
            db.Update(currentItem);
            db.SaveChanges();
        }
    }
}
