using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFinalEvidence.Shared
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime JoiningDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
        public string? ImageUrl { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
