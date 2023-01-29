using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab_Day02.ViewModels
{
    public class ProjectVM
    {
        public int ProjectNumber { get; set; }

        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "Name is required")]
        [MinLength(5, ErrorMessage = "Name must be more than or equal 5 letters")]
        public string ProjectName { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "Location is required")]
        [Remote("validLocations", "CustomeValidation", ErrorMessage = "location must be only one of these [cairo, alex, giza]")]
        public string ProjectLocation { get; set; }

        [Compare("ProjectLocation")]
        [Display(Name = "Confirm Location")]
        public string ConfirmProjectLocation { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Select a Department")]
        public int DeptNum { get; set; }


    }
}
