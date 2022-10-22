using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Models
{
    public class TimeTrackerContext : DbContext
    {
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Project>? Projects { get; set; }
        public DbSet<WorkPeriod>? WorkPeriods { get; set; }

        public string? DbPath { get; }
    
        public TimeTrackerContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "timeTracker.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
