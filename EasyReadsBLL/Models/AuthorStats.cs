using EasyReadsBLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.Models
{
    public class AuthorStats
    {
        public DateTime StartDate { get; set; } = DateTime.Now.AddDays(-6);
        public DateTime EndDate { get; set; } = DateTime.Now;
        public string Username { get; set; }
        public int ArticlePosted { get; set; }
        public int FollowerGained { get; set; }
        public int LikesReceived { get; set; }
        public int CommentsReceived { get; set; }
        public int BookmarkReceived { get; set; }
        public List<ArticleDTO>? TopArticles { get; set; }
    }
}
