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

        public ProjectEditForm(int? projectId = null)
        {
            InitializeComponent();

            if(projectId == null)
            {
                this.Close();
            }

            currentItem = db.Projects.Include(db2 => db2.Department).First(i => i.Id == projectId);

            if(currentItem != null)
            {
                editForm.Title = currentItem.Title ?? "";
                editForm.Description = currentItem.Description ?? "";
                editForm.AllocatedHours = currentItem.AllocatedHours.ToString();
                editForm.frmIsCompleted.IsChecked = (bool)currentItem.IsCompleted;
                editForm.frmDepartment.SelectedValue = currentItem.Department.Id;
            }
        }

        private void Button_Click(object Sender, RoutedEventArgs e)
        {
            MessageBox.Show(currentItem.Title);
        }
    }
}
