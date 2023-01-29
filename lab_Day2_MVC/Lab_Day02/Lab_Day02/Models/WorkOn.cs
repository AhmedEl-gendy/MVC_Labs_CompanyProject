using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab_Day02.Models
{
    public class WorkOn
    {
        [Key, Column(Order = 0)]
        public int EmpSSN { get; set; }
        [Key, Column(Order = 1)]
        public int ProjectNum { get; set; }
        public int WorksHours { get; set; }
        [ForeignKey("EmpSSN")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("ProjectNum")]
        public virtual Project Project { get; set; }
    }
}
