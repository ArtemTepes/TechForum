using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechForum.Models
{
    public class RegisterModel
    {


        [Required]        
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Please enter a valid email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "Length of user name must be in range from 4 to 12")]
        [RegularExpression(@"^[A-Za-z0-9_]*$", ErrorMessage = "Please use only letters, numbers or underlines ")]
        [Display(Name = "Nickname")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"[A-Za-z0-9_]", ErrorMessage = "Please use only letters, numbers or underlines ")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Length of password must be in range from 6 to 16")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Length of password must be in range from 6 to 16")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

    }
}