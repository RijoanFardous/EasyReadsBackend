using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.EF.Entities
{
    public class Token
    {
        [Key]
        public int TokenId { get; set; }

        [Required]
        [StringLength(50)]
        public string TokenKey { get; set; }

        public DateTime CreatedAt { get; set; }

        [StringLength(30)]
        [ForeignKey("User")]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string UserType { get; set; }

        public virtual User User { get; set; }
    }
}
