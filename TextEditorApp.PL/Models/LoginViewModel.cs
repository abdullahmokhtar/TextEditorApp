using System.ComponentModel.DataAnnotations;

namespace TextEditorApp.PL.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required]
        [MaxLength(6)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
