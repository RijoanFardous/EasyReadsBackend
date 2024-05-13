using System;
using EasyReadsBLL.DTOs;
using EasyReadsDAL;
using EasyReadsDAL.EF.Entities;

namespace EasyReadsBLL.Services
{
	public class TopicService
	{
		private readonly DataAccessFactory _dataAccessFactory;

		public TopicService(DataAccessFactory dataAccessFactory)
		{
			_dataAccessFactory = dataAccessFactory;
		}

        public void Create(TopicDTO topic)
		{
			Topic topic1 = new Topic();
			topic1.TopicName = topic.TopicName;
			topic1.AddDate = DateTime.Now;

			_dataAccessFactory.TopicData().Create(topic1);
        }

		public List<TopicDTO> GetAllTopic()
		{

			var alltopic =_dataAccessFactory.TopicData().GetAll();
            var alltopicDTO = Convert(alltopic);

            return alltopicDTO;

		}

        public TopicDTO? GetTopic(int id)
        {
            var singleTopic = _dataAccessFactory.TopicData().Get(id);
           if(singleTopic != null)
            {
                var singleTopicDTO = Convert(singleTopic);
                return singleTopicDTO;
            }
            else
            {
                return null;
            }
        }

        public void UpdateTopic(TopicDTO topic)
        {
           var singleTopic = _dataAccessFactory.TopicData().Get(topic.TopicId);
            if(singleTopic != null)
            {
                singleTopic.TopicName = topic.TopicName;
                _dataAccessFactory.TopicData().Update(singleTopic);
            }
           
        }

        public void FollowTopic(UserTopicDTO userTopicDTO)
        {
            UserTopic userTopic = new UserTopic();
            userTopic.TopicId = userTopicDTO.TopicId;
            userTopic.Username = userTopicDTO.Username;
            userTopic.TimeStamp = DateTime.Now;
            _dataAccessFactory.TopicData().AddUserTopic(userTopic);
            _dataAccessFactory.TopicData().AddFollowerCount(userTopicDTO.TopicId);
        }

        public void UnFollowTopic(UserTopicDTO userTopicDTO)
        {
            UserTopic userTopic = new UserTopic();
            userTopic.TopicId = userTopicDTO.TopicId;
            userTopic.Username = userTopicDTO.Username;
            _dataAccessFactory.TopicData().RemoveUserTopic(userTopic);
            _dataAccessFactory.TopicData().DecFollowerCount(userTopicDTO.TopicId);
        }

        public List<TopicDTO> Convert(List<Topic> topics)
        {
            List<TopicDTO> topicsDTO = new List<TopicDTO>();
            foreach (Topic topic in topics)
            {
                topicsDTO.Add(Convert(topic));
            }
            return topicsDTO;
        }

        public TopicDTO Convert(Topic topic)
        {
            return new TopicDTO
            {
                TopicId = topic.TopicId,
                TopicName = topic.TopicName,
                FollowersCount = topic.FollowersCount,
                AddDate = topic.AddDate,
               
            };
        }
    }
}

