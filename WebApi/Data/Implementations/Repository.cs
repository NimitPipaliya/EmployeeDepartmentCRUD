using Microsoft.EntityFrameworkCore;
using WebApi.Data.Contract;
using WebApi.Model;

namespace WebApi.Data.Implementations
{
    public class Repository:IRepository
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public bool Add(Employee employee)
        {
            try
            {
                var result = false;
                if (employee != null)
                {
                    _appDbContext.Employees.Add(employee);
                    _appDbContext.SaveChanges();
                    result = true;
                }
                return result;
            }
            catch
            {
                throw new Exception();
            }
        }
        public bool Update(Employee employee)
        {
            try
            {
                var result = false;
                if (employee != null)
                {
                    _appDbContext.Employees.Update(employee);
                    _appDbContext.SaveChanges();
                    result = true;
                }
                return result;
            }
            catch
            {
                throw new Exception();
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var result = false;
                var employee = _appDbContext.Employees.Find(id);
                if (employee != null)
                { 
                    _appDbContext.Employees.Remove(employee);
                    _appDbContext.SaveChanges();
                    result = true;
                }
                return result;
            }
            catch
            {
                throw new Exception();
            }
        }
        public IEnumerable<Employee> GetAllEmployeees()
        {
            try
            {
                IEnumerable<Employee> employees = _appDbContext.Employees.Include(c=>c.Department).ToList();
                return employees;
            }
            catch
            {
                throw new Exception();
            }
        }
        public Employee? GetEmployeeById(int id)
        {
            try
            {
                var employee = _appDbContext.Employees.Include(c=>c.Department).FirstOrDefault(c => c.EmployeeId == id);
                return employee;
            }
            catch
            {
                throw new Exception();
            }
        }
        public bool EmployeeNameExists(string name)
        {
            try
            {
                var employees = _appDbContext.Employees.FirstOrDefault(c => c.EmployeeName.ToLower() == name.ToLower());
                if (employees != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new Exception();
            }
        }
        public bool EmployeeEmailExists(string Email)
        {
            try
            {
                var employees = _appDbContext.Employees.FirstOrDefault(c => c.Email.ToLower() == Email.ToLower());
                if (employees != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new Exception();
            }
        }
        public bool EmployeeNameExists(int id, string name)
        {
            try
            {
                var employee = _appDbContext.Employees.FirstOrDefault(c => c.EmployeeName.ToLower() == name.ToLower() && c.EmployeeId != id);
                if (employee != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new Exception();
            }
        }
        public bool EmployeeEmailExists(int id, string Email)
        {
            try
            {
                var employee = _appDbContext.Employees.FirstOrDefault(c => c.Email.ToLower() == Email.ToLower() && c.EmployeeId != id);
                if (employee != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new Exception();
            }
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            try
            {
                IEnumerable<Department> departments = _appDbContext.Departments.ToList();
                return departments;
            }
            catch
            {
                throw new Exception();
            }
        }

    }
}
