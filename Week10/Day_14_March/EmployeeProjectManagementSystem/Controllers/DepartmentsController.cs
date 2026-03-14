using Microsoft.AspNetCore.Mvc;
using EmployeeProjectManagementSystem.Data;
using EmployeeProjectManagementSystem.Models;
using System.Linq;

namespace EmployeeProjectManagementSystem.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }

        // LIST
        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }

        // CREATE PAGE
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public IActionResult Create(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // EDIT PAGE
        public IActionResult Edit(int id)
        {
            var dept = _context.Departments.Find(id);
            return View(dept);
        }

        // EDIT POST
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var dept = _context.Departments.Find(id);

            _context.Departments.Remove(dept);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}