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
    public class LikeRepo : ILikeRepo
    {
        private readonly EasyReadsContext _db;
        public LikeRepo(EasyReadsContext db)
        {
            _db = db;
        }


        public void Create(Like obj)
        {
            _db.Likes.Add(obj);
            _db.SaveChanges();
        }

        public void Delete(Like obj)
        {
            var data = (from like in _db.Likes where like.Username.Equals(obj.Username) && like.ArticleId == obj.ArticleId select like).FirstOrDefault();

            if (data != null)
            {
                _db.Likes.Remove(data);
                _db.SaveChanges();
            }
        }

        public void DeleteAllLikes(int articleId)
        {
            var data = (from like in _db.Likes where like.ArticleId == articleId select like).ToList();
            foreach (var like in data)
            {
                _db.Likes.Remove(like);
            }
            _db.SaveChanges();
        }

        public List<Like> GetAllLikes(int articleId)
        {
            var data = (from like in _db.Likes where like.ArticleId == articleId select like).ToList();

            return data;
        }
    }
}
