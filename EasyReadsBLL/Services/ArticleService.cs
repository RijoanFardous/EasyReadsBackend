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
    }
}
