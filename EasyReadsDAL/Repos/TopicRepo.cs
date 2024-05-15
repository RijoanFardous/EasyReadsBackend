using System;
using EasyReadsDAL.EF;
using EasyReadsDAL.EF.Entities;
using EasyReadsDAL.Interfaces;

namespace EasyReadsDAL.Repos
{
    public class TopicRepo : ITopicRepo
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

        public Topic? Get(int id)
        {
            return _db.Topics.Find(id);
        }

        public List<Topic> GetAll()
        {
            return _db.Topics.ToList();
        }

        public void Delete(int id)
        {
            var topic = _db.Topics.Find(id);
            _db.Topics.Remove(topic);
            _db.SaveChanges();

        }

        public void Update(Topic obj)
        {
            var topic = _db.Topics.Find(obj.TopicId);
            topic.TopicName = obj.TopicName;
            _db.SaveChanges();
        }

        public void AddFollowerCount(int id)
        {
            var topic = _db.Topics.Find(id);
            if(topic != null)
            {
                topic.FollowersCount = topic.FollowersCount + 1;
                _db.SaveChanges();
            }
        }


        public void DecFollowerCount(int id)
        {
            var topic = _db.Topics.Find(id);
            if (topic != null)
            {
                topic.FollowersCount = topic.FollowersCount - 1;
                _db.SaveChanges();
            }
        }

        public void AddUserTopic(UserTopic obj)
        {
            var topic = (from usertopic in _db.UserTopics where usertopic.TopicId == obj.TopicId && usertopic.Username.Equals(obj.Username) select usertopic).FirstOrDefault();
            if(topic == null)
            {
                _db.UserTopics.Add(obj);
                _db.SaveChanges();
            }
        }

        public void RemoveUserTopic(UserTopic userTopic)
        {
            var userTopic1 = (from ut in _db.UserTopics where ut.TopicId == userTopic.TopicId && ut.Username.Equals(userTopic.Username) select ut).FirstOrDefault();
            if(userTopic1 != null)
            {
                _db.UserTopics.Remove(userTopic1);
                _db.SaveChanges();
            }
        }

        public List<UserTopic> UserTopicsByDate(int topicId, DateTime startdate, DateTime enddate)
        {
            var data = (from ut in _db.UserTopics where ut.TopicId == topicId && ut.TimeStamp >= startdate && ut.TimeStamp <= enddate select ut).ToList();
            return data;
        }
    }
}

