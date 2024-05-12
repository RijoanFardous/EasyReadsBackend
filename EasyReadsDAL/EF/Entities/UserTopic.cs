using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyReadsDAL.EF.Entities
{
	public class UserTopic
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("Topic")]
		public int TopicId { get; set; }

		[ForeignKey("User")]
		public string Username { get; set; }

		public DateTime TimeStamp { get; set; }

		public virtual User User {get;set;}
		public virtual Topic Topic { get; set; }
		
	}
}



