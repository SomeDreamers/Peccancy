using Microsoft.AspNetCore.Mvc;
using Peccancy.WebApp.Models.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Peccancy.WebApp.Models.View
{
    public class UserModel
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
        [Remote("VerifyName", "Account", ErrorMessage = "该用户名已存在！")]
        public string Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "密码不能为空")]
        [MinLength(6, ErrorMessage = "密码不能小于6个字符")]
        [MaxLength(30, ErrorMessage = "密码不能超过30个字符")]
        public string Password { get; set; }

        /// <summary>
        /// 角色 
        /// </summary>
        public int Role { get; set; }

        /**************************表外字段*****************************/
        /// <summary>
        /// 确认密码
        /// </summary>
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "请输入确认密码")]
        [Compare("Password", ErrorMessage = "确认密码不一致")]
        public string SurePassword { get; set; }

        public UserModel() { }

        public UserModel(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Password = user.Password;
        }

        public User GetUser()
        {
            return new User
            {
                Id = Id,
                Name = Name,
                Password = Password
            };
        }
    }
}
