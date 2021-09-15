using System;
using log4net.Repository.Hierarchy;

namespace ASF.Framework.Utilities
{
    public class LogUtils
    {
        public static String GetRequestId()
        {
            return log4net.LogicalThreadContext.Properties["request-id"] == null ? null : log4net.LogicalThreadContext.Properties["request-id"].ToString();
        }
    }
}