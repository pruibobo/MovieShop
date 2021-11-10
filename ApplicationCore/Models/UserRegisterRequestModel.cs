using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class UserRegisterRequestModel
    {
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(100,ErrorMessage = "The Password should be minimum of 8 characters " +
                                         "and maximum of 100 character",MinimumLength = 8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%^&*()]).{8,}$",
            ErrorMessage = "Password should have minimum of 8 characters and should " +
                           "include one upper, lower, number and a special character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required] 
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required] 
        [StringLength(100)]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


    }
}
