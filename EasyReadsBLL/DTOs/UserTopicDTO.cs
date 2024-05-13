using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.DTOs
{
    public class UserTopicDTO
    {
        public int Id { get; set; }

        [Required]
        public int TopicId { get; set; }

        [Required]
        public string Username { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
