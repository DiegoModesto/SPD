using System.ComponentModel.DataAnnotations;

namespace SPD.Api.Authentication.ViewModel.AuthViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username must be write")]
        [MinLength(5, ErrorMessage = "Username must be 5 alphanumeric min length")]
        [MaxLength(30, ErrorMessage = "Username must be 30 alphanumeric length")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Email must be write")]
        [EmailAddress(ErrorMessage = "Email's field must be a valid email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "First name must be write")]
        [MinLength(3, ErrorMessage = "First name must be 3 alphanumeric min length")]
        [MaxLength(15, ErrorMessage = "First name must be 15 alphanumeric length")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last name must be write")]
        [MinLength(3, ErrorMessage = "Last name must be 3 alphanumeric min length")]
        [MaxLength(15, ErrorMessage = "Last name must be 15 alphanumeric length")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Password must be write")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$", ErrorMessage = "Password needs: 1 small-case letter, 1 Capital letter, 1 digit, 1 special character and the length should be between 6-10 characters")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Email must be write")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
