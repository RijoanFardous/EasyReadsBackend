using EasyReadsDAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.Interfaces
{
    public interface IBookmarkRepo
    {
        public void Create(Bookmark bookmark);
        public void Delete(Bookmark bookmark);
        public void DeleteAll(string username);
        public void DeleteAllByArticle(int articleId);
        public void Update(Bookmark bookmark);
        public Bookmark? GetBookmark(int id);
        public List<Bookmark> GetBookmarks(string username);
        public List<Bookmark> GetArticleBookmarks(int articleId);
        public List<Bookmark> GetArticleBookmarksByDate(int articleId, DateTime startdate, DateTime enddate);
    }
}
