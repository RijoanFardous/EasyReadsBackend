using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.EF.Entities
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }

        [ForeignKey("User")]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Reason { get; set; }

        [Required]
        [StringLength(100)]
        public string Status { get; set; }
        public DateTime ReportedAt { get; set; }

        public virtual User User { get; set; }
        public virtual Article Article { get; set; }
    }
}
