using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int? AllocatedHours { get; set; }
        public Boolean IsCompleted { get; set; } = false;
        public DateTime Created { get; set; } = DateTime.Now;


    }
}
