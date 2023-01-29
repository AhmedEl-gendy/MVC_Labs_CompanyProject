using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab_Day02.Models
{
    public class Department
    {
        [Key]
        public int DeptNum { get; set; }
        [StringLength(50)]
        public string? DeptName { get; set; }
        public int? ManagerSSN { get; set; }
        [ForeignKey("ManagerSSN")]
        public virtual Employee? Manager { get; set; }
        [DataType(DataType.Date)]
        public DateTime ManagerHiredate { get; set; }

        public virtual List<Employee>? Employees { get; set; }
        public virtual List<Project>? Projects { get; set; }
        public virtual List<Location>? Locations { get; set; }
    }
}
