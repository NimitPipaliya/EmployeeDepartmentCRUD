using WebApi.Model;

namespace WebApi.Data.Contract
{
    public interface IRepository
    {
        bool Add(Employee employee);
        bool Update(Employee employee);
        bool Delete(int id);
        IEnumerable<Employee> GetAllEmployeees();
        Employee? GetEmployeeById(int id);
        bool EmployeeNameExists(string name);
        bool EmployeeEmailExists(string Email);
        bool EmployeeNameExists(int id, string name);
        bool EmployeeEmailExists(int id, string Email);
        IEnumerable<Department> GetAllDepartments();
    }
}
