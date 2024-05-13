using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.DTOs
{
    public class FollowerDTO
    {
        public int FollowerId { get; set; }

        [Required]
        public string FollowerUsername { get; set; }

        [Required]
        public string FollowedUsername { get; set; }
        public DateTime FollowedAt { get; set; }
    }
}
