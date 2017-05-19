using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Peccancy.WebApp.Models.ORM
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public long Id { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public string Card { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public string TrueName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public string Tell { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public string Address { get; set; }

        /// <summary>
        /// 户籍所在地
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public string Domicile { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public int Sex { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "不能为空")]
        public string Password { get; set; }
    }
}
