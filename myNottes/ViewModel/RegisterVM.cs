using System.ComponentModel.DataAnnotations;

namespace myNottes.ViewModel
{
    public class RegisterVM
    {

        [Required]
        [Display(Name ="FirstName")]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set;}

        [Required]
        [Display(Name ="Email Address")]
        public string? Email { get; set; }

        [Required]
        public string ? UserName {  get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        [Compare("Password")]
       public string? ConformedPassword{ get; set;}
    }
}
