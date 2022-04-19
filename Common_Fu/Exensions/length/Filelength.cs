using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Fu
{
    public static partial class Extension
    {
        /// <summary>
        /// 文件大小判断
        /// </summary>
        /// <param name="size"></param>
        /// <param name="legGalSize"></param>
        /// <param name="kbOrMB"></param>
        /// <returns></returns>
        public static bool FileLength(this long size, int legGalSize, bool kbOrMB = true)
        {
            if (kbOrMB)
            {
                var resultSize = size / 1024;
                return legGalSize > resultSize;
            }
            else
            {
                long resultSize = size / 1024;
                resultSize = resultSize / 1024;
                return legGalSize > resultSize;
            }

        }
    }
}
