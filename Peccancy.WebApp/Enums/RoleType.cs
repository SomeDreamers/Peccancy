using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peccancy.WebApp.Enums
{
    public enum RoleType
    {
        /// <summary>
        /// 管理员
        /// </summary>
        System = 1,
        /// <summary>
        /// 用户
        /// </summary>
        User = 2
    }

    public static class RoleTypeExtension
    {
        public static string GetDescription(this RoleType type)
        {
            switch (type)
            {
                case RoleType.System: return "System";
                case RoleType.User: return "User";
                default: return "";
            }
        }
    }
}
