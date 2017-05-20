using Microsoft.EntityFrameworkCore;
using Peccancy.WebApp.Interfaces;
using Peccancy.WebApp.Models.ORM;
using Peccancy.WebApp.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peccancy.WebApp.Managers
{
    public class RecordManager : IRecordManager
    {
        private readonly ApplicationDbContext context;
        public RecordManager(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 保存违章记录
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task SaveAsync(Record record)
        {
            //更新
            if(record.Id > 0)
            {
                context.Record.Update(record);
            }
            //新增
            else
            {
                context.Record.Add(record);
            }
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 获取违章记录模型
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="illegalTitle"></param>
        /// <returns></returns>
        public async Task<List<RecordModel>> GetRecordsAsync(string userName = "", string illegalTitle = "", long userId = 0)
        {
            string sql = @"SELECT r.id AS Id, r.userId AS UserId, r.illegalId AS IllegalId, r.handleMan AS HandleMan, r.time AS Time, r.location AS Location, r.`status` AS `Status`, r.memo AS Memo, u.trueName AS UserName, i.title AS IllegalTitle
                FROM record AS r LEFT JOIN `user` AS u ON r.userId = u.id LEFT JOIN illegal i ON r.illegalId = i.id WHERE 1 = 1";
            if (!string.IsNullOrEmpty(userName))
                sql += String.Format(" AND u.trueName LIKE '%{0}%'", userName);
            if (!string.IsNullOrEmpty(illegalTitle))
                sql += String.Format(" AND i.title LIKE '%{0}%'", illegalTitle);
            if (userId > 0)
                sql += String.Format(" AND r.userId = {0}", userId);
            List<RecordModel> records = await context.RecordModel.FromSql(sql).ToListAsync();
            return records;
        }

        /// <summary>
        /// 处理违章记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="handleMan"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public async Task HandleRecordAsync(long id, string handleMan, string memo)
        {
            Record record = await GetRecordByIdAsync(id);
            record.HandleMan = handleMan;
            record.Memo = memo;
            record.Status = 1;
            context.Record.Update(record);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// 根据ID获取违章记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Record> GetRecordByIdAsync(long id)
        {
            return await context.Record.SingleAsync(c => c.Id == id);
        }
    }
}
