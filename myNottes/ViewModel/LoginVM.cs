using System.ComponentModel.DataAnnotations;

namespace myNottes.ViewModel
{
    public class LoginVM
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe  { get; set; }
    }
}
