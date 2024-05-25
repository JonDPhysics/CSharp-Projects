using System.ComponentModel.DataAnnotaions;

namespace Allocations.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Please enter your email.")]
        public string LogEmail {get; set;}
        
        [Required(ErrorMessage = "Must enter a password.")]
        public string LogPassword {get; set;}
    }
}