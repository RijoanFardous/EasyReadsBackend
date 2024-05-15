using EasyReadsDAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.Interfaces
{
    public interface ITopicRepo
    {
        public void Create(Topic topic);
        public void Update(Topic topic);
        public void Delete(int id);
        public Topic? Get(int id);
        public List<Topic> GetAll();
        public void AddFollowerCount(int id);
        public void DecFollowerCount(int id);

        public void AddUserTopic(UserTopic userTopic);
        public void RemoveUserTopic(UserTopic userTopic);
        public List<UserTopic> UserTopicsByDate(int topicId, DateTime startdate, DateTime enddate);
    }
}
