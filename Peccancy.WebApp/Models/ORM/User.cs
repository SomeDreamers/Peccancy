﻿using System;
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
        public long Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(8, ErrorMessage = "用户名不超过8个字符")]
        public string Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        [MinLength(6, ErrorMessage = "密码不能小于6个字符")]
        [MaxLength(30, ErrorMessage = "密码不能超过30个字符")]
        public string Password { get; set; }
    }
}
