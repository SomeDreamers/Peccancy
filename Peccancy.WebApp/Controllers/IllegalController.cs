using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Peccancy.WebApp.Models.ORM;
using Peccancy.WebApp.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Peccancy.WebApp.Controllers
{
    [Authorize]
    public class IllegalController:Controller
    {
        private readonly IIllegalManager illegalManger;
        public IllegalController(IIllegalManager illegalManger)
        {
            this.illegalManger = illegalManger;
        }
        /// <summary>
        /// 显示创建页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// 创建违章规则
        /// </summary>
        /// <param name="illegal"></param>
        /// <returns></returns>
        public async Task<IActionResult> Save(Illegal illegal)
        {
            await illegalManger.CreateAsync(illegal);
            return RedirectToAction("List", "Illegal");
        }
        /// <summary>
        /// 违章规则列表
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> List()
        {
            List<Illegal> illegals =await illegalManger.GetIllegalListAsync();
            return View("List",illegals);
        }
    }
}
