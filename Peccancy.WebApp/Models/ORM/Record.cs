using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Peccancy.WebApp.Models.ORM
{
    /// <summary>
    /// 违章记录
    /// </summary>
    public class Record
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public long Id { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public long UserId { get; set; }

        /// <summary>
        /// 违章规则ID
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public long IllegalId { get; set; }

        /// <summary>
        /// 处理人
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public string HandleMan { get; set; }

        /// <summary>
        /// 违章时间
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public DateTime Time { get; set; }

        /// <summary>
        /// 违章地点
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public string Location { get; set; }

        /// <summary>
        /// 处理状态（待处理、已处理）
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public int Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public string Memo { get; set; }
    }
}
