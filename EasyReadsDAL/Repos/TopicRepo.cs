using System;
using EasyReadsDAL.EF;
using EasyReadsDAL.EF.Entities;
using EasyReadsDAL.Interfaces;

namespace EasyReadsDAL.Repos
{
    public class TopicRepo : IRepo<Topic, int>
    {
        private readonly EasyReadsContext _db;
        public  TopicRepo(EasyReadsContext db)
        {
           _db = db;

        }
        public void Create(Topic obj)
        {
            _db.Topics.Add(obj);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
           var topic = _db.Topics.Find(id);
            _db.Topics.Remove(topic);
            _db.SaveChanges();

        }

        public Topic? Get(int id)
        {
            return _db.Topics.Find(id);
        }

        public List<Topic> GetAll()
        {
            return _db.Topics.ToList();
        }

        public void Update(Topic obj)
        {
            var topic = _db.Topics.Find(obj.TopicId);
            topic.TopicName = obj.TopicName;
            topic.FollowersCount = obj.FollowersCount;
            _db.SaveChanges();
        }
    }
}

