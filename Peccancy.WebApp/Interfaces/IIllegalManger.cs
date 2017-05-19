using Peccancy.WebApp.Models.ORM;
using Peccancy.WebApp.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peccancy.WebApp.Interfaces
{
    public interface IIllegalManger
    {
        /// <summary>
        /// 创建违章规则
        /// </summary>
        /// <returns></returns>
        Task CreateAsync(Illegal illegal);
        /// <summary>
        /// 违章列表
        /// </summary>
        /// <returns></returns>
        Task<List<Illegal>> IllegalList();
    }
}
