using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab_Day02.Models
{
    public class Dependent
    {
        [Key, Column(Order = 0)]
        public int EmpSSN { get; set; }
        [Key, Column(Order = 1)]
        [StringLength(50)]
        public string? DependName { get; set; }
        [StringLength(50)]
        public string? DependSex { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DependBirthDate { get; set; }
        [StringLength(50)]
        public string? Relationship { get; set; }
        [ForeignKey("EmpSSN")]
        public virtual Employee? Employee { get; set; }
    }
}
