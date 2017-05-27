using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using Peccancy.WebApp.Enums;
using Peccancy.WebApp.Helpers;
using Peccancy.WebApp.Interfaces;
using Peccancy.WebApp.Models;
using Peccancy.WebApp.Models.ORM;
using Peccancy.WebApp.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Peccancy.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager userManager;
        public AccountController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        /// <summary>
        /// 普通用户登录界面
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            var bol = HttpContext.User.Identity.IsAuthenticated;
            if (bol)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        /// <summary>
        /// 管理员登录界面
        /// </summary>
        /// <returns></returns>
        public IActionResult AdminLogin()
        {
            var bol = HttpContext.User.Identity.IsAuthenticated;
            if (bol)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        /// <summary>
        /// 注册界面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            var bol = HttpContext.User.Identity.IsAuthenticated;
            if (bol)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IActionResult> Authenticate(LoginUserModel user)
        {
            ReturnResult result = new ReturnResult();
            var userName = "";
            long userId = 0;
            if(user.Role == (int)RoleType.System)
            {
                Admin admin = await userManager.GetAdminByNameAsync(user.Name);
                if (admin == null || admin.Password != EncryptionHelper.GetMD5(user.Password))
                {
                    result.IsSuccess = false;
                    result.Message = "用户名或密码错误！";
                    return Json(result);
                }
                userName = admin.Name;
                userId = admin.Id;
            }
            else
            {
                User customer = await userManager.GetUserByCardAsync(user.Name);
                if (customer == null || customer.Password != EncryptionHelper.GetMD5(user.Password))
                {
                    result.IsSuccess = false;
                    result.Message = "身份证号或密码错误！";
                    return Json(result);
                }
                userName = customer.TrueName;
                userId = customer.Id;
            }
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, userName, ClaimValueTypes.String), new Claim(ClaimTypes.Role, ((RoleType)user.Role).GetDescription(), ClaimValueTypes.String), new Claim(ClaimTypes.Sid, userId.ToString(), ClaimValueTypes.String) };
            var userIdentity = new ClaimsIdentity(claims, "Customer");
            var userPrincipal = new ClaimsPrincipal(userIdentity);
            await HttpContext.Authentication.SignInAsync("IdeaCoreUser", userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            var action = HttpContext.User.Identity.Role() == RoleType.System.GetDescription() ? "AdminLogin" : "Login";
            await HttpContext.Authentication.SignOutAsync("IdeaCoreUser");
            return RedirectToAction(action);
        }

        /// <summary>
        /// 验证用户名唯一性
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public async Task<bool> VerifyName(string Name)
        {
            User user = await userManager.GetUserByCardAsync(Name);
            return user == null;
        }

        /// <summary>
        /// 新增管理员界面
        /// </summary>
        /// <returns></returns>
        public IActionResult AddAdmin()
        {
            return View();
        }
        /// <summary>
        /// 新增管理员
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task<IActionResult> CreateAdmin(UserModel userModel)
        {
            //密码加密
            userModel.Password = EncryptionHelper.GetMD5(userModel.Password);
            //存储管理员信息
            await userManager.RegisterAsync(userModel);
            return RedirectToAction("index", "home"); 
        }
    }
}
