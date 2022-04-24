using Common_Fu;
using Entities.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Fu.Data.Test
{
    public static class TestTableClass
    {
        public static ModelBuilder AddTsetData(this ModelBuilder builder)
        {
            List<TestTable> testlist = new()
            {
                new TestTable
                {
                    TsetBool = true,
                    TsetInt = 1,
                    TsetDateTime = DateTime.Now,
                    TsetString = "帅哥1"
                },
                    new TestTable
                {
                    TsetBool = false,
                    TsetInt = 2,
                    TsetDateTime = DateTime.Now,
                    TsetString = "帅哥2"
                },
                new TestTable
                {
                    TsetBool = false,
                    TsetInt = 3,
                    TsetDateTime = DateTime.Now,
                    TsetString = "帅哥3"
                },
                new TestTable
                {
                    TsetBool = true,
                    TsetInt = 4,
                    TsetDateTime = DateTime.Now,
                    TsetString = "帅哥4"
                },
                new TestTable
                {
                    TsetBool = true,
                    TsetInt = 5,
                    TsetDateTime = DateTime.Now,
                    TsetString = "帅哥5"
                },
                new TestTable
                {
                    TsetBool = true,
                    TsetInt = 6,
                    TsetDateTime = DateTime.Now,
                    TsetString = "帅哥6"
                },
                new TestTable
                {
                    TsetBool = false,
                    TsetInt = 7,
                    TsetDateTime = DateTime.Now,
                    TsetString = "帅哥7"
                },
            };
            testlist.ForEach(x => x.InitDomainEntity(true));
            builder.Entity<TestTable>().HasData(testlist);
            return builder;
        }
    }
}
