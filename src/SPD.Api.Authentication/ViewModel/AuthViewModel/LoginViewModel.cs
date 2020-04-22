using System.ComponentModel.DataAnnotations;

namespace SPD.Api.Authentication.ViewModel.AuthViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username must be write")]
        [MinLength(5, ErrorMessage = "Username must be 5 alphanumeric min length")]
        [MaxLength(30, ErrorMessage = "Username must be 30 alphanumeric length")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Password must be write")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$", ErrorMessage = "Password needs: 1 small-case letter, 1 Capital letter, 1 digit, 1 special character and the length should be between 6-10 characters")]
        public string Password { get; set; }

        public bool IsPersistent { get; set; } = false;
    }
}
