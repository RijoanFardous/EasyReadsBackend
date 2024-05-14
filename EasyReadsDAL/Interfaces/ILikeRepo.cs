using EasyReadsDAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.Interfaces
{
    public interface ILikeRepo
    {
        void Create(Like obj);
        void Delete(Like obj);
        List<Like> GetAllLikes(int articleId);
        List<Like> GetAllLikesByDate(int articleId, DateTime startdate, DateTime enddate);
        void DeleteAllLikes(int articleId);
    }
}
