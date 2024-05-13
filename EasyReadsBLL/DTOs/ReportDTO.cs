using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.DTOs
{
    public class ReportDTO
    {
        public int ReportId { get; set; }

        [Required]
        public string ArticleId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Reason { get; set; }

        public string? Status { get; set; }
        public DateTime ReportedAt { get; set; }
    }
}
