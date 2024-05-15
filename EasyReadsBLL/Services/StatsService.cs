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

        public AuthorStats GetAuthorStats(AuthorStats stats)
        {
            stats.ArticlePosted = _dataAccessFactory.ArticleData().GetAllArticlesOfAuthorByDate(stats.Username, stats.StartDate, stats.EndDate).Count();
            stats.FollowerGained = _dataAccessFactory.FollowerData().GetAllFollowersByDate(stats.Username, stats.StartDate, stats.EndDate).Count();

            var articles = _dataAccessFactory.ArticleData().GetAllArticlesOfAuthor(stats.Username);
            foreach(var article in articles)
            {
                stats.BookmarkReceived += _dataAccessFactory.BookmarkData().GetArticleBookmarksByDate(article.ArticleId, stats.StartDate, stats.EndDate).Count();
                stats.CommentsReceived += _dataAccessFactory.CommentData().GetAllCommentsByDate(article.ArticleId, stats.StartDate, stats.EndDate).Count();
                stats.LikesReceived += _dataAccessFactory.LikeData().GetAllLikesByDate(article.ArticleId, stats.StartDate, stats.EndDate).Count();
            }

            stats.TopArticles = _articleService.Convert(articles.Take(5).ToList());

            return stats;
        }

        public TopicStats GetTopicStats(TopicStats stats)
        {
            stats.ArticlePosted = _dataAccessFactory.ArticleData().GetAllArticlesOfTopicByDate(stats.TopicId, stats.StartDate, stats.EndDate).Count();
            stats.FollowerGained = _dataAccessFactory.TopicData().UserTopicsByDate(stats.TopicId, stats.StartDate, stats.EndDate).Count();

            var articles = _dataAccessFactory.ArticleData().GetTopArticlesByTopic(stats.TopicId);
            foreach (var article in articles)
            {
                stats.BookmarkReceived += _dataAccessFactory.BookmarkData().GetArticleBookmarksByDate(article.ArticleId, stats.StartDate, stats.EndDate).Count();
                stats.CommentsReceived += _dataAccessFactory.CommentData().GetAllCommentsByDate(article.ArticleId, stats.StartDate, stats.EndDate).Count();
                stats.LikesReceived += _dataAccessFactory.LikeData().GetAllLikesByDate(article.ArticleId, stats.StartDate, stats.EndDate).Count();
            }

            stats.TopArticles = _articleService.Convert(articles.Take(5).ToList());

            return stats;
        }

        public BasicStats GetBasicStats()
        {
            BasicStats stats = new BasicStats();
            stats.TotalUsers = _dataAccessFactory.UserData().GetAllUsers().Count();
            stats.TotalAuthors = _dataAccessFactory.UserData().GetAllAuthors().Count();
            stats.UsersJoinedToday = _dataAccessFactory.UserData().JoinedToday().Count();
            stats.TotalArticlesPosted = _dataAccessFactory.ArticleData().GetAllArticles().Count();
            stats.TotalArticlesPosted = _dataAccessFactory.ArticleData().GetAllArticlesOfToday().Count();

            return stats;
        }

        public List<ArticleDTO> GetTopArticles()
        {
            var data = _dataAccessFactory.ArticleData().GetTopArticles();
            return _articleService.Convert(data);
        }
    }
}
