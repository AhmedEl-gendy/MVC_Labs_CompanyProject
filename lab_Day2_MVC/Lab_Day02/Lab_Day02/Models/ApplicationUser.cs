using Microsoft.AspNetCore.Identity;

namespace Lab_Day02.Models
{
    public class ApplicationUser :IdentityUser
    {

        public string Address { get; set; }

        public int Age { get; set; }

        public DateTime RegisterDate { get; set; }


    }
}
