﻿
using Lab_Day02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab_Day02.Controllers
{
    public class EmployeeController : Controller
    {
        private MVC_DbContext dbContext;
        public EmployeeController()
        {
            dbContext = new MVC_DbContext();
        }
        public IActionResult Index()
        {
            List<Employee> employees = dbContext.Employees.ToList();
            return View(employees);
        }

        //public IActionResult GetById(int id)
        //{
        //    Employee? employee = dbContext.Employees.Include(e => e.Supervisor).Include(e => e.Department).Include(e => e.Dependents).SingleOrDefault(c => c.SSN == id);
        //    if (employee == null)
        //    {
        //        return View("Error");
        //    }
        //    return View(employee);
        //}
        public IActionResult GetById()
        {
            
            int employeeSSN = (int)HttpContext.Session.GetInt32("SSN");
            var employee = dbContext.Employees.Include(e => e.Supervisor).Include(e => e.Department).Include(e => e.Dependents).SingleOrDefault(c => c.SSN == employeeSSN);
            if (employee == null)
            {
                return View("Error");
            }
            //var depeartment = dbContext.Departments.ToList();
            //ViewBag.depeartment = depeartment;
            return View(employee);
        }




        public IActionResult AddEmployee()
        {

            List<Employee> employees = dbContext.Employees.ToList();
            return View(employees);
        }

        public IActionResult AddDB(Employee employee)
        {


            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();

            List<Employee> employees = dbContext.Employees.ToList();
            return View("Index", employees);
        }

        public IActionResult Edit(int id)
        {
            Employee employee = dbContext.Employees.SingleOrDefault(c => c.SSN == id);
            List<Employee> employees = dbContext.Employees.ToList();
            List<Department> departments = dbContext.Departments.ToList();
            ViewBag.department = departments;

            ViewBag.employee = employees;
            return View(employee);
        }

        public IActionResult EditDb(Employee employee)
        {
            Employee oldData = dbContext.Employees.FirstOrDefault(c => c.SSN == employee.SSN);
            if (oldData != null)
            {
                oldData.Fname = employee.Fname;
                oldData.Lname = employee.Lname;
                oldData.Address = employee.Address;
                oldData.Salary = employee.Salary;
                oldData.BirthDate = employee.BirthDate;
                oldData.Sex = employee.Sex;
                oldData.SupervisorID = employee.SupervisorID;
                oldData.DepartmentNum = employee.DepartmentNum;

            }
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Employee employee = dbContext.Employees.SingleOrDefault(c => c.SSN == id);
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult LoginSSN(int SSN, string Fname)
        {
            var employee = dbContext.Employees.SingleOrDefault(e => e.SSN == SSN && e.Fname == Fname);
            if (employee == null)
            {
                // login failed
                ModelState.AddModelError("", "Invalid SSN or Fname");
                return View();
            }
            else
            {
                // login successful
                HttpContext.Session.SetInt32("SSN", SSN);
                return RedirectToAction(nameof(GetById));
            }
        }


        public IActionResult EmpDependents(int SSN)
        {
            var employeeSSN = HttpContext.Session.GetInt32("SSN");
            var dependents = dbContext.Dependents.Where(d => d.EmpSSN == employeeSSN).ToList();
            return View(dependents);
        }

        public IActionResult AddDependent()
        {
            var employeeSSN = HttpContext.Session.GetInt32("SSN");
            TempData["msg"] = "Dependent Added Successfully!";
            List<Employee> employees = dbContext.Employees.ToList();
            List<Dependent> dependents = dbContext.Dependents.ToList();
            ViewBag.employeeSSN = employeeSSN;
            return View(dependents);
        }

        public IActionResult AddDependentDB(Dependent dependent)
        {
            dependent.EmpSSN = HttpContext.Session.GetInt32("SSN").Value;
            dbContext.Dependents.Add(dependent);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(EmpDependents));
        }

        public IActionResult UpdateDependent(string DependName)
        {
            //var EmpSSN = HttpContext.Session.GetInt32("SSN").Value;
            //var dependent = dbContext.Dependents.SingleOrDefault(d => d.EmpSSN == EmpSSN && d.DependName == DependName);
            var dependent = dbContext.Dependents.SingleOrDefault(d => d.DependName == DependName);

            if (dependent == null)
            {
                // dependent not found
                return Empty;
            }
            else
            {
                TempData["msg"] = "Dependent Updated Successfully!";
                // return the dependent data to the update dependent view
                return View(dependent);
            }
        }

        [HttpPost]
        public IActionResult UpdateDependentDB(Dependent dependent)
        {

            var oldDependent = dbContext.Dependents.SingleOrDefault(d => d.EmpSSN == dependent.EmpSSN && d.DependName == dependent.DependName);
            if (oldDependent == null)
            {
                // dependent not found
                return NotFound();
            }
            else
            {
                // update the dependent's data
                oldDependent.DependName = dependent.DependName;
                oldDependent.DependSex = dependent.DependSex;
                oldDependent.DependBirthDate = dependent.DependBirthDate;
                oldDependent.Relationship = dependent.Relationship;

                dbContext.SaveChanges();
                return RedirectToAction(nameof(EmpDependents));
            }
        }

        public IActionResult DeleteDependent(int EmpSSN, string DependName)
        {
            EmpSSN = HttpContext.Session.GetInt32("SSN").Value;
            var dependent = dbContext.Dependents.SingleOrDefault(d => d.EmpSSN == EmpSSN && d.DependName == DependName);
            if (dependent == null)
            {
                // dependent not found
                return NotFound();
            }
            else
            {
                dbContext.Dependents.Remove(dependent);
                dbContext.SaveChanges();
                TempData["msg"] = "Dependent Deleted Successfully!";
                return RedirectToAction(nameof(EmpDependents));
            }
        }





    }
}