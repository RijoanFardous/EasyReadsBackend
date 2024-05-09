using EasyReadsBLL.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EasyReadsAPI.Auth
{
    public class AuthorAttribute : Attribute, IAuthorizationFilter
    {
        private readonly UserService _userService;
        public AuthorAttribute(UserService userService)
        {
            _userService = userService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenkey = context.HttpContext.Request.Headers["Authorization"];

            if (!string.IsNullOrWhiteSpace(tokenkey))
            {
                var token = _userService.GetToken(tokenkey);
                if (token != null && token.UserType.Equals("Author"))
                {
                    return;
                }
            }
            context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
        }
    }
}
