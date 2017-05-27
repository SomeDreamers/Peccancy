using Peccancy.WebApp.Models.ORM;
using Peccancy.WebApp.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peccancy.WebApp.Interfaces
{
    public interface IRecordManager
    {
        /// <summary>
        /// 保存违章记录
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Task SaveAsync(Record record);

        /// <summary>
        /// 获取违章记录模型
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="illegalTitle"></param>
        /// <returns></returns>
        Task<List<RecordModel>> GetRecordsAsync(string userName = "", string illegalTitle = "", long userId = 0);

        /// <summary>
        /// 处理违章记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="handleMan"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        Task HandleRecordAsync(long id, string handleMan, string memo);

        /// <summary>
        /// 根据ID获取违章记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Record> GetRecordByIdAsync(long id);
    }
}
