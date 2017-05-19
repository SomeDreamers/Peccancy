using Peccancy.WebApp.Models.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peccancy.WebApp.Models.View
{
    public class IllegalModel
    {
        /// <summary>
        /// 违章规则列表
        /// </summary>
        public List<Illegal> IllegalList { get; set; }
    }
}
