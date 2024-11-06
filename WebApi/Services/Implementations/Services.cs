using WebApi.Data;
using WebApi.Data.Contract;
using WebApi.Dtos;
using WebApi.Model;
using WebApi.Services.Contract;

namespace WebApi.Services.Implementations
{
    public class Services:IServices
    {
        public readonly IRepository _repository;
        public Services(IRepository repository)
        {
            _repository = repository;
        }
        public ServiceResponse<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            var response = new ServiceResponse<IEnumerable<EmployeeDto>>();
            try
            {
                var employees = _repository.GetAllEmployeees();
                if (employees != null && employees.Any())
                {
                    List<EmployeeDto> employeeDtos = new List<EmployeeDto>();
                    foreach (var employee in employees)
                    {
                        employeeDtos.Add(new EmployeeDto()
                        {
                            EmployeeId = employee.EmployeeId,
                            EmployeeName = employee.EmployeeName,
                            Email = employee.Email,
                            Phone = employee.Phone,
                            DepartmentId = employee.DepartmentId,
                            department = new DepartmentDto
                            {
                                DepartmentId = employee.Department.DepartmentId,
                                DepartmentName=employee.Department.DepartmentName
                            },
                        });

                    }
                    response.Success = true;
                    response.Data = employeeDtos;
                }
                else
                {
                    response.Success = false;
                    response.Message = "No record found!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return response;
        }
        public ServiceResponse<EmployeeDto> GetEmployeeById(int id)
        {
            var response = new ServiceResponse<EmployeeDto>();
            try
            {
                var existingEmployee = _repository.GetEmployeeById(id);
                if (existingEmployee != null)
                {
                    var employee = new EmployeeDto()
                    {
                        EmployeeId = existingEmployee.EmployeeId,
                        EmployeeName = existingEmployee.EmployeeName,
                        Email = existingEmployee.Email,
                        Phone = existingEmployee.Phone,
                        department = new DepartmentDto
                        {
                            DepartmentId = existingEmployee.DepartmentId,
                            DepartmentName = existingEmployee.Department.DepartmentName,
                        }
                    };
                    response.Success = true;
                    response.Data = employee;
                }

                else
                {
                    response.Success = false;
                    response.Message = "Something went wrong,try after sometime";
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return response;
        }
        public ServiceResponse<string> AddEmployee(AddEmployeeDto employeeDto)
        {
            var response = new ServiceResponse<string>();
            try
            {
                if (_repository.EmployeeNameExists(employeeDto.EmployeeName))
                {
                    response.Success = false;
                    response.Message = "Employee name already exists";
                    return response;
                }
                if (_repository.EmployeeEmailExists(employeeDto.Email))
                {
                    response.Success = false;
                    response.Message = "Email address already exists";
                    return response;
                }
                var employee = new Employee()

                {
                    EmployeeName = employeeDto.EmployeeName,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                    DepartmentId = employeeDto.DepartmentId
                };
                var result = _repository.Add(employee);
                if (result)
                {
                    response.Success = true;
                    response.Message = "Employee Added Successfully";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Something went wrong. Please try later";
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return response;
        }
        public ServiceResponse<string> ModifyEmployee(UpdateEmployeeDto employeeDto)
        {
            var response = new ServiceResponse<string>();
            try
            {
                var message = string.Empty;
                if (_repository.EmployeeNameExists(employeeDto.EmployeeId, employeeDto.EmployeeName))
                {
                    response.Success = false;
                    response.Message = "Employee name already exists.";
                    return response;

                }
                if (_repository.EmployeeEmailExists(employeeDto.EmployeeId, employeeDto.Email))
                {
                    response.Success = false;
                    response.Message = "Email address already exists.";
                    return response;

                }
                var existingEmployee = _repository.GetEmployeeById(employeeDto.EmployeeId);
                var result = false;
                if (existingEmployee != null)
                {
                    existingEmployee.EmployeeName = employeeDto.EmployeeName;
                    existingEmployee.Email = employeeDto.Email;
                    existingEmployee.Phone = employeeDto.Phone;
                    existingEmployee.DepartmentId = employeeDto.DepartmentId;
                    result = _repository.Update(existingEmployee);
                }
                if (result)
                {
                    response.Success = true;
                    response.Message = "Employee updated successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Something went wrong,try after sometime";
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return response;

        }
        public ServiceResponse<string> RemoveEmployee(int id)
        {
            var response = new ServiceResponse<string>();
            try
            {
                var result = _repository.Delete(id);

                if (result)
                {
                    response.Success = true;
                    response.Message = "Employee deleted successfully";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Something went wrong";
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return response;
        }
        public ServiceResponse<IEnumerable<DepartmentDto>> GetAllDeparment()
        {
            var response = new ServiceResponse<IEnumerable<DepartmentDto>>();
            try
            {
                var departments = _repository.GetAllDepartments();
                if (departments != null && departments.Any())
                {
                    List<DepartmentDto> departmentDtos = new List<DepartmentDto>();
                    foreach (var department in departments)
                    {
                        departmentDtos.Add(new DepartmentDto()
                        {
                            DepartmentId = department.DepartmentId,
                            DepartmentName = department.DepartmentName
                        });

                    }
                    response.Success = true;
                    response.Data = departmentDtos;
                }
                else
                {
                    response.Success = false;
                    response.Message = "No record found!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return response;
        }

    }
}
