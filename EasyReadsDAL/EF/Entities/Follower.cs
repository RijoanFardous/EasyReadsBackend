using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.EF.Entities
{
    public class Follower
    {
        [Key]
        public int FollowerId { get; set; }

        [ForeignKey("FollowerUser")]
        public string FollowerUsername { get; set; }

        [ForeignKey("FollowedUser")]
        public string FollowedUsername { get; set; }
        public DateTime FollowedAt { get; set; }

        public virtual User FollowerUser { get; set; }
        public virtual User FollowedUser { get; set; }

    }
}
