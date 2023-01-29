using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab_Day02.Models
{
    public class Project
    {
        [Key]
        public int ProjectNumber { get; set; }
        [StringLength(50)]
        public string? ProjectName { get; set; }
        [StringLength(50)]
        public string? ProjectLocation { get; set; }

        public int DeptNum { get; set; }
        [ForeignKey("DeptNum")]
        public virtual Department? Department { get; set; }
        public virtual List<WorkOn>? WorksOn { get; set; }
    }
}
