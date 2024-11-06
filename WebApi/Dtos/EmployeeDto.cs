using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApi.Dtos
{
    public class EmployeeDto
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Employee name is required.")]
        [StringLength(50)]
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        [Phone]
        [StringLength(10)]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email address is required.")]
        [StringLength(50)]
        [EmailAddress]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email format.")]
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public DepartmentDto department {  get; set; } 
    }
}
