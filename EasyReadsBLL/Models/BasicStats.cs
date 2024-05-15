using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.Models
{
    public class BasicStats
    {
        public int TotalUsers { get; set; }
        public int TotalAuthors { get; set; }
        public int UsersJoinedToday { get; set; }
        public int TotalArticlesPosted { get; set; }
        public int ArticlesPostedToday { get; set; }
    }
}
