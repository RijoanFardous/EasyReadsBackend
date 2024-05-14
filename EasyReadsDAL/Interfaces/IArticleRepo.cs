using EasyReadsDAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.Interfaces
{
    public interface IArticleRepo
    {
        void CreateArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(int id);
        Article? GetArticle(int id);
        List<Article> GetAllArticles();
        List<Article> GetAllPublicArticles();
        List<Article> GetTopArticles();
        List<Article> GetTopArticlesByTopic(int topicId);
        List<Article> GetAllArticlesOfAuthor(string username);
        List<Article> GetAllArticlesOfAuthorByDate(string username, DateTime startdate, DateTime enddate);
        List<Article> GetAllArticlesOfTopic(int topicId);
        List<Article> GetPublicArticlesofAuthor(string username);
        List<Article> GetFollowersOnlyArticlesOfAuthor(string username);

        void IncLikesCount(int id);
        void DecLikesCount(int id);
        void IncCommentsCount(int id);
        void DecCommentsCount(int id);
        void IncBookmarkCount(int id);
        void DecBookmarkCount(int id);

        void CreateArticleVersion(ArticleVersion version);
        void DeleteArticleVersion(int id);
        ArticleVersion? GetArticleVersion(int id);
        List<ArticleVersion> GetAllArticleVersions(int articleId);
        void DeleteAllVersions(int articleId);
    }
}
