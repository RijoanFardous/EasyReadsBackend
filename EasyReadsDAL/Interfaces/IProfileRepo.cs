using EasyReadsDAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsDAL.Interfaces
{
    public interface IProfileRepo
    {
        public void Create(Profile profile);
        public Profile? GetProfile(string username);
        public void Update(Profile profile);
        public void UpdatePicture(string username, string plink);
        public void Delete(string username);
        public void IncFollowerCount(string username);
        public void DecFollowerCount(string username);
        public void IncFollowingCount(string username);
        public void DecFollowingCount(string username);
    }
}
