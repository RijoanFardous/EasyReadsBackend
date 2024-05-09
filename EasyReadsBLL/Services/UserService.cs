using EasyReadsBLL.DTOs;
using EasyReadsBLL.Models;
using EasyReadsDAL;
using EasyReadsDAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReadsBLL.Services
{
    public class UserService
    {
        private readonly DataAccessFactory _dataAccessFactory;
        public UserService(DataAccessFactory dataAccessFactory)
        {
            _dataAccessFactory = dataAccessFactory;
        }


        public TokenDTO Signup(UserDTO userDTO)
        {
            // Create New User
            var user = Convert(userDTO);
            user.HashedPassword = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
            user.UserType = "Member";
            user.JoinDate = DateOnly.FromDateTime(DateTime.Today);

            _dataAccessFactory.UserData().Signup(user);

            // Create Profile for New User
            Profile profile = new Profile();
            profile.Bio = "New here, eager to connect!";
            profile.Username = user.Username;
            _dataAccessFactory.ProfileData().Create(profile);

            // Generate Token for New User
            Token token = GenerateToken(user.Username, user.UserType);
            _dataAccessFactory.TokenData().Create(token);
            return Convert(token);
        }

        public bool IsUniqueUsername(string username)
        {
            return _dataAccessFactory.UserData().IsUniqueUsername(username);
        }

        public bool IsUniqueEmail(string email)
        {
            return _dataAccessFactory.UserData().IsUniqueEmail(email);
        }

        public TokenDTO? Login(LoginData data)
        {
            var user = _dataAccessFactory.UserData().GetUser(data.Username);
            if(user == null) return null;

            bool isValid = BCrypt.Net.BCrypt.Verify(data.Password, user.HashedPassword);
            if (isValid)
            {
                Token token = GenerateToken(user.Username, user.UserType);
                _dataAccessFactory.TokenData().Create(token);
                return Convert(token);
            }
            return null;
        }

        public void Logout(string tokenkey)
        {
            _dataAccessFactory.TokenData().Delete(tokenkey);
        }

        public bool ChangePassword (ChangePassData data)
        {
            var user = _dataAccessFactory.UserData().GetUser(data.Username);
            if (user == null) return false;

            bool isValid = BCrypt.Net.BCrypt.Verify(data.CurrentPass, user.HashedPassword);
            if (isValid)
            {
                _dataAccessFactory.UserData().ChangePass(data.Username, BCrypt.Net.BCrypt.HashPassword(data.NewPass));
                return true;
            }
            return false;
        }

        public List<UserDTO> GetAllUsers()
        {
            List<User> users = _dataAccessFactory.UserData().GetAllUsers();

            return Convert(users);
        }

        public UserDTO? GetUser(string username)
        {
            var user =  _dataAccessFactory.UserData().GetUser(username);
            if(user != null) return Convert(user);
            return null;
        }

        public UserProfileDTO? GetUserProfile(string username)
        {
            // Get User and Profile Data.
            var user = _dataAccessFactory.UserData().GetUser(username);
            var profile = _dataAccessFactory.ProfileData().GetProfile(username);
            if (user != null && profile != null)
            {
                UserProfileDTO userProfile = new UserProfileDTO();
                userProfile.Username = username;
                userProfile.FullName = user.FullName;
                userProfile.Email = user.Email;
                userProfile.UserType = user.UserType;
                userProfile.JoinDate = user.JoinDate;
                userProfile.ProfilePicture = profile.ProfilePicture;
                userProfile.Bio = profile.Bio;
                userProfile.Address = profile.Address;
                userProfile.Website = profile.Website;
                userProfile.FollowersCount = profile.FollowersCount;
                userProfile.FollowingCount = profile.FollowingCount;
                return userProfile;
            }
            return null;
        }

        public UserProfileDTO? UpdateProfile(UserProfileDTO userProfile)
        {
            _dataAccessFactory.UserData().UpdateFullName(userProfile.Username, userProfile.FullName);

            Profile profile = new Profile
            {
                Username = userProfile.Username,
                Website = userProfile.Website,
                Address = userProfile.Address,
                Bio = userProfile.Bio,
            };
            _dataAccessFactory.ProfileData().Update(profile);

            var data = GetUserProfile(userProfile.Username);
            return data;
        }

        public Token GenerateToken(string username, string usertype)
        {
            return new Token
            {
                TokenKey = Guid.NewGuid().ToString(),
                Username = username,
                CreatedAt = DateTime.Now,
                UserType = usertype
            };
        }

        public Token? GetToken(string tokenkey)
        {
            return _dataAccessFactory.TokenData().Get(tokenkey);
        }

        public TokenDTO Convert(Token token)
        {
            return new TokenDTO
            {
                TokenKey = token.TokenKey,
                Username = token.Username,
            };
        }



        public List<UserDTO> Convert(List<User> users)
        {
            List<UserDTO> usersDTO = new List<UserDTO>();
            foreach (User user in users)
            {
                usersDTO.Add(Convert(user));
            }
            return usersDTO;
        }

        public UserDTO Convert(User user)
        {
            return new UserDTO
            {
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
                UserType = user.UserType,
                JoinDate = user.JoinDate,
            };
        }

        public User Convert(UserDTO user)
        {
            return new User
            {
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
            };
        }
    }
}
