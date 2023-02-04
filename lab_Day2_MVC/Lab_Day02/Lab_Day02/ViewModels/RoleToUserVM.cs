using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Lab_Day02.ViewModels
{
    public class RoleToUserVM
    {

        [Key]
        [Display(Name = "User")]
        public string UserId { get; set; }
        [Display(Name = "Role")]
        public string RoleName { get; set; }
        public SelectList Users { get; set; }
        public SelectList Roles { get; set; }
    }



}
