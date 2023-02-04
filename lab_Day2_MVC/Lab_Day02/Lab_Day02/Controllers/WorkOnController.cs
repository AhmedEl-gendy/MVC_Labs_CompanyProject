using Lab_Day02.Models;
using Lab_Day02.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab_Day02.Controllers
{
    public class WorkOnController : Controller
    {
        MVC_DbContext Db;

        public WorkOnController()
        {
            Db = new MVC_DbContext();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EmpProjects()
        {
            //var works = Db.WorksOn.SingleOrDefault(e => e.ProjectNum == p && e.EmpSSN == id);
            //var projects = new SelectList(Db.Projects.ToList(), "ProjectNumber", "ProjectName");
            //ViewBag.projects = projects;
            var emps = new SelectList(Db.Employees.Select(s => new {s.SSN, FullName = s.Fname + " " + s.Lname}).ToList(), "SSN", "FullName");
            ViewBag.emps = emps;

            return View("_EmpProjects");
        }

        [HttpPost]
        public IActionResult EditEmpProjects(EmpProjectsVM wo)
        {
            var old = Db.WorksOn.SingleOrDefault(e => e.EmpSSN == wo.EmpSSN && e.ProjectNum == wo.ProjectNum);
            old.WorksHours = wo.WorksHours;

            if (ModelState.IsValid)
            {
                Db.SaveChanges();
 
            }
            return RedirectToAction("Index","Home");
        }

        public IActionResult EditEmpProjects_Projects(int id)
        {
            var projects = Db.WorksOn.Include(p => p.Employee).Where(p => p.EmpSSN == id).Select(p => p.Project).ToList();
            ViewBag.projects = new SelectList(projects, "ProjectNumber", "ProjectName");
             

            return PartialView("_ProjectsList");      
        }

        public IActionResult EditEmpProjects_Hours(int id, int ProjectNum)
        {
            var hours = Db.WorksOn.SingleOrDefault(h => h.EmpSSN == id && h.ProjectNum == ProjectNum);
            return PartialView("_Hours", hours);
        }
        















        }
}
