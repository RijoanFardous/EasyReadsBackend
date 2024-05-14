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
    public class CommentRepo : ICommentRepo
    {
        private readonly EasyReadsContext _db;
        public CommentRepo(EasyReadsContext db)
        {
            _db = db;
        }
        public void CreateComment(Comment comment)
        {
            _db.Comments.Add(comment);
            _db.SaveChanges();
        }

        public void CreateReply(Reply reply)
        {
            _db.Replies.Add(reply);
            _db.SaveChanges();
        }

        public void DeleteAllReplies(int commentId)
        {
            var replies = GetAllReplies(commentId);
            foreach(var reply in replies)
            {
                _db.Replies.Remove(reply);
            }
            _db.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            var data = _db.Comments.Find(id);
            if(data != null)
            {
                _db.Comments.Remove(data);
                _db.SaveChanges();
            }
        }

        public void DeleteReply(int id)
        {
            var data = _db.Replies.Find(id);
            if (data != null)
            {
                _db.Replies.Remove(data);
                _db.SaveChanges();
            }
        }

        public List<Comment> GetAllComments(int articleId)
        {
            var data = (from comment in _db.Comments where comment.ArticleId == articleId select comment).ToList();
            return data;
        }

        public List<Comment> GetAllCommentsByDate(int articleId, DateTime startdate, DateTime enddate)
        {
            var data = (from comment in _db.Comments 
                        where comment.ArticleId == articleId && comment.TimeStamp >= startdate && comment.TimeStamp <= enddate
                        select comment).ToList();
            return data;
        }

        public List<Reply> GetAllReplies(int commentId)
        {
            var data = (from reply in _db.Replies where reply.CommentId == commentId select reply).ToList();
            return data;
        }

        public Comment? GetComment(int id)
        {
            return _db.Comments.Find(id);
        }

        public Reply? GetReply(int id)
        {
            return _db.Replies.Find(id);
        }

        public void UpdateComment(Comment comment)
        {
            var data = _db.Comments.Find(comment.CommentId);
            if(data != null)
            {
                data.Content = comment.Content;
                _db.SaveChanges();
            }
        }

        public void UpdateReply(Reply reply)
        {
            var data = _db.Replies.Find(reply.ReplyId);
            if (data != null)
            {
                data.Content = reply.Content;
                _db.SaveChanges();
            }
        }
    }
}
