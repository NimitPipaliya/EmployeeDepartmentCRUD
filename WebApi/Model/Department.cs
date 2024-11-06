using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
    public class Department
    {
        [Key]
        [Required] 
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
