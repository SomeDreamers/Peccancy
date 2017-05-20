using Microsoft.EntityFrameworkCore;
using Peccancy.WebApp.Interfaces;
using Peccancy.WebApp.Models.ORM;
using Peccancy.WebApp.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peccancy.WebApp.Managers
{
    public class IllegalManager : IIllegalManager
    {
        private readonly ApplicationDbContext context;
        public IllegalManager(ApplicationDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// 创建违章规则
        /// </summary>
        /// <returns></returns>
        public async Task CreateAsync(Illegal illegal)
        {
            context.Illegal.Add(illegal);
            await context.SaveChangesAsync();
        }
        /// <summary>
        /// 违章列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<Illegal>> IllegalList()
        {
            List<Illegal> list= await context.Illegal.ToListAsync();
            return list;
        }
    }
}
