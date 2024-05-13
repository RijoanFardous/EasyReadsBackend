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
    public class ProfileRepo : IProfileRepo
    {
        private readonly EasyReadsContext _context;
        public ProfileRepo(EasyReadsContext context)
        {
            _context = context;
        }

        public void Create(Profile profile)
        {
            _context.Profiles.Add(profile);
            _context.SaveChanges();
        }

        public void Delete(string username)
        {
            var profile = GetProfile(username);
            if (profile != null)
            {
                _context.Profiles.Remove(profile);
                _context.SaveChanges();
            }
        }

        public Profile? GetProfile(string username)
        {
            var profile = (from p in _context.Profiles where p.Username.Equals(username) select p).FirstOrDefault();
            return profile;
        }


        public void Update(Profile profile)
        {
            var data = GetProfile(profile.Username);
            data.Bio = profile.Bio;
            data.Address = profile.Address;
            data.Website = profile.Website;
            _context.SaveChanges();
        }

        public void UpdatePicture(string username, string plink)
        {
            var profile = GetProfile(username);
            profile.ProfilePicture = plink;
            _context.SaveChanges();
        }

        public void IncFollowerCount(string username)
        {
            var profile = GetProfile(username);
            if(profile != null)
            {
                profile.FollowersCount++;
                _context.SaveChanges();
            }
        }

        public void IncFollowingCount(string username)
        {
            var profile = GetProfile(username);
            if (profile != null)
            {
                profile.FollowingCount++;
                _context.SaveChanges();
            }
        }

        public void DecFollowerCount(string username)
        {
            var profile = GetProfile(username);
            if (profile != null)
            {
                profile.FollowersCount--;
                _context.SaveChanges();
            }
        }

        public void DecFollowingCount(string username)
        {
            var profile = GetProfile(username);
            if (profile != null)
            {
                profile.FollowingCount--;
                _context.SaveChanges();
            }
        }

    }
}
