using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab_Day02.Models
{
    public class Location
    {
        [Key, Column(Order = 0)]
        public int DeptNum { get; set; }
        [Key, Column(Order = 1)]
        public string? Loc { get; set; }
        [ForeignKey("DeptNum")]
        public virtual Department? Department { get; set; }
    }
}
