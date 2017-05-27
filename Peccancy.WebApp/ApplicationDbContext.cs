using Microsoft.EntityFrameworkCore;
using Peccancy.WebApp.Models.ORM;
using Peccancy.WebApp.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peccancy.WebApp
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// 管理员表
        /// </summary>
        public DbSet<Admin> Admin { get; set; }

        /// <summary>
        /// 违章规则表
        /// </summary>
        public DbSet<Illegal> Illegal { get; set; }

        /// <summary>
        /// 违章记录
        /// </summary>
        public DbSet<Record> Record { get; set; }

        public DbSet<RecordModel> RecordModel { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
