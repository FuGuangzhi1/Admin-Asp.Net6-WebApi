using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Fu.ExeclHelper.Exensions
{
    public static class WookBookExensions
    {
        public static byte[] ExeclTobyte(this IWorkbook workBook)
        {
            MemoryStream memoryStream = new();
            workBook.Write(memoryStream);
            byte[] data = memoryStream.ToArray();
            memoryStream.Write(data, 0, data.Length);
            return data;
        }
    }
}
