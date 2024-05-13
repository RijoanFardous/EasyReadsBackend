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
    public class FollowerRepo : IFollowerRepo
    {
        private readonly EasyReadsContext _db;
        public FollowerRepo(EasyReadsContext db)
        {
            _db = db;
        }


        public void Create(Follower obj)
        {
            _db.Followers.Add(obj);
            _db.SaveChanges();
        }

        public void Delete(Follower obj)
        {
            var data = (from f in _db.Followers where f.FollowedUsername.Equals(obj.FollowedUsername) && f.FollowerUsername.Equals(obj.FollowerUsername) select f).FirstOrDefault();

            if (data != null)
            {
                _db.Followers.Remove(data);
                _db.SaveChanges();
            }
        }

        public Follower? Get(int id)
        {
            return _db.Followers.Find(id);
        }

        public List<Follower> GetAllFollowers(string username)
        {
            var data = (from f in _db.Followers where f.FollowedUsername.Equals(username) select f).ToList();
            return data;
        }

        public List<Follower> GetAllFollowings(string username)
        {
            var data = (from f in _db.Followers where f.FollowerUsername.Equals(username) select f).ToList();
            return data;
        }

        public bool IsFollowing(Follower obj)
        {
            var data = (from f in _db.Followers where f.FollowedUsername.Equals(obj.FollowedUsername) && f.FollowerUsername.Equals(obj.FollowerUsername) select f).FirstOrDefault();

            if (data != null)
            {
                return true;
            }
            return false;
        }

        public void Update(Follower obj)
        {
            throw new NotImplementedException();
        }
    }
}
