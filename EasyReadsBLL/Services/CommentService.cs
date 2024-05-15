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
    public class CommentService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public CommentService(DataAccessFactory dataAccessFactory)
        {
            _dataAccessFactory = dataAccessFactory;
        }

        public void CreateComment(CommentDTO commentDTO)
        {
            Comment comment = new Comment();
            comment.Content = commentDTO.Content;
            comment.ArticleId = commentDTO.ArticleId;
            comment.Username = commentDTO.Username;
            comment.TimeStamp = DateTime.Now;
            _dataAccessFactory.CommentData().CreateComment(comment);
            _dataAccessFactory.ArticleData().IncCommentsCount(comment.ArticleId);
        }

        public CommentDTO? GetComment(int id)
        {
            var data = _dataAccessFactory.CommentData().GetComment(id);
            if(data != null)
            {
                return Convert(data);
            }
            return null;
        }

        public List<CommentDTO> GetAllComments(int articleId)
        {
            var data = _dataAccessFactory.CommentData().GetAllComments(articleId);
            return Convert(data);
        }

        public void UpdateComment(CommentDTO commentDTO)
        {
            Comment comment = new Comment();
            comment.CommentId = commentDTO.CommentId;
            comment.ArticleId = commentDTO.ArticleId;
            comment.Content = commentDTO.Content;
            _dataAccessFactory.CommentData().UpdateComment(comment);
        }

        public void DeleteComment(int id)
        {
            
            var comment = _dataAccessFactory.CommentData().GetComment(id);
            if(comment != null)
            {
                _dataAccessFactory.CommentData().DeleteAllReplies(id);
                _dataAccessFactory.ArticleData().DecCommentsCount(comment.ArticleId);
                _dataAccessFactory.CommentData().DeleteComment(id);
            }

        }

        public void CreateReply(ReplyDTO replyDTO)
        {
            Reply reply = new Reply();
            reply.Content = replyDTO.Content;
            reply.CommentId = replyDTO.CommentId;
            reply.Username = replyDTO.Username;
            reply.TimeStamp = DateTime.Now;
            _dataAccessFactory.CommentData().CreateReply(reply);
        }

        public ReplyDTO? GetReply(int id)
        {
            var data = _dataAccessFactory.CommentData().GetReply(id);
            if (data != null)
            {
                return Convert(data);
            }
            return null;
        }

        public List<ReplyDTO> GetAllReplies(int commentId)
        {
            var data = _dataAccessFactory.CommentData().GetAllReplies(commentId);
            return Convert(data);
        }

        public void UpdateReply(ReplyDTO replyDTO)
        {
            Reply reply = new Reply();
            reply.CommentId = replyDTO.CommentId;
            reply.Username = replyDTO.Username;
            reply.ReplyId = replyDTO.ReplyId;
            reply.Content = replyDTO.Content;
            _dataAccessFactory.CommentData().UpdateReply(reply);
        }

        public void DeleteReply(int id)
        {
            _dataAccessFactory.CommentData().DeleteReply(id);
        }

        public void DeleteAllReplies(int commentId)
        {
            _dataAccessFactory.CommentData().DeleteAllReplies(commentId);
        }

        public List<ReplyDTO> Convert(List<Reply> replies)
        {
            List<ReplyDTO> repliesDTO = new List<ReplyDTO>();
            foreach (var reply in replies)
            {
                repliesDTO.Add(Convert(reply));
            }
            return repliesDTO;
        }

        public ReplyDTO Convert(Reply reply)
        {
            return new ReplyDTO
            {
                ReplyId = reply.ReplyId,
                Content = reply.Content,
                CommentId = reply.CommentId,
                Username = reply.Username,
                TimeStamp = reply.TimeStamp,
            };
        }

        public List<CommentDTO> Convert(List<Comment> comments)
        {
            List<CommentDTO> commentsDTO = new List<CommentDTO>();
            foreach (var comment in comments)
            {
                commentsDTO.Add(Convert(comment));
            }
            return commentsDTO;
        }

        public CommentDTO Convert(Comment comment)
        {
            return new CommentDTO
            {
                CommentId = comment.CommentId,
                Content = comment.Content,
                ArticleId = comment.ArticleId,
                Username = comment.Username,
                TimeStamp = comment.TimeStamp,
            };
        }
    }
}
