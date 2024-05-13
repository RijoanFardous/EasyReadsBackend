using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyReadsDAL.EF.Entities
{
	public class Reply
	{
        [Key]
        public int ReplyId { get; set; }

        [Required]
        [StringLength(200)]
        public string Content { get; set; }

        [ForeignKey("Comment")]
        public int CommentId { get; set; }

        [ForeignKey("User")]
        public string Username { get; set; }

        public DateTime TimeStamp { get; set; }


        public virtual User User { get; set; }
        public virtual Comment Comment { get; set; }
    }
}




