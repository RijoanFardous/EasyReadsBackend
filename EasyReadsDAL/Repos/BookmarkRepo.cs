using EasyReadsDAL.EF;
using EasyReadsDAL.EF.Entities;
using EasyReadsDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.Repos
{
    public class BookmarkRepo: IBookmarkRepo
    {
        private readonly EasyReadsContext _db;
        public BookmarkRepo(EasyReadsContext db)
        {
            _db = db;
        }

        public void Create(Bookmark bookmark)
        {
            _db.Bookmarks.Add(bookmark);
            _db.SaveChanges();
        }

        public void Delete(Bookmark bm)
        {
            var bookmark = (from b in _db.Bookmarks where b.ArticleId == bm.ArticleId && b.UserName.Equals(bm.UserName) select b).FirstOrDefault();
            if(bookmark != null )
            {
                _db.Bookmarks.Remove(bookmark);
                _db.SaveChanges();
            }
        }

        public void DeleteAll(string username)
        {
            var bookmarks = (from b in _db.Bookmarks where b.UserName.Equals(username) select b).ToList();
            foreach (var bookmark in bookmarks)
            {
                _db.Bookmarks.Remove(bookmark);
            }
            _db.SaveChanges();
        }

        public List<Bookmark> GetArticleBookmarks(int articleId)
        {
            var bookmarks = (from b in _db.Bookmarks where b.ArticleId == articleId select b).ToList();
            return bookmarks;
        }

        public List<Bookmark> GetArticleBookmarksByDate(int articleId, DateTime startdate, DateTime enddate)
        {
            var bookmarks = (from b in _db.Bookmarks 
                             where b.ArticleId == articleId && b.TimeStamp >= startdate && b.TimeStamp <= enddate
                             select b).ToList();
            return bookmarks;
        }

        public Bookmark? GetBookmark(int id)
        {
            return _db.Bookmarks.Find(id);
        }

        public List<Bookmark> GetBookmarks(string username)
        {
            var bookmarks = (from b in _db.Bookmarks where b.UserName.Equals(username) select b).ToList();
            return bookmarks;
        }

        public void Update(Bookmark bookmark)
        {
            throw new NotImplementedException();
        }
    }
}
