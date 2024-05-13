using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.EF.Entities
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        [ForeignKey("User")]
        public string Username { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public DateTime LikedAt { get; set; }

        public virtual User User { get; set; }
        public virtual Article Article { get; set; }
    }
}
