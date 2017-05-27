using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Peccancy.WebApp.Helpers;
using Peccancy.WebApp.Interfaces;
using Peccancy.WebApp.Models.ORM;
using Peccancy.WebApp.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peccancy.WebApp.Controllers
{
    [Authorize]
    public class RecordController : Controller
    {
        private readonly IRecordManager recordManager;
        private readonly IIllegalManager illegalManager;
        private readonly IUserManager userManager;
        public RecordController(IRecordManager recordManager, IIllegalManager illegalManager, IUserManager userManager)
        {
            this.recordManager = recordManager;
            this.illegalManager = illegalManager;
            this.userManager = userManager;
        }

        /// <summary>
        /// 违章记录列表
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> List(string userName, string illegalTitle)
        {
            List<RecordModel> models = await recordManager.GetRecordsAsync(userName, illegalTitle);
            return View(models);
        }

        /// <summary>
        /// 添加违章记录界面
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            //获取用户下拉列表数据
            List<User> users = await userManager.GetUserListAsync();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var user in users)
            {
                items.Add(new SelectListItem { Text = user.TrueName, Value = user.Id.ToString() });
            }
            ViewData["UserItems"] = items;
            //获取违章规则下拉列表数据
            items = new List<SelectListItem>();
            List<Illegal> illegals = await illegalManager.GetIllegalListAsync();
            foreach (var illegal in illegals)
            {
                items.Add(new SelectListItem { Text = illegal.Title, Value = illegal.Id.ToString() });
            }
            ViewData["IllegalItems"] = items;
            return View();
        }

        /// <summary>
        /// 保存违章记录
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task<IActionResult> Save(Record record)
        {
            await recordManager.SaveAsync(record);
            return RedirectToAction("List");
        }

        /// <summary>
        /// 处理违章记录
        /// </summary>
        /// <param name="handleMan"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public async Task<IActionResult> Handle(long id, string handleMan, string memo)
        {
            await recordManager.HandleRecordAsync(id, handleMan, memo);
            return Json(new { IsSuccess = true });
        }

        /// <summary>
        /// 编辑违章记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(long id)
        {
            Record record = await recordManager.GetRecordByIdAsync(id);
            //获取用户下拉列表数据
            List<User> users = await userManager.GetUserListAsync();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var user in users)
            {
                items.Add(new SelectListItem { Text = user.TrueName, Value = user.Id.ToString(), Selected = user.Id == record.UserId });
            }
            ViewData["UserItems"] = items;
            //获取违章规则下拉列表数据
            items = new List<SelectListItem>();
            List<Illegal> illegals = await illegalManager.GetIllegalListAsync();
            foreach (var illegal in illegals)
            {
                items.Add(new SelectListItem { Text = illegal.Title, Value = illegal.Id.ToString(), Selected = illegal.Id == record.IllegalId });
            }
            ViewData["IllegalItems"] = items;
            return View(record);
        }

        /// <summary>
        /// 用户个人违章记录
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> PersonList()
        {
            long id = HttpContext.User.Identity.Uid();
            var records = await recordManager.GetRecordsAsync(userId: id);
            return View(records);
        }
    }
}
