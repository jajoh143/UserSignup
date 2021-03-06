using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserSignup.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Display(Name = "Username")]
        [Required]
        public string Username {get; set;}
        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string Email {get; set;}
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}
    }

    public class UserPost : User
    {
        [Compare("Password")]
        [Display(Name = "Verify Password")]
        [DataType(DataType.Password)]
        public string Verify { get; set; }
    }
}