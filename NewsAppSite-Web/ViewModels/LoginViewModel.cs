using System.ComponentModel.DataAnnotations;

namespace NewsAppSite_Web.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
