using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.EF.Entities
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 50)]
        public string Content { get; set; }

        [Required]
        [ForeignKey("Author")]
        public string WrittenBy { get; set; }

        [StringLength(150)]
        public string? CoverImage { get; set; }

        [Required]
        [StringLength(20)]
        public string Audience { get; set; }

        [ForeignKey("Topic")]
        public int TopicId { get; set; }

        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public int BookmarksCount { get; set; }
        public int NumberOfWords { get; set; }
        public DateTime PostedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual User Author { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
