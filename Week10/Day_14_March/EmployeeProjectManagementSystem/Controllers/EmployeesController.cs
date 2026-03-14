using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeProjectManagementSystem.Data;
using EmployeeProjectManagementSystem.Models;

public class EmployeesController : Controller
{
    private readonly AppDbContext _context;

    public EmployeesController(AppDbContext context)
    {
        _context = context;
    }

    // LIST ALL EMPLOYEES
    public IActionResult Index()
    {
        var employees = _context.Employees
                        .Include(e => e.Department)
                        .ToList();

        return View(employees);
    }

    // CREATE FORM
    public IActionResult Create()
    {
        ViewBag.Departments = _context.Departments.ToList();
        ViewBag.Projects = _context.Projects.ToList();

        return View();
    }

    // CREATE EMPLOYEE
    [HttpPost]
    public IActionResult Create(Employee employee, int[] projectIds)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();

        foreach (var pid in projectIds)
        {
            EmployeeProject ep = new EmployeeProject
            {
                EmployeeId = employee.EmployeeId,
                ProjectId = pid,
                AssignedDate = DateTime.Now
            };

            _context.EmployeeProjects.Add(ep);
        }

        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    public IActionResult ProjectsOfEmployee(int id)
{
    var projects = _context.EmployeeProjects
                    .Where(ep => ep.EmployeeId == id)
                    .Select(ep => ep.Project)
                    .ToList();

    return View(projects);
}
public IActionResult EmployeesPerDepartment()
{
    var result = _context.Employees
        .GroupBy(e => e.Department.Name)
        .Select(g => new DepartmentEmployeeCount
        {
            Department = g.Key,
            Count = g.Count()
        })
        .ToList();

    return View(result);
}
public IActionResult Details(int id)
{
    var employee = _context.Employees
        .Include(e => e.Department)
        .FirstOrDefault(e => e.EmployeeId == id);

    return View(employee);
}
public IActionResult Edit(int id)
{
    var employee = _context.Employees.Find(id);

    ViewBag.Departments = _context.Departments.ToList();

    return View(employee);
}
[HttpPost]
public IActionResult Edit(Employee employee)
{
    _context.Employees.Update(employee);
    _context.SaveChanges();

    return RedirectToAction("Index");
}
public IActionResult Delete(int id)
{
    var employee = _context.Employees.Find(id);

    _context.Employees.Remove(employee);

    _context.SaveChanges();

    return RedirectToAction("Index");
}
}