using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Fu.GuidHelper
{
    public static class GuidHelper
    {
        public static Guid GetNewGuid()
        {
            Thread.Sleep(100);
            Int64 lastTicks = -1;
            long ticks = System.DateTime.UtcNow.Ticks;

            if (ticks <= lastTicks)
            {
                ticks = lastTicks + 1;
            }

            byte[] ticksBytes = BitConverter.GetBytes(ticks);

            Array.Reverse(ticksBytes);

            Guid myGuid = new();
            byte[] guidBytes = myGuid.ToByteArray();

            Array.Copy(ticksBytes, 0, guidBytes, 10, 6);
            Array.Copy(ticksBytes, 6, guidBytes, 8, 2);

            Guid newGuid = new(guidBytes);

            //string filepath = @"D:\temp\TheNewGuids.txt";
            //using (StreamWriter writer = new StreamWriter(filepath, true))
            //{
            //    writer.WriteLine("GUID Created = " + newGuid.ToString());
            //}

            return newGuid;
        }
    }
}
