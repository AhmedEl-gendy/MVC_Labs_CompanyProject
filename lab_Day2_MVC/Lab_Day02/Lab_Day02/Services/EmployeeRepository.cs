using Lab_Day02.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace Lab_Day02.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        MVC_DbContext Db;
        public EmployeeRepository(MVC_DbContext _Db)
        {
            Db = _Db;

        }

        public List<Employee> getAll()
        {
            return Db.Employees.ToList();
        }

        public Employee getById(int id)
        {
            return Db.Employees.SingleOrDefault(c => c.SSN == id);
        }

        public Employee getFullInfoById(int id)
        {
            return Db.Employees.Include(e => e.Supervisor).Include(e => e.Department).Include(e => e.Dependents).SingleOrDefault(c => c.SSN == id);
        }

        public int create(Employee employee)
        {
            Db.Employees.Add(employee);
            int rawsEffected = Db.SaveChanges();
            return rawsEffected;
        }

        public int update(Employee employee)
        {
            Employee oldEmployee = Db.Employees.FirstOrDefault(c => c.SSN == employee.SSN);
            if (oldEmployee != null)
            {
                oldEmployee.Fname = employee.Fname;
                oldEmployee.Lname = employee.Lname;
                oldEmployee.Address = employee.Address;
                oldEmployee.Salary = employee.Salary;
                oldEmployee.BirthDate = employee.BirthDate;
                oldEmployee.Sex = employee.Sex;
                oldEmployee.SupervisorID = employee.SupervisorID;
                oldEmployee.DepartmentNum = employee.DepartmentNum;

            }
            int rawsEffected = Db.SaveChanges();
            return rawsEffected;

        }


        public int delete(int id)
        {
            Employee employee = Db.Employees.SingleOrDefault(c => c.SSN == id);
            Db.Employees.Remove(employee);
            int rawsEffected = Db.SaveChanges();
            return rawsEffected;
        }

        public Employee getByIdAndFname(int SSN, string Fname)
        {
            return Db.Employees.SingleOrDefault(e => e.SSN == SSN && e.Fname == Fname);
        }








    }
}
