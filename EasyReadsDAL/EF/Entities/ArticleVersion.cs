using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.EF.Entities
{
    public class ArticleVersion
    {
        [Key]
        public int VersionId { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 50)]
        public string Content { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public int NumberOfWords { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual Article Article { get; set; }
    }
}
