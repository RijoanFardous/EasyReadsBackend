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
            _dataAccessFactory.ArticleData().CreateArticle(article);
        }

        public void RemoveArticle(int id)
        {

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
    }
}
