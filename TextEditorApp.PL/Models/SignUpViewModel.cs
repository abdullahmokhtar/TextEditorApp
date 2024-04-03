using System.ComponentModel.DataAnnotations;

namespace TextEditorApp.PL.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "User Name Is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required]
        [MaxLength(6)]
        public string Password { get; set; }
        [Required]
        [MaxLength(6)]
        [Compare("Password", ErrorMessage = "Password MisMatch")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Required")]
        //[Compare("True", ErrorMessage =)]
        private bool isAgree { get; set; }

        public bool IsAgree
        {
            get => isAgree;
            set => isAgree = value;
        }


    }
}
