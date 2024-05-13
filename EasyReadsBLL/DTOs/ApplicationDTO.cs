using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.DTOs
{
    public class ApplicationDTO
    {
        public int ApplicationId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public string? Status { get; set; }
        public DateTime AppliedAt { get; set; }
    }
}
