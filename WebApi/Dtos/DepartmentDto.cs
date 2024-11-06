using System.ComponentModel.DataAnnotations;
using WebApi.Model;

namespace WebApi.Dtos
{
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
