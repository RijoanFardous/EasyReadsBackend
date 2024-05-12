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
            return (from article in _context.Articles where article.WrittenBy.Equals(username) && article.Audience.Equals("Public") select article).ToList();
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
    }
}
