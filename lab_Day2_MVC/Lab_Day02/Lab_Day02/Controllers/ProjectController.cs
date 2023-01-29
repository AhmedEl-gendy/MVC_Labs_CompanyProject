using Lab_Day02.Models;
using Lab_Day02.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab_Day02.Controllers
{
    public class ProjectController : Controller
    {
        private MVC_DbContext Db;
        public ProjectController()
        {
            Db = new MVC_DbContext();
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult showProjects()
        {
            var projects = Db.Projects.ToList();
            return View(projects);
        }

        public IActionResult getProjectById(int id)
        {
            var project = Db.Projects.Include(e => e.Department).SingleOrDefault(c => c.ProjectNumber == id);
            if (project == null)
            {
                return View("Error");
            }

            return View(project); 
        }

        [HttpGet]
        public IActionResult addProject()
        {
            var depts = new SelectList(Db.Departments.ToList(), "DeptNum", "DeptName");
            ViewBag.depts = depts;
            return View();
        }


        //public IActionResult addProjectDB(Project p)
        //{
        //    Db.Projects.Add(p);
        //    Db.SaveChanges();
        //    return RedirectToAction(nameof(showProjects));
        //}

        //using validation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult addProject(ProjectVM p)
        {
            List<string> validLocations = new List<string> { "cairo", "alex", "giza" };
            if (!validLocations.Contains(p.ProjectLocation))
            {
                ModelState.AddModelError("", "only available locations [cairo, alex, giza]");
            }
            //if (ModelState.GetFieldValidationState("ProjectLocation") == ModelValidationState.Valid
            //    && p.ProjectLocation.Contains("cairo")
            //    && p.ProjectLocation.Contains("alex")
            //    && p.ProjectLocation.Contains("giza")
            //    )
            //{
            //    ModelState.AddModelError("", "only available locations [cairo, alex, giza]");
            //}

            if (ModelState.IsValid)
            {
                Project newProject = new Project()
                {
                    ProjectName = p.ProjectName,
                    ProjectLocation = p.ProjectLocation,
                    DeptNum = p.DeptNum,
                };
                Db.Projects.Add(newProject);
                Db.SaveChanges();
                return RedirectToAction(nameof(showProjects));
            }
            return View();
        }

        public IActionResult updateProject(int id)
        {
            var project = Db.Projects.SingleOrDefault(d => d.ProjectNumber == id);
            var dept = new SelectList(Db.Departments.ToList(), "DeptNum", "DeptName");
            ViewBag.depts = dept;
            return View(project);
        }
        public IActionResult updateProjectDB(Project project)
        {
            var oldproject = Db.Projects.SingleOrDefault(d => d.ProjectNumber == project.ProjectNumber);
            oldproject.ProjectName = project.ProjectName;
            oldproject.ProjectLocation = project.ProjectLocation;
            oldproject.DeptNum = project.DeptNum;
            Db.SaveChanges();
            return RedirectToAction(nameof(showProjects));
        }
        public IActionResult deleteProject(int id)
        {
            var project = Db.Projects.SingleOrDefault(d => d.ProjectNumber == id);
            Db.Projects.Remove(project);
            Db.SaveChanges();
            return RedirectToAction(nameof(showProjects));
        }




















    }
}
