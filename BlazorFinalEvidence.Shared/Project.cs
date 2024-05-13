using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFinalEvidence.Shared
{
    public class Project
    {
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public decimal? ProjectBudget {  get; set; }
        public int EmployeeId {  get; set; }
    }
}
