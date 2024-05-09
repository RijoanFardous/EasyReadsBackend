using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.DTOs
{
    public class UserDTO
    {
        [Required]
        [StringLength(30, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Only alphanumerical and _ are allowed.")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z .]+$", ErrorMessage = "Only alphabets, dots and spaces are allowed.")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;

        public string? UserType { get; set; } = string.Empty;

        public DateOnly? JoinDate { get; set; }
    }
}
