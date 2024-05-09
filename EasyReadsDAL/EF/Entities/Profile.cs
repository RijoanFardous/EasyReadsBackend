using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.EF.Entities
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }

        [StringLength(200)]
        public string? ProfilePicture { get; set; }

        [StringLength(150)]
        public string? Bio { get; set; }

        [StringLength(150)]
        public string? Address { get; set; }

        [StringLength(100)]
        public string? Website { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }

        [ForeignKey("User")]
        public string Username { get; set; }

        public virtual User User { get; set; }
    }
}
