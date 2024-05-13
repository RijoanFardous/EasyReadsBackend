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
    public class FollowerService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public FollowerService(DataAccessFactory dataAccessFactory)
        {
            _dataAccessFactory = dataAccessFactory;
        }

        public void CreateFollower(FollowerDTO data)
        {
            Follower follower = Convert(data);
            follower.FollowedAt = DateTime.Now;
            _dataAccessFactory.FollowerData().Create(follower);
        }

        public void DeleteFollower(FollowerDTO data)
        {
            Follower follower = Convert(data);
            _dataAccessFactory.FollowerData().Delete(follower);
        }

        public List<FollowerDTO> GetAllFollowers(string username)
        {
            var data =  _dataAccessFactory.FollowerData().GetAllFollowers(username);
            return Convert(data);
        }

        public List<FollowerDTO> GetAllFollowings(string username)
        {
            var data = _dataAccessFactory.FollowerData().GetAllFollowings(username);
            return Convert(data);
        }

        public bool IsFollowing(FollowerDTO data)
        {
            Follower follower = Convert(data);
            return _dataAccessFactory.FollowerData().IsFollowing(follower);
        }


        public Follower Convert(FollowerDTO data)
        {
            Follower follower = new Follower();
            follower.FollowerUsername = data.FollowerUsername;
            follower.FollowedUsername = data.FollowedUsername;

            return follower;
        }

        public List<FollowerDTO> Convert(List<Follower> data)
        {
            List<FollowerDTO> followers = new List<FollowerDTO>();
            foreach (var follower in data)
            {
                followers.Add(Convert(follower));
            }
            return followers;
        }

        public FollowerDTO Convert(Follower data)
        {
            FollowerDTO follower = new FollowerDTO();
            follower.FollowerUsername = data.FollowerUsername;
            follower.FollowedUsername = data.FollowedUsername;
            follower.FollowedAt = data.FollowedAt;

            return follower;
        }
    }
}
