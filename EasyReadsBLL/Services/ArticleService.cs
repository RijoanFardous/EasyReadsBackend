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
    public class ArticleService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public ArticleService(DataAccessFactory dataAccessFactory)
        {
            _dataAccessFactory = dataAccessFactory;
        }

        public void CreateArticle(ArticleDTO articleDTO)
        {
            Article article = new Article();
            article.Title = articleDTO.Title;
            article.Content = articleDTO.Content;
            article.WrittenBy = articleDTO.WrittenBy;
            article.TopicId = articleDTO.TopicId;
            
            if(articleDTO.Audience.Equals("Public") || articleDTO.Audience.Equals("Followers"))
            {
                article.Audience = articleDTO.Audience;
            }
            else
            {
                article.Audience = "Private";
            }

            string[] words = articleDTO.Content.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            article.NumberOfWords = words.Length;
            article.PostedAt = DateTime.Now;
            _dataAccessFactory.ArticleData().CreateArticle(article);
        }

        public ArticleDTO? GetArticle(int id, string tokenkey)
        {
            var article = _dataAccessFactory.ArticleData().GetArticle(id);

            if(article == null)
            {
                return null;
            }

            if (article.Audience.Equals("Public"))
            {
                return Convert(article);
            }

            var token = _dataAccessFactory.TokenData().Get(tokenkey);
            if (token != null)
            {
                if (token.Username.Equals(article.WrittenBy))
                {
                    return Convert(article);
                }

                if (article.Audience.Equals("Followers"))
                {
                    var obj = new Follower();
                    obj.FollowerUsername = token.Username;
                    obj.FollowedUsername = article.WrittenBy;
                    if (_dataAccessFactory.FollowerData().IsFollowing(obj))
                    {
                        return Convert(article);
                    }
                }
            }
            return new ArticleDTO();
        }

        public List<ArticleDTO> GetAllPublicArticles()
        {
            var data = _dataAccessFactory.ArticleData().GetAllPublicArticles();
            return Convert(data);
        }

        public List<ArticleDTO> GetAllPublicArticlesByUser(string username)
        {
            var data = _dataAccessFactory.ArticleData().GetPublicArticlesofAuthor(username);
            return Convert(data);
        }
        
        public List<ArticleDTO> GetAllFollowerArticlesByUser(string username)
        {
            var data = _dataAccessFactory.ArticleData().GetFollowersOnlyArticlesOfAuthor(username);
            return Convert(data);
        }

        public List<ArticleDTO> GetAllArticlesByUser(string username)
        {
            var data = _dataAccessFactory.ArticleData().GetAllArticlesOfAuthor(username);
            return Convert(data);
        }

        public List<ArticleDTO> GetAllArticlesByTopicId(int topicId)
        {
            var data = _dataAccessFactory.ArticleData().GetAllArticlesOfTopic(topicId);
            return Convert(data);
        }

        public void RemoveArticle(int id)
        {
            _dataAccessFactory.BookmarkData().DeleteAllByArticle(id);
            _dataAccessFactory.LikeData().DeleteAllLikes(id);
            _dataAccessFactory.CommentData().DeleteAllComments(id);
            _dataAccessFactory.ArticleData().DeleteAllVersions(id);
            _dataAccessFactory.ArticleData().DeleteArticle(id);
        }

        public void UpdateArticle(ArticleDTO newversion)
        {
            var article = _dataAccessFactory.ArticleData().GetArticle(newversion.ArticleId);
            if(article != null)
            {
                ArticleVersion version = new ArticleVersion();
                version.Title = article.Title;
                version.Content = article.Content;
                version.NumberOfWords = article.NumberOfWords;
                version.ModifiedAt = DateTime.Now;
                version.ArticleId = article.ArticleId;

                _dataAccessFactory.ArticleData().CreateArticleVersion(version);

                article.Title = newversion.Title;
                article.Content = newversion.Content;
                article.ModifiedAt = DateTime.Now;
                string[] words = newversion.Content.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                article.NumberOfWords = words.Length;
                _dataAccessFactory.ArticleData().UpdateArticle(article);
            }
        }

        public ArticleVersionDTO? GetArticleVersion(int id)
        {
            var data = _dataAccessFactory.ArticleData().GetArticleVersion(id);
            if(data != null)
            {
                return Convert(data);
            }
            return null;
        }

        public List<ArticleVersionDTO> GetAllArticleVersion(int articleId)
        {
            var data = _dataAccessFactory.ArticleData().GetAllArticleVersions(articleId);
            return Convert(data);
        }

        public void RestoreVersion(int id)
        {
            var data = _dataAccessFactory.ArticleData().GetArticleVersion(id);
            if(data != null)
            {
                var article = _dataAccessFactory.ArticleData().GetArticle(data.ArticleId);

                ArticleVersion version = new ArticleVersion();
                version.Title = article.Title;
                version.Content = article.Content;
                version.NumberOfWords = article.NumberOfWords;
                version.ModifiedAt = DateTime.Now;
                version.ArticleId = article.ArticleId;

                _dataAccessFactory.ArticleData().CreateArticleVersion(version);

                article.Title = data.Title;
                article.Content = data.Content;
                article.ModifiedAt = DateTime.Now;
                article.NumberOfWords = data.NumberOfWords;
                _dataAccessFactory.ArticleData().UpdateArticle(article);
            }
        }

        public List<ArticleDTO> Convert(List<Article> articles)
        {
            var data = new List<ArticleDTO>();
            foreach (var article in articles)
            {
                data.Add(Convert(article));
            }
            return data;
        }

        public ArticleDTO Convert(Article article)
        {
            return new ArticleDTO
            {
                ArticleId = article.ArticleId,
                Title = article.Title,
                Content = article.Content,
                WrittenBy = article.WrittenBy,
                TopicId = article.TopicId,
                Audience = article.Audience,
                CoverImage = article.CoverImage,
                LikesCount = article.LikesCount,
                CommentsCount = article.CommentsCount,
                BookmarksCount = article.BookmarksCount,
                NumberOfWords = article.NumberOfWords,
                PostedAt = article.PostedAt,
                ModifiedAt = article.ModifiedAt,
            };
        }

        public List<ArticleVersionDTO> Convert(List<ArticleVersion> versions)
        {
            var data = new List<ArticleVersionDTO>();
            foreach (var version in versions)
            {
                data.Add(Convert(version));
            }
            return data;
        }

        public ArticleVersionDTO Convert(ArticleVersion article)
        {
            return new ArticleVersionDTO
            {
                VersionId = article.VersionId,
                ArticleId = article.ArticleId,
                Title = article.Title,
                Content = article.Content,
                NumberOfWords = article.NumberOfWords,
                ModifiedAt = article.ModifiedAt,
            };
        }
    }
}
