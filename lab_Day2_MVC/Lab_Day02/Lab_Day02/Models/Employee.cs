using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Day02.Models
{
    public class Employee
    {
        [Key]
        public int SSN { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [StringLength(50)]
        public string? Sex { get; set; }
        [StringLength(50)]
        public string? Fname { get; set; }
        [StringLength(50)]
        public string? Lname { get; set; }
        [StringLength(100)]
        public string? Address { get; set; }
        public int? Salary { get; set; }

        public int? SupervisorID { get; set; }
        [ForeignKey("SupervisorID")]
        public virtual Employee? Supervisor { get; set; }
        [ForeignKey("DepartmentNum")]
        public int? DepartmentNum { get; set; }
        public virtual Department? Department { get; set; }

        public List<Dependent>? Dependents { get; set; }
        public List<WorkOn>? WorksOn { get; set; }


    }
}
