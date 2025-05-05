using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Common.Models.User
{
    public class UserModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
