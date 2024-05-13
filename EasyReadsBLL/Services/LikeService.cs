using EasyReadsBLL.DTOs;
using EasyReadsDAL.EF.Entities;
using EasyReadsDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.Services
{
    public class LikeService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public LikeService(DataAccessFactory dataAccessFactory)
        {
            _dataAccessFactory = dataAccessFactory;
        }

        public void CreateLike(LikeDTO data)
        {
            Like like = Convert(data);
            like.LikedAt = DateTime.Now;
            _dataAccessFactory.LikeData().Create(like);
        }

        public void DeleteLike(LikeDTO data)
        {
            Like like = Convert(data);
            _dataAccessFactory.LikeData().Delete(like); ;
        }

        public List<LikeDTO> GetAllLikes(int articleId)
        {
            var data = _dataAccessFactory.LikeData().GetAllLikes(articleId);
            return Convert(data);
        }


        public Like Convert(LikeDTO data)
        {
            Like like = new Like();
            like.ArticleId = data.ArticleId;
            like.Username = data.Username;

            return like;
        }

        public List<LikeDTO> Convert(List<Like> data)
        {
            List<LikeDTO> likes = new List<LikeDTO>();
            foreach (var like in data)
            {
                likes.Add(Convert(like));
            }
            return likes;
        }

        public LikeDTO Convert(Like data)
        {
            LikeDTO like = new LikeDTO();
            like.LikeId = data.LikeId;
            like.ArticleId = data.ArticleId;
            like.Username = data.Username;
            like.LikedAt = data.LikedAt;
            return like;
        }
    }
}
