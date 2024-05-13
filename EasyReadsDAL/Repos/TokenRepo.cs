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
    public class TokenRepo : IRepo<Token, string>
    {
        private readonly EasyReadsContext _context;

        public TokenRepo(EasyReadsContext context)
        {
            _context = context;
        }

        public void Create(Token obj)
        {
            _context.Tokens.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(string tokenkey)
        {
            var token = (from t in _context.Tokens where t.TokenKey.Equals(tokenkey) select t).FirstOrDefault();
            if(token != null)
            {
                _context.Tokens.Remove(token);
                _context.SaveChanges();
            }
        }

        public Token? Get(string tokenkey)
        {
            var token = (from t in _context.Tokens where t.TokenKey.Equals(tokenkey) select t).FirstOrDefault();
            return token;
        }

        public List<Token> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Token obj)
        {
            throw new NotImplementedException();
        }
    }
}
