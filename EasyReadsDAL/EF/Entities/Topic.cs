using System;
using System.ComponentModel.DataAnnotations;

namespace EasyReadsDAL.EF.Entities
{
	public class Topic
	{

		  [Key]
		  public int TopicId { get; set; }

		  [Required]
		  [StringLength(50)]
		  public string TopicName { get; set; }

		  public int FollowersCount { get; set; }

		  public DateTime AddDate { get; set; }
	  
		  
		  

	}
}



