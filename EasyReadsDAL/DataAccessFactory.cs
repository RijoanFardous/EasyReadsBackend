using EasyReadsDAL.EF;
using EasyReadsDAL.EF.Entities;
using EasyReadsDAL.Interfaces;
using EasyReadsDAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL
{
    public class DataAccessFactory
    {
        private readonly EasyReadsContext _context;

        public DataAccessFactory(EasyReadsContext context)
        {
            _context = context;
        }

        public IUserRepo UserData()
        {
            return new UserRepo(_context);
        }

        public IProfileRepo ProfileData()
        {
            return new ProfileRepo(_context);
        }

        public IRepo<Token, string> TokenData()
        {
            return new TokenRepo(_context);
        }

        public IArticleRepo ArticleData()
        {
            return new ArticleRepo(_context);
        }

        public IRepo<Topic,int> TopicData()
        {
            return new TopicRepo(_context);
        }
    }
}
