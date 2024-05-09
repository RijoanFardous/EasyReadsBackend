using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.EF.Entities
{
    public class User
    {
        [Required]
        [StringLength(30, MinimumLength = 4)]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Only alphanumerical and _ are allowed.")]
        [Key]
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
        public string HashedPassword { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string UserType { get; set; } = string.Empty;

        [Required]
        public DateOnly JoinDate { get; set; }
    }
}
