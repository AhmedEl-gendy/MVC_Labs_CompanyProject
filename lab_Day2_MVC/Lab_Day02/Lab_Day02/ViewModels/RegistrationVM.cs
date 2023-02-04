using System.ComponentModel.DataAnnotations;

namespace Lab_Day02.ViewModels
{
    public class RegistrationVM
    {
        [Key]
        [Required]
        public string UserName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }



    }
}
