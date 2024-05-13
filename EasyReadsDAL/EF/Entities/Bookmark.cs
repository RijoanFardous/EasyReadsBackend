using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyReadsDAL.EF.Entities
{
	public class Bookmark
	{
		[Key]
		public int BookmarkId { get; set; }

		[ForeignKey("User")]
		public string UserName { get; set; }

		[ForeignKey("Article")]
		public int ArticleId { get; set; }

		public DateTime TimeStamp { get; set; }


		public virtual User User { get; set; }
		public virtual Article Article { get; set; }
		


	}
}

