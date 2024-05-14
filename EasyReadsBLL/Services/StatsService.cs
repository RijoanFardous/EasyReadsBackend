using EasyReadsBLL.DTOs;
using EasyReadsBLL.Models;
using EasyReadsDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.Services
{
    public class StatsService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        private readonly ArticleService _articleService;
        public StatsService(DataAccessFactory dataAccessFactory, ArticleService articleService)
        {
            _dataAccessFactory = dataAccessFactory;
            _articleService = articleService;
        }

        public AuthorStats GetAuthorStats(string username, DateTime? startdate, DateTime? enddate)
        {
            AuthorStats stats = new AuthorStats();
            stats.Username = username;
            if(startdate == null)
            {
                stats.StartDate = DateTime.Now.AddDays(-6);
            }
            if(enddate == null)
            {
                stats.EndDate = DateTime.Now;
            }

            stats.ArticlePosted = _dataAccessFactory.ArticleData().GetAllArticlesOfAuthorByDate(username, stats.StartDate, stats.EndDate).Count();
            stats.FollowerGained = _dataAccessFactory.FollowerData().GetAllFollowersByDate(username, stats.StartDate, stats.EndDate).Count();

            var articles = _dataAccessFactory.ArticleData().GetAllArticlesOfAuthor(username);
            foreach(var article in articles)
            {
                stats.BookmarkReceived += _dataAccessFactory.BookmarkData().GetArticleBookmarksByDate(article.ArticleId, stats.StartDate, stats.EndDate).Count();
                stats.CommentsReceived += _dataAccessFactory.CommentData().GetAllCommentsByDate(article.ArticleId, stats.StartDate, stats.EndDate).Count();
                stats.LikesReceived += _dataAccessFactory.LikeData().GetAllLikesByDate(article.ArticleId, stats.StartDate, stats.EndDate).Count();
            }

            stats.TopArticles = _articleService.Convert(articles.Take(5).ToList());

            return stats;
        }

        public List<ArticleDTO> GetTopArticles()
        {
            var data = _dataAccessFactory.ArticleData().GetTopArticles();
            return _articleService.Convert(data);
        }
    }
}
