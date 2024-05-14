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
            if (article != null)
            {
                _context.Articles.Remove(article);
                _context.SaveChanges();
            }
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
            var articles = (from article in _context.Articles
                            where article.TopicId == topicId && article.Audience.Equals("Public")
                            select article).ToList();

            return articles;
        }

        public Article? GetArticle(int id)
        {
            var article = _context.Articles.Find(id);
            return article;
        }

        public List<Article> GetFollowersOnlyArticlesOfAuthor(string username)
        {
            var articles = (from article in _context.Articles
                            where article.WrittenBy.Equals(username) && article.Audience.Equals("Public") || article.Audience.Equals("Followers")
                            select article).ToList();

            return articles;
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
            var article = _context.Articles.Find(id);
            if(article != null)
            {
                article.BookmarksCount++;
            }
            _context.SaveChanges();
        }

        public void IncCommentsCount(int id)
        {
            var article = _context.Articles.Find(id);
            if (article != null)
            {
                article.CommentsCount++;
            }
            _context.SaveChanges();
        }

        public void IncLikesCount(int id)
        {
            var article = _context.Articles.Find(id);
            if (article != null)
            {
                article.LikesCount++;
            }
            _context.SaveChanges();
        }

        public void DecBookmarkCount(int id)
        {
            var article = _context.Articles.Find(id);
            if (article != null)
            {
                article.BookmarksCount--;
            }
            _context.SaveChanges();
        }

        public void DecCommentsCount(int id)
        {
            var article = _context.Articles.Find(id);
            if (article != null)
            {
                article.CommentsCount--;
            }
            _context.SaveChanges();
        }

        public void DecLikesCount(int id)
        {
            var article = _context.Articles.Find(id);
            if (article != null)
            {
                article.LikesCount--;
            }
            _context.SaveChanges();
        }


        public void UpdateArticle(Article article)
        {
            var data = _context.Articles.Find(article.ArticleId);
            if(data != null)
            {
                data.Title = article.Title;
                data.Content = article.Content;
                data.NumberOfWords = article.NumberOfWords;
                data.ModifiedAt = article.ModifiedAt;
                _context.SaveChanges();
            }
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
                    ORDER BY LikesCount DESC, CommentsCount DESC, BookmarksCount DESC
                ").ToList();
        }

        public List<Article> GetTopArticlesByTopic(int topicId)
        {
            return _context.Articles.FromSqlRaw(@"
                    SELECT TOP 10 *
                    FROM Articles WHERE opicId = {0}
                    ORDER BY LikesCount DESC, CommentsCount DESC, BookmarksCount DESC
                ", topicId).ToList();
        }

        public void CreateArticleVersion(ArticleVersion version)
        {
            _context.ArticleVersions.Add(version);
            _context.SaveChanges();
        }

        public void DeleteArticleVersion(int id)
        {
            var data = _context.ArticleVersions.Find(id);
            if (data != null)
            {
                _context.ArticleVersions.Remove(data);
                _context.SaveChanges();
            }
        }

        public ArticleVersion? GetArticleVersion(int id)
        {
            return _context.ArticleVersions.Find(id);
        }

        public List<ArticleVersion> GetAllArticleVersions(int articleId)
        {
            var data = (from ar in _context.ArticleVersions where ar.ArticleId == articleId select ar).ToList();
            return data;
        }

        public void DeleteAllVersions(int articleId)
        {
            var data = GetAllArticleVersions(articleId);
            foreach (var version in data)
            {
                _context.ArticleVersions.Remove(version);
            }
            _context.SaveChanges();
        }
    }
}
