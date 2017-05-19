using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Peccancy.WebApp.Models.ORM;
using Peccancy.WebApp.Interfaces;

namespace Peccancy.WebApp.Controllers
{
    public class IllegalController:Controller
    {
        private readonly IIllegalManger illegalManger;
        public IllegalController(IIllegalManger illegalManger)
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
            return RedirectToAction("IllegalList", "Illegal");
        }
        /// <summary>
        /// 违章规则列表
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> IllegalList()
        {
            List<Illegal> illegals =await illegalManger.IllegalList();
            return View("List",illegals);
        }
    }
}
