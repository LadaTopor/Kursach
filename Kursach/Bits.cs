using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    internal class Bits
    {

        static public BitArray ByteToBit(byte src)
        {
            BitArray bitArray = new BitArray(8);
            bool st = false;
            for (int i = 0; i < 8; i++)
            {
                if ((src >> i & 1) == 1)
                {
                    st = true;
                }
                else st = false;
                bitArray[i] = st;
            }
            return bitArray;
        }

        static public byte BitToByte(BitArray src)
        {
            byte num = 0;
            for (int i = 0; i < src.Count; i++)
                if (src[i] == true)
                    num += (byte)Math.Pow(2, i);
            return num;
        }
    }
}
