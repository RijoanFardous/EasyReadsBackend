using EasyReadsAPI.Auth;
using EasyReadsBLL.DTOs;
using EasyReadsBLL.Models;
using EasyReadsBLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyReadsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("signup")]
        public IActionResult Signup(UserDTO user)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(_userService.IsUniqueUsername(user.Username))
                    {
                        if (_userService.IsUniqueEmail(user.Email))
                        {
                            var token = _userService.Signup(user);
                            return Ok(token);
                        }
                        ModelState.AddModelError("Email", "Email already used.");
                        return BadRequest(ModelState);
                    }
                    ModelState.AddModelError("Username", "Username taken. Please try another.");
                    return BadRequest(ModelState);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginData data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var token = _userService.Login(data);
                    if (token != null)
                    {
                        return Ok(token);
                    }
                    ModelState.AddModelError("Message", "Invalid Username or Password");
                    return BadRequest(ModelState);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }


        [TypeFilter(typeof(LoggedAttribute))]
        [HttpDelete]
        [Route("logout")]
        public IActionResult Logout()
        {
            try
            {
                var tokenkey = HttpContext.Request.Headers["Authorization"];
                _userService.Logout(tokenkey);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }


        [TypeFilter(typeof(LoggedAttribute))]
        [HttpPut]
        [Route("changepassword")]
        public IActionResult ChangePassword(ChangePassData data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_userService.ChangePassword(data))
                    {
                        return Ok();
                    }
                    ModelState.AddModelError("Message", "Invalid Username or Password");
                    return BadRequest(ModelState);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("get/all")]
        public IActionResult GetAllUsers()
        {
            try
            {
                List<UserDTO> usersDTO = _userService.GetAllUsers();
                return Ok(usersDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("get/{username}")]
        public IActionResult GetUser(string username)
        {
            try
            {
                var user = _userService.GetUser(username);
                if(user != null) return Ok(user);
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("get/profile/{username}")]
        public IActionResult GetUserProfile(string username)
        {
            try
            {
                var userProfile = _userService.GetUserProfile(username);
                if (userProfile != null)
                {
                    return Ok(userProfile);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }


        [TypeFilter(typeof(LoggedAttribute))]
        [HttpPut]
        [Route("update/profile/{username}")]
        public IActionResult UpdateProfile(UserProfileDTO userProfile)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var data = _userService.UpdateProfile(userProfile);
                    if(data != null)
                    {
                        return Ok(data);
                    }
                    return BadRequest();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Occurred: {ex.Message}");
            }
        }
    }
}
