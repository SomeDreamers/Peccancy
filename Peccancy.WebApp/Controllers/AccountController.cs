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
                if (admin == null || admin.Password != GetMD5(user.Password))
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
                if (customer == null || customer.Password != GetMD5(user.Password))
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
        /// MD5加密
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static string GetMD5(string myString)
        {
            string pwd = "";
            MD5 md5 = MD5.Create(); //实例化一个md5对像
                                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(myString));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd = pwd + s[i].ToString("X").PadLeft(2, '0');
            }
            return pwd;
        }
    }
}
