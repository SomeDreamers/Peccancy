using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Peccancy.WebApp.Models.ORM
{
    public class Illegal
    {
        /// <summary>
        /// 违章规则ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 违章规则标题
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public string Title { get; set; }
        /// <summary>
        /// 违章规则内容
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public string Content { get; set; }
        /// <summary>
        /// 违章类型
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public string Type { get; set; }
        /// <summary>
        /// 违章严重程度
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public string Ponderance { get; set; }
        /// <summary>
        /// 违章惩罚
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public string Punishment { get; set; }

    }
}
