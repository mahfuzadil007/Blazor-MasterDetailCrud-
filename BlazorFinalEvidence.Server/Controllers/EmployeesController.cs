using BlazorFinalEvidence.Server.Data;
using BlazorFinalEvidence.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorFinalEvidence.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public EmployeesController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            return await _db.Employees.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var emp = await _db.Employees.Include(s => s.Projects).FirstOrDefaultAsync(s => s.Id == id);
            if (emp == null) { return NotFound(); }
            return emp;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(Employee emp)
        {
            _db.Employees.Add(emp);
            await _db.SaveChangesAsync();
            return emp.Id;
        }
        [HttpPut]
        public async Task<ActionResult> Put(Employee emp)
        {
            _db.Entry(emp).State = EntityState.Modified;
            foreach (var item in emp.Projects)
            {
                if (item.Id != 0)
                {
                    _db.Entry(item).State = EntityState.Modified;
                }
                else
                {
                    _db.Entry(item).State = EntityState.Added;
                }
            }
            var idsOfProjects = emp.Projects.Select(s => s.Id).ToList();
            var projectToDelete = await _db.Projects.Where(s => !idsOfProjects.Contains(s.Id) && s.EmployeeId == emp.Id).ToListAsync();
            _db.RemoveRange(projectToDelete);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var emp = await _db.Employees.Include(s => s.Projects).FirstOrDefaultAsync(s => s.Id == id);
            if (emp == null) return NotFound();
            _db.Projects.RemoveRange(emp.Projects);
            _db.Employees.Remove(emp);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
