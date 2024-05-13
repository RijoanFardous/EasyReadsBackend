using EasyReadsDAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.Interfaces
{
    public interface IUserRepo
    {
        List<User> GetAllUsers();
        User? GetUser(string username);
        void Signup(User user);
        bool IsUniqueUsername(string username);
        bool IsUniqueEmail(string email);
        void ChangePass(string username, string password);
        void UpdateFullName(string username, string fullname);
    }
}
