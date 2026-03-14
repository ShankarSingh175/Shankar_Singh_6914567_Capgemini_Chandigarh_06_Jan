using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeProjectManagementSystem.Data;
using EmployeeProjectManagementSystem.Models;

public class ProjectsController : Controller
{
    private readonly AppDbContext _context;

    public ProjectsController(AppDbContext context)
    {
        _context = context;
    }

    // SHOW PROJECT LIST
    public IActionResult Index()
    {
        var projects = _context.Projects.ToList();
        return View(projects);
    }

    // CREATE PROJECT FORM
    public IActionResult Create()
    {
        ViewBag.Employees = _context.Employees.ToList();
        return View();
    }

    // SAVE PROJECT
    [HttpPost]
    public IActionResult Create(Project project, int[] employeeIds)
    {
        _context.Projects.Add(project);
        _context.SaveChanges();

        foreach (var empId in employeeIds)
        {
            EmployeeProject ep = new EmployeeProject
            {
                EmployeeId = empId,
                ProjectId = project.ProjectId,
                AssignedDate = DateTime.Now
            };

            _context.EmployeeProjects.Add(ep);
        }

        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    public IActionResult EmployeesInProject(int id)
{
    var employees = _context.EmployeeProjects
                    .Where(ep => ep.ProjectId == id)
                    .Select(ep => ep.Employee)
                    .Include(e => e.Department)
                    .ToList();

    return View(employees);
}
public IActionResult Dashboard()
{
    var projects = _context.Projects
        .Include(p => p.EmployeeProjects)
        .ThenInclude(ep => ep.Employee)
        .ThenInclude(e => e.Department)
        .ToList();

    return View(projects);
}
}