using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Fu
{

    public static class Base64Convert
    {
        /// <summary>
        ///  文件转换成Base64字符串
        /// </summary>
        /// <param name="fs">文件流</param>
        /// <returns></returns>
        public static String FileToBase64(this Stream fs)
        {
            string strRet = null;

            try
            {
                if (fs == null) return null;
                byte[] bt = new byte[fs.Length];
                fs.Read(bt, 0, bt.Length);
                strRet = Convert.ToBase64String(bt);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return strRet;
        }

        /// <summary>
        /// Base64字符串转换成文件
        /// </summary>
        /// <param name="strInput">base64字符串</param>
        /// <param name="fileName">保存文件的绝对路径</param>
        /// <returns></returns>
        public static bool Base64ToFileAndSave(string strInput, string fileName)
        {
            bool bTrue = false;
            try
            {
                byte[] buffer = Convert.FromBase64String(strInput);
                FileStream fs = new FileStream(fileName, FileMode.CreateNew);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
                bTrue = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bTrue;
        }
    }
}
