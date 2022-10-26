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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeTracker.Models;

namespace TimeTracker.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ProjectForm : UserControl
    {
        public string Title
        {
            get { return frmTitle.Text; }
            set { frmTitle.Text = value; }
        }

        public string Department
        {
            get { return frmDepartment.Text; }
            set { frmDepartment.Text = value; }
        }

        public string Description
        {
            get { return frmDescription.Text; }
            set { frmDescription.Text = value; }
        }

        public string AllocatedHours
        {
            get { return frmAllocatedHours.Text; }
            set { frmAllocatedHours.Text = value; }
        }

        public Boolean IsCompleted
        {
            get { return (bool)frmIsCompleted.IsChecked; }

            set { frmIsCompleted.IsChecked = value; }
        }

        public delegate void MyControlClickEvent(object sender, RoutedEventArgs e);
        public event MyControlClickEvent OnButtonClick;

        public EventHandler ButtonClicked;

        public ProjectForm()
        {
            InitializeComponent();
            using var db = new TimeTrackerContext();


            frmDepartment.DataContext = db.Departments.ToList();
            frmDepartment.DisplayMemberPath = "Title";

        }

        private void frmSubmit_Click(object sender, RoutedEventArgs e)
        {
            this.OnButtonClick?.Invoke(sender, e);
        }
    }
}
