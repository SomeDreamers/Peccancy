using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peccancy.WebApp.Models.ORM
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class Admin
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
