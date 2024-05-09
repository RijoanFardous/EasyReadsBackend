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
    public class UserRepo : IUserRepo
    {
        private readonly EasyReadsContext _context;

        public UserRepo(EasyReadsContext context)
        {
            _context = context;
        }

        public void Signup(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool IsUniqueUsername(string username)
        {
            var user = _context.Users.Find(username);
            if(user == null)
            {
                return true;
            }
            return false;
        }

        public bool IsUniqueEmail(string email)
        {
            var user = (from u in _context.Users where u.Email.Equals(email) select u).FirstOrDefault();
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUser(string username)
        {
            return _context.Users.Find(username);
        }

        public void UpdateFullName(string username, string fullname)
        {
            var user = GetUser(username);
            if (user != null)
            {
                user.FullName = fullname;
                _context.SaveChanges();
            }
        }

        public void ChangePass(string username, string password)
        {
            var user = _context.Users.Find(username);
            user.HashedPassword = password;
            _context.SaveChanges();
        }
    }
}
