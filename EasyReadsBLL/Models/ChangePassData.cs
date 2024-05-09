using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.Models
{
    public class ChangePassData
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string CurrentPass { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string NewPass { get; set; }
    }
}
