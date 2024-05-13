using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.EF.Entities
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }

        [ForeignKey("User")]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string Status { get; set; }
        public DateTime AppliedAt { get; set; }

        public virtual User User { get; set; }
    }
}
