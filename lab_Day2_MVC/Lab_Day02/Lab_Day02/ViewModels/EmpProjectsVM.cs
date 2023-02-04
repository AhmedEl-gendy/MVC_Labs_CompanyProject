using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab_Day02.ViewModels
{
    public class EmpProjectsVM
    {

        [Display(Name = "Employee")]
        [Required(ErrorMessage = "Selecting an Employee is required")]
        public int EmpSSN { get; set; }

        [Display(Name = "Project")]
        [Required(ErrorMessage = "Selecting a Project is required")]
        public int? ProjectNum { get; set; }

        [Display(Name = "Working Hours")]
        [Required(ErrorMessage = "Work hours is required")]
        public int WorksHours { get; set; }

    }
}
