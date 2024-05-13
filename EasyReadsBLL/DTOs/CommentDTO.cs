using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.DTOs
{
    public class CommentDTO
    {
        public int CommentId { get; set; }

        [Required]
        [StringLength(200)]
        public string Content { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [Required]
        public string Username { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
