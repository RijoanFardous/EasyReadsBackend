using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.DTOs
{
    public class LikeDTO
    {
        public int LikeId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int ArticleId { get; set; }
        public DateTime LikedAt { get; set; }
    }
}
