using Lab_Day02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab_Day02.Controllers
{
    public class DepartmentController : Controller
    {
        MVC_DbContext Db;
        public DepartmentController()
        {
            Db = new MVC_DbContext();
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ShowDepartment()
        {

            var id = (int)HttpContext.Session.GetInt32("SSN");
            var department = Db.Departments.Include(e => e.Locations).Include(e => e.Employees).SingleOrDefault(e => e.ManagerSSN == id);
            return View(department);
        }

        public IActionResult ShowDeptProjects()
        {
            var id = (int)HttpContext.Session.GetInt32("SSN");
            var projects = Db.Projects.Where(e => e.DeptNum == e.Department.DeptNum && e.Department.ManagerSSN == id);
            return View(projects);
        }

        public IActionResult addEmpToDeptProject()
        {
            var id = (int)HttpContext.Session.GetInt32("SSN");
            var employees = Db.Employees.ToList();
            var projects = Db.Projects.Where(e => e.DeptNum == e.Department.DeptNum && e.Department.ManagerSSN == id);
            ViewData["projects"] = projects;
            return View(employees);
        }

        public IActionResult addToProject(int employee, List<int> project,int WorksHours)
        {
            foreach (var p in project)
            {
                WorkOn add = new WorkOn()
                {
                    EmpSSN = employee,
                    ProjectNum = p,
                    WorksHours = WorksHours,
                };
                Db.WorksOn.Add(add);
                Db.SaveChanges();
            }

            return RedirectToAction(nameof(ShowDepartment));
        }

        public IActionResult displayDepartments()
        {
            var dept = Db.Departments.ToList();
            return View(dept);

        }

        public IActionResult GetDeptById(int id)
        {
            var dept = Db.Departments.Include(e => e.Locations).Include(e => e.Projects).Include(e => e.Employees).SingleOrDefault(c => c.DeptNum == id);
            if (dept == null)
            {
                return View("Error");
            }
            var Employee = Db.Employees.Include(d => d.Department).SingleOrDefault(e => e.SSN == dept.ManagerSSN);
            ViewData["Employee"] = Employee;
            return View(dept);
        }

        public IActionResult addDepartment()
        {

            var emp = new SelectList(Db.Employees.ToList(), "SSN", "Fname");

            return View(emp);
        }

        public IActionResult saveDepartment(Department dept)
        {
            Db.Departments.Add(dept);
            Db.SaveChanges();
            return RedirectToAction(nameof(displayDepartments));
        }


        public IActionResult updateDepartment(int id)
        {
            var dept = Db.Departments.SingleOrDefault(d => d.DeptNum == id);
            var emp = new SelectList(Db.Employees.ToList(), "SSN", "Fname");
            ViewBag.list = emp;
            return View(dept);
        }
        public IActionResult saveUpdate(Department dept)
        {
            var oldDept = Db.Departments.SingleOrDefault(d => d.DeptNum == dept.DeptNum);
            oldDept.DeptName = dept.DeptName;
            oldDept.ManagerHiredate = dept.ManagerHiredate;
            oldDept.ManagerSSN = dept.ManagerSSN;
            Db.SaveChanges();
            return RedirectToAction(nameof(displayDepartments));
        }

        public IActionResult deleteDepartment(int id)
        {
            var dept = Db.Departments.SingleOrDefault(d => d.DeptNum == id);
            Db.Departments.Remove(dept);
            Db.SaveChanges();
            return RedirectToAction(nameof(displayDepartments));
        }




    }
}
