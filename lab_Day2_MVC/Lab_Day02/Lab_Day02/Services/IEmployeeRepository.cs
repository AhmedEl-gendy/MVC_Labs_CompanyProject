using Lab_Day02.Models;

namespace Lab_Day02.Services
{
    public interface IEmployeeRepository
    {
        int create(Employee employee);
        int delete(int id);
        List<Employee> getAll();
        Employee getById(int id);
        Employee getFullInfoById(int id);
        Employee getByIdAndFname(int SSN, string Fname);
        int update(Employee employee);
    }
}