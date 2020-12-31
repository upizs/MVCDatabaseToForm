using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDataFormDatabaseToForm.Models
{
    public class EmployeeModel
    {
        [Display(Name = "Employee ID")]
        [Range(10000,99999, ErrorMessage ="You need to enter a valid Employee ID")]
        public int EmployeeId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You need to give us your first name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to give us your last name")]
        public string LastName { get; set; }
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You need to give us your email address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Comfirm Email")]
        [DataType(DataType.EmailAddress)]
        [Compare("EmailAddress", ErrorMessage = "The Email and Comfirm Email does not match")]
        public string ConfirmEmailAddress { get; set; }
        
        [Required(ErrorMessage = "You must create a password")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage ="Password must be at least 6 characers long")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Comfirm Password")]
        [Compare("Password", ErrorMessage = "The Password and Compare Password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}