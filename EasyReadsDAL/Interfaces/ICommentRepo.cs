using EasyReadsDAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.Interfaces
{
    public interface ICommentRepo
    {
        // Comments
        public void CreateComment(Comment comment);
        public void DeleteComment(int id);
        public void UpdateComment(Comment comment);
        public Comment? GetComment(int id);
        public List<Comment> GetAllComments(int articleId);

        // Replies
        public void CreateReply(Reply reply);
        public void DeleteReply(int id);
        public void DeleteAllReplies(int commentId);
        public void UpdateReply(Reply reply);
        public Reply? GetReply(int id);
        public List<Reply> GetAllReplies(int commentId);
    }
}
