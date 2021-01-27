using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WhlMicroservices.Base.Interface;
using WhlMicroservices.Base.Model;
using WhlServices.Common.Common;

namespace WhlMicroservices.UserMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [Route("query")]
        [HttpGet]
        public JsonResult QueryUser(string username, string password)
        {
            Console.WriteLine($"This is {typeof(UserController).Name}{nameof(QueryUser)} username={username} password={password}");
            AjaxResult<Userinfo> ajaxResult = null;
            Userinfo tbUser = _userService.QueryUser(username, password);

            ajaxResult = new AjaxResult<Userinfo>()
            {
                Result = true,
                TValue = tbUser
            };
            return new JsonResult(ajaxResult);
        }

        [Route("/api/user/verify")]
        [HttpGet]
        //[AllowAnonymousAttribute]//自己校验
        public JsonResult CurrentUser()
        {
            AjaxResult ajaxResult = null;
            IEnumerable<Claim> claimlist = HttpContext.AuthenticateAsync().Result.Principal.Claims;
            if (claimlist != null && claimlist.Count() > 0)
            {
                string username = claimlist.FirstOrDefault(u => u.Type == "username").Value;
                string id = claimlist.FirstOrDefault(u => u.Type == "id").Value;
                ajaxResult = new AjaxResult()
                {
                    Result = true,
                    Value = new
                    {
                        id = id,
                        username = username,
                    }
                };
            }
            else
            {
                ajaxResult = new AjaxResult()
                {
                    Result = false,
                    Message = "Token无效，请重新登陆"
                };
            }
            return new JsonResult(ajaxResult);
        }
    }
}
