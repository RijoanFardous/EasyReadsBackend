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
    public class SearchService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        private readonly UserService _userService;
        private readonly ArticleService _articleService;
        public SearchService(DataAccessFactory dataAccessFactory, UserService userService, ArticleService articleService)
        {
            _dataAccessFactory = dataAccessFactory;
            _userService = userService;
            _articleService = articleService;
        }

        public List<UserDTO> SearchUsers(string keyword)
        {
            List<User> users = _dataAccessFactory.UserData().GetAllUsers();
            List<UserDTO> matchedUsers = new List<UserDTO>();

            foreach (var user in users)
            {
                if (user.Username.Contains(keyword))
                {
                    var data = _userService.Convert(user);
                    matchedUsers.Add(data);
                }
            }
            return matchedUsers;
        }

        public List<ArticleDTO> SearchArticles(string keyword)
        {
            List<Article> articles = _dataAccessFactory.ArticleData().GetAllPublicArticles();
            List<ArticleDTO> matchedArticles = new List<ArticleDTO>();

            foreach (var article in articles)
            {
                if (article.Title.Contains(keyword))
                {
                    var data = _articleService.Convert(article);
                    matchedArticles.Add(data);
                }
            }
            return matchedArticles;
        }
    }
}
