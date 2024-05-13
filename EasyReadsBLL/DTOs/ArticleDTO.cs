using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.DTOs
{
    public class ArticleDTO
    {
        public int ArticleId { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 50)]
        public string Content { get; set; }

        [Required]
        public string WrittenBy { get; set; }

        public string? CoverImage { get; set; }

        [Required]
        public string Audience { get; set; }

        [Required]
        public int TopicId { get; set; }

        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public int BookmarksCount { get; set; }
        public int NumberOfWords { get; set; }
        public DateTime? PostedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
