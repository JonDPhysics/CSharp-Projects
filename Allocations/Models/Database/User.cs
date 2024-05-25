using System;
using System.Collection.Generic;
using System.ComponentModel.DataAnnotaions;
using System.ComponentModel.DataAnnotaions.Schema;

namespace Allocations.Models
{

    public class User
    {
        [Key]
        public int usersID {get; set;}

        [Required(ErrorMessage = "Please enter your first name.")]
        [Display(firstName = "First Name: ")]
        [RegularExpression("^[A-Za-z ]+$")]
        public string firstName {get; set;}

        [Required(ErrorMessage = "Please enter your last name.")]
        [Display(lastName = "Last Name: ")]
        [RegularExpression("^[A-Za-z ]+$")]
        public string lastName {get; set;}

        [Required(ErrorMessage = "Please enter your email address.")]
        [DataType(DataType.Text)]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(email = "Email: ")]
        public string email {get; set;}
        
        [Required(ErrorMessage = "You must enter a password")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters in length.")]
        [DataType(DataType.Password)]
        [Display(passwordHash = "Password: ")]
        public string passwordHash {get; set;}

        [NotMapped]
        [Compare("Password", ErrorMessage = "Your password must match.")]
        [Display(confirmPassword = "Confirm Password: ")]
        public string confirmPassword {get; set;}

        public DateTime createdAt {get; set;} = DateTime.Now;
        public DateTime updatedAt {get; set;} = DateTime.Now;
    }
    
}