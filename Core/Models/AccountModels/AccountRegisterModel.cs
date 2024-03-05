using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core.Models.AccountModels
{
    public class AccountRegisterModel
    {
        [Required(ErrorMessage = "UserName is required")]
        [StringLength(20, ErrorMessage = "UserName must be less than 20 characters")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Characters are not allowed.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Customer Password is required")]
        [StringLength(30, ErrorMessage = "Password must be between 5 and 30 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password Confirm is required")]
        [Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }
        [Required(ErrorMessage = "Customer IdentityCard is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Customer's Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Invalid Phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(50, ErrorMessage = "Address must be less than 50 characters")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Customer Birthday Date is required")]
        [BirthDateValid]
        public DateTimeOffset Birthday { get; set; }
/*        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }*/
    }
    public class BirthDateValidAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(Object? value, ValidationContext validationContext)
        {
            DateTime now = DateTime.Today;
            DateTimeOffset birthDateValue = (DateTimeOffset)value;
            if (now < birthDateValue)
            {
                return new ValidationResult("The Customer hasn't born yet?");

            }
            /* if (now < birthDateValue.AddYears(18))
             {
                 return new ValidationResult("The Employee does not 18 years old");

             }*/
            if (now > birthDateValue.AddYears(125))
            {
                return new ValidationResult("The Customer absolutely already dead");
            }
            /*if (now > birthDateValue.AddYears(65))
            {
                return new ValidationResult("The Customer's age is over 65");
            }*/

            return ValidationResult.Success;
        }
    }
}
