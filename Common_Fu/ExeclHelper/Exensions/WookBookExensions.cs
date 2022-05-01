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
            byte[] buffer = null;
            using (MemoryStream ms = new MemoryStream())
            {
                workBook.Write(ms);
                buffer = ms.GetBuffer();
                ms.Close();
            }
            return buffer;
        }
    }
}
