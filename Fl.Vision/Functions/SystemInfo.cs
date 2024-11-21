using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL.Vision.Functions
{
    public class SystemInfo
    {
        public static string GetSystemEnvironmentVariable(string key) {
            // 获取系统环境变量的值
            return Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Machine);
        }
    }
}
