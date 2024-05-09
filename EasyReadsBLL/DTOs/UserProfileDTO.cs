using EasyReadsDAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.DTOs
{
    public class UserProfileDTO
    {
        public string Username { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z .]+$", ErrorMessage = "Only alphabets, dots and spaces are allowed.")]
        public string FullName { get; set; }

        public string? Email { get; set; }

        public string? UserType { get; set; }

        public DateOnly? JoinDate { get; set; }

        public string? ProfilePicture { get; set; }

        [StringLength(150)]
        public string? Bio { get; set; }

        [StringLength(150)]
        public string? Address { get; set; }

        [StringLength(100)]
        public string? Website { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
    }
}
