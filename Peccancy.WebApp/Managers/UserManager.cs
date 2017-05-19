using Microsoft.EntityFrameworkCore;
using Peccancy.WebApp.Interfaces;
using Peccancy.WebApp.Models.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peccancy.WebApp.Managers
{
    public class UserManager : IUserManager
    {
        private readonly ApplicationDbContext context;
        public UserManager(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task CreateAsync(User user)
        {
            context.User.Add(user);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 删
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task DeleteAsync(User user)
        {
            context.User.Remove(user);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 查
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> QueryAsync()
        {
            //var takeUser = await context.User_users.TakeWhile(c => c.Id == 1).ToListAsync();
            var userModel = await context.User.SingleAsync(c => c.Id == 1);
            var user= context.User.Single(b => b.Id == 1);
            var users = await context.User.ToListAsync();
            //var Userss = context.User_users.Where(c => c.Name.Contains("ew".Trim())).ToList();    //contains存在问题
            var usersss = context.User.FromSql("Select * from user_users where id > 10 limit 0, 10").ToList();
            return usersss;
        }

        /// <summary>
        /// 改
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task UpdateAsync(User user)
        {
            context.User.Update(user);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 根据身份证号获取用户
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<User> GetUserByCardAsync(string card)
        {
            return (await context.User.Where(c => c.Card == card).ToListAsync()).FirstOrDefault();
        }

        /// <summary>
        /// 根据用户名获取管理员
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Admin> GetAdminByNameAsync(string name)
        {
            return (await context.Admin.Where(c => c.Name == name).ToListAsync()).FirstOrDefault();
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task RegisterAsync(User user)
        {
            context.User.Add(user);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 获取用户数据集合
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public async Task<List<User>> GetUserListAsync()
        {
            return await context.User.ToListAsync();
        }
    }
}
