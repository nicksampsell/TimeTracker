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
using TimeTracker.Controls;
using System.Collections.ObjectModel;

namespace TimeTracker.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ProjectForm : UserControl
    {
        public string Title { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public string Description { get; set; }
        public int AllocatedHours { get; set; } = 0;
        public bool IsCompleted { get; set; } = false;
        public Object Data { get; set; }
        public int Selection { get; set; }
        public string ButtonText { get; set; } = "Save Changes";

        public delegate void MyControlClickEvent(object sender, RoutedEventArgs e);
        public event MyControlClickEvent OnButtonClick;

        public EventHandler ButtonClicked;

        public ProjectForm()
        {
            InitializeComponent();

            using var db = new TimeTrackerContext();
            //frmDepartment.ItemsSource = db.Departments.ToList();
            frmDepartment.ItemsSource = db.Departments.ToList();
            this.DataContext = this;
            frmDepartment.DisplayMemberPath = "Title";


        }

        private void frmSubmit_Click(object sender, RoutedEventArgs e)
        {
            this.OnButtonClick?.Invoke(sender, e);
        }

        private void frmTitle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
