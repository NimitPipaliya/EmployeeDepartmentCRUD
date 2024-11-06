using WebApi.Dtos;
using WebApi.Model;

namespace WebApi.Services.Contract
{
    public interface IServices
    {
        ServiceResponse<IEnumerable<EmployeeDto>> GetAllEmployees();
        ServiceResponse<EmployeeDto> GetEmployeeById(int id);
        ServiceResponse<string> AddEmployee(AddEmployeeDto employeeDto);
        ServiceResponse<string> ModifyEmployee(UpdateEmployeeDto employeeDto);
        ServiceResponse<string> RemoveEmployee(int id);
        ServiceResponse<IEnumerable<DepartmentDto>> GetAllDeparment();
    }
}
