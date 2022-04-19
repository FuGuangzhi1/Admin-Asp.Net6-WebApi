using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Fu.Redis
{
    public class CustomRedisConfig
    {
        //地址
        public string? Host { get; set; }
        //端口
        public int Port { get; set; }
        public int DefaultDB { get; set; }
        
    }
}
