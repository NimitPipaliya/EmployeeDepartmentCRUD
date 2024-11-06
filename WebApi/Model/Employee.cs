using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
    public class Employee
    {
        [Key]
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50)]
        public string EmployeeName { get; set; }
        [Required]
        [Phone]
        [StringLength (10)]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }

    }
}
