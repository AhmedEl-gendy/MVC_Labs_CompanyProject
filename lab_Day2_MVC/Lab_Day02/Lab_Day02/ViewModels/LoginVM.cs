using System.ComponentModel.DataAnnotations;

namespace Lab_Day02.ViewModels
{
    public class LoginVM
    {
        [Required]
        [Key]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
