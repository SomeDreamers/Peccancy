using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peccancy.WebApp.Helpers;
using Peccancy.WebApp.Interfaces;
using Peccancy.WebApp.Models.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peccancy.WebApp.Controllers
{
    [Authorize]
    public class ManagerUserController : Controller
    {
        private readonly IUserManager userManager;
        public ManagerUserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// 登记用户界面
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            return View();
        }

        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<IActionResult> Save(User user)
        {
            user.Password = EncryptionHelper.GetMD5(user.Password);
            await userManager.RegisterAsync(user);
            return RedirectToAction("List");
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> List()
        {
            var users = await userManager.GetUserListAsync();
            return View(users);
        }
    }
}
