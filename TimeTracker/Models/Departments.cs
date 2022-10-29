using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<Project> Projects { get; } = new();
        public List<WorkPeriod> WorkPeriods { get; } = new();

        public override bool Equals(object obj)
        {
            return Equals(obj as Department);
        }

        public bool Equals(Department dept)
        {
            return dept != null && dept.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id & Title.GetHashCode();
        }
    }
}
