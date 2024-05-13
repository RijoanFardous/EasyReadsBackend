using EasyReadsDAL.EF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.EF
{
    public class EasyReadsContext : DbContext
    {
        public EasyReadsContext(DbContextOptions<EasyReadsContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleVersion> ArticleVersions { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<UserTopic> UserTopics { get; set; }
    }
}
