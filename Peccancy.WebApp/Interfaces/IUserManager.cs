using Peccancy.WebApp.Models.ORM;
using Peccancy.WebApp.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peccancy.WebApp.Interfaces
{
    public interface IUserManager
    {

        Task CreateAsync(User user);

        /// <summary>
        /// 查
        /// </summary>
        /// <returns></returns>
        Task<List<User>> QueryAsync();

        /// <summary>
        /// 根据身份证号获取用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<User> GetUserByCardAsync(string name);

        /// <summary>
        /// 根据用户名获取管理员
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Admin> GetAdminByNameAsync(string name);

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task RegisterAsync(User user);

        /// <summary>
        /// 获取用户数据集合
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        Task<List<User>> GetUserListAsync();
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task RegisterAsync(UserModel model);
    }
}
