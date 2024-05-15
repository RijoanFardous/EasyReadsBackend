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

        public void MemberToAuthor(string username)
        {
            var user = GetUser(username);
            if (user != null)
            {
                user.UserType = "Author";
                _context.SaveChanges();
            }
        }

        public List<User> GetAllAuthors()
        {
            var data = (from u in _context.Users where u.UserType.Equals("Author") select u).ToList();
            return data;
        }

        public List<User> JoinedToday()
        {
            var data = (from u in _context.Users where u.JoinDate <= DateOnly.FromDateTime(DateTime.Today) && u.JoinDate >= DateOnly.FromDateTime(DateTime.Today.AddDays(-1)) select u).ToList();
            return data;
        }
    }
}
