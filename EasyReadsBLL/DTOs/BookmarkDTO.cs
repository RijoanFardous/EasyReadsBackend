using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.DTOs
{
    public class BookmarkDTO
    {
        public int BookmarkId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public int ArticleId { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
