using EasyReadsBLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EasyReadsAPI.Auth
{
    public class LoggedAttribute : Attribute, IAuthorizationFilter
    {
        private readonly UserService _userService;
        public LoggedAttribute (UserService userService)
        {
            _userService = userService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenkey = context.HttpContext.Request.Headers["Authorization"];

            if (!string.IsNullOrWhiteSpace(tokenkey))
            {
                var token = _userService.GetToken(tokenkey);
                if(token != null)
                {
                    return;
                }
            }
            context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
        }
    }
}
