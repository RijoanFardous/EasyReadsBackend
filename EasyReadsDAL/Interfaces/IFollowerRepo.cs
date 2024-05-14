using EasyReadsDAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.Interfaces
{
    public interface IFollowerRepo
    {
        void Create(Follower obj);
        void Update(Follower obj);
        void Delete(Follower obj);
        Follower? Get(int id);
        List<Follower> GetAllFollowers(string username);
        List<Follower> GetAllFollowings(string username);
        void DeleteAllFollowers(string username);
        void DeleteAllFollowings(string username);
        bool IsFollowing(Follower obj);
    }
}
