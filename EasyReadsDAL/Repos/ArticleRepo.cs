using EasyReadsDAL.EF;
using EasyReadsDAL.EF.Entities;
using EasyReadsDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.Repos
{
    public class ArticleRepo : IArticleRepo
    {
        private readonly EasyReadsContext _context;
        public ArticleRepo(EasyReadsContext context)
        {
            _context = context;
        }

        public void CreateArticle(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }


        public void DeleteArticle(int id)
        {
            var article = _context.Articles.Find(id);
            _context.Articles.Remove(article);
            _context.SaveChanges();
        }

        public List<Article> GetAllArticles()
        {
            return _context.Articles.ToList();
        }

        public List<Article> GetAllArticlesOfAuthor(string username)
        {
            return (from article in _context.Articles where article.WrittenBy.Equals(username) select article).ToList();
        }

        public List<Article> GetAllArticlesOfTopic(int topicId)
        {
            throw new NotImplementedException();
        }

        public Article? GetArticle(int id)
        {
            var article = _context.Articles.Find(id);
            return article;
        }

        public List<Article> GetFollowersOnlyArticlesOfAuthor(string username)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetPublicArticlesofAuthor(string username)
        {
            var articles = (from article in _context.Articles
                            where article.WrittenBy.Equals(username) && article.Audience.Equals("Public")
                            orderby article.LikesCount descending, article.CommentsCount descending, article.BookmarksCount descending
                            select article).ToList();

            return articles;
        }

        public void IncBookmarkCount(int id)
        {
            throw new NotImplementedException();
        }

        public void IncCommentsCount(int id)
        {
            throw new NotImplementedException();
        }

        public void IncLikesCount(int id)
        {
            throw new NotImplementedException();
        }

        public void DecBookmarkCount(int id)
        {
            throw new NotImplementedException();
        }

        public void DecCommentsCount(int id)
        {
            throw new NotImplementedException();
        }

        public void DecLikesCount(int id)
        {
            throw new NotImplementedException();
        }


        public void UpdateArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetAllPublicArticles()
        {
            return (from article in _context.Articles where article.Audience.Equals("Public") select article).ToList();
        }

        public List<Article> GetAllArticlesOfAuthorByDate(string username, DateTime startdate, DateTime enddate)
        {
            return (from article in _context.Articles 
                    where article.WrittenBy.Equals(username) && article.PostedAt >= startdate && article.PostedAt <= enddate
                    select article).ToList();
        }

        public List<Article> GetTopArticles()
        {
            return _context.Articles.FromSqlRaw(@"
                    SELECT TOP 10 *
                    FROM Articles
                    ORDER BY LikesCount DESC, CommentsCount DESC, BookmarkCount DESC
                ").ToList();
        }

        public List<Article> GetTopArticlesByTopic(int topicId)
        {
             throw new NotImplementedException();
        }
    }
}
