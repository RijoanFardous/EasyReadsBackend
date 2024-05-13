using EasyReadsBLL.DTOs;
using EasyReadsDAL;
using EasyReadsDAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.Services
{
    public class BookmarkService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public BookmarkService(DataAccessFactory dataAccessFactory)
        {
            _dataAccessFactory = dataAccessFactory;
        }

        public BookmarkDTO? GetBookmark(int id)
        {
            var bookmark = _dataAccessFactory.BookmarkData().GetBookmark(id);
            if(bookmark != null)
            {
                var bookmarkDTO = Convert(bookmark);
                return bookmarkDTO;
            }
            return null;
        }

        public List<BookmarkDTO> GetAllBookmarks(string username)
        {
            var bookmarks = _dataAccessFactory.BookmarkData().GetBookmarks(username);
            var bookmarksDTO = Convert(bookmarks);
            return bookmarksDTO;
        }

        public void Create(BookmarkDTO bookmarkDTO)
        {
            Bookmark bookmark = new Bookmark();
            bookmark.ArticleId = bookmarkDTO.ArticleId;
            bookmark.UserName = bookmarkDTO.UserName;
            bookmark.TimeStamp = DateTime.Now;
            _dataAccessFactory.BookmarkData().Create(bookmark);
            _dataAccessFactory.ArticleData().IncBookmarkCount(bookmarkDTO.ArticleId);
        }

        public void Delete(BookmarkDTO bookmarkDTO)
        {
            _dataAccessFactory.BookmarkData().Delete(Convert(bookmarkDTO));
            _dataAccessFactory.ArticleData().DecBookmarkCount(bookmarkDTO.ArticleId);
        }


        public List<BookmarkDTO> Convert(List<Bookmark> bookmarks)
        {
            List<BookmarkDTO> bookmarksDTO = new List<BookmarkDTO>();
            foreach(var bookmark in bookmarks)
            {
                bookmarksDTO.Add(Convert(bookmark));
            }
            return bookmarksDTO;
        }
        public BookmarkDTO Convert(Bookmark bookmark)
        {
            return new BookmarkDTO
            {
                BookmarkId = bookmark.BookmarkId,
                UserName = bookmark.UserName,
                ArticleId = bookmark.ArticleId,
                TimeStamp = bookmark.TimeStamp,
            };
        }

        public Bookmark Convert(BookmarkDTO bookmark)
        {
            return new Bookmark
            {
                BookmarkId = bookmark.BookmarkId,
                UserName = bookmark.UserName,
                ArticleId = bookmark.ArticleId,
                TimeStamp = bookmark.TimeStamp,
            };
        }
    }
}
