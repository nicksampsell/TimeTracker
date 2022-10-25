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
        public ProjectEditForm(int? projectId = null)
        {
            InitializeComponent();

            if(projectId == null)
            {
                this.Close();
            }

            using var db = new TimeTrackerContext();

            var item = db.Projects.Include(db2 => db2.Department).First(i => i.Id == projectId);

            if(item != null)
            {
                editForm.Title = item.Title ?? "";
                editForm.Description = item.Description ?? "";
                editForm.AllocatedHours = item.AllocatedHours.ToString();
                editForm.frmIsCompleted.IsChecked = (bool)item.IsCompleted;
                editForm.frmDepartment.SelectedValue = item.Department.Title;
            }
        }
    }
}
