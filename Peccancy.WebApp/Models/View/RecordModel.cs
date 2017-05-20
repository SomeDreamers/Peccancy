using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peccancy.WebApp.Models.View
{
    /// <summary>
    /// 违章记录模型
    /// </summary>
    public class RecordModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 违章规则ID
        /// </summary>
        public long IllegalId { get; set; }

        /// <summary>
        /// 处理人
        /// </summary>
        public string HandleMan { get; set; }

        /// <summary>
        /// 违章时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 违章地点
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 处理状态（待处理、已处理）
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }

        /********************表外字段***********************/
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 违章规则名
        /// </summary>
        public string IllegalTitle { get; set; }
    }
}
