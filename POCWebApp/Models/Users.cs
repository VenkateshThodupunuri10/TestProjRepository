using System.ComponentModel.DataAnnotations;

namespace POCWebApp.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        [Unique]
        [RegularExpression( @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Invalid Email Id")]
        public string Email { get; set; }
        [Required]
        [StringLength(20,MinimumLength=6)]
        public string Password { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime UpdatedDateTime { get; set; }

    }
}
