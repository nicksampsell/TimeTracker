using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Models
{
    public class WorkPeriod
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
