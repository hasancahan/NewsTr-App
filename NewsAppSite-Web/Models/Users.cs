using System.ComponentModel.DataAnnotations;

namespace NewsAppSite_Web.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //public virtual ICollection<Comments> Comments { get; set; }
    }
}
