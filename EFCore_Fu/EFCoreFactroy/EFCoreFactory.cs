using Common_Fu;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Fu.EFCoreFactroy
{
    public interface IEFCoreFactory
    {
        MyDBContext CreateDefaultDBContext();
    }

    public class EFCoreFactory : IEFCoreFactory
    {
        private readonly IConfiguration _configuration;

        public EFCoreFactory(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public MyDBContext CreateDefaultDBContext()
        {
            //根据配置文件获取操作的数据库
            string useSql = _configuration.GetSection("UseSql").Value;
            //EFCore上下文配置的建筑者
            DbContextOptionsBuilder<MyDBContext> dbContextOptionsBuilder = useSql switch
            {
                "MYSQL" => new DbContextOptionsBuilder<MyDBContext>()
                .UseMySQL(_configuration
                .GetConnectionString("mysql")),
                "SQLSever" => new DbContextOptionsBuilder<MyDBContext>()
                .UseSqlServer(_configuration
                .GetConnectionString("default")),
                _ => new DbContextOptionsBuilder<MyDBContext>()
                .UseSqlServer(_configuration
                .GetConnectionString("default"))
            };

            //实例化上下文
            MyDBContext dBContext
                = new MyDBContext(dbContextOptionsBuilder.Options);
            return dBContext;
        }
    }
}
