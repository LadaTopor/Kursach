using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace Kursach
{
    class Cryption
    {
        static public void SetEncryption(Bitmap bPic)
        {
            byte[] Symbol = Encoding.GetEncoding(1251).GetBytes("/");
            BitArray ArrBeginSymbol = Bits.ByteToBit(Symbol[0]);
            Color curColor = bPic.GetPixel(0, 0);
            BitArray tempArray = Bits.ByteToBit(curColor.R);
            tempArray[0] = ArrBeginSymbol[0];
            tempArray[1] = ArrBeginSymbol[1];
            byte nR = Bits.BitToByte(tempArray);

            tempArray = Bits.ByteToBit(curColor.G);
            tempArray[0] = ArrBeginSymbol[2];
            tempArray[1] = ArrBeginSymbol[3];
            tempArray[2] = ArrBeginSymbol[4];
            byte nG = Bits.BitToByte(tempArray);

            tempArray = Bits.ByteToBit(curColor.B);
            tempArray[0] = ArrBeginSymbol[5];
            tempArray[1] = ArrBeginSymbol[6];
            tempArray[2] = ArrBeginSymbol[7];
            byte nB = Bits.BitToByte(tempArray);

            Color nColor = Color.FromArgb(nR, nG, nB);
            bPic.SetPixel(0, 0, nColor);
        }

    static public bool isEncryption(Bitmap scr)
        {
            byte[] rez = new byte[1];
            Color color = scr.GetPixel(0, 0);
            BitArray colorArray = Bits.ByteToBit(color.R); //получаем байт цвета и преобразуем в массив бит
            BitArray messageArray = Bits.ByteToBit(color.R); ;//инициализируем результирующий массив бит
            messageArray[0] = colorArray[0];
            messageArray[1] = colorArray[1];

            colorArray = Bits.ByteToBit(color.G);//получаем байт цвета и преобразуем в массив бит
            messageArray[2] = colorArray[0];
            messageArray[3] = colorArray[1];
            messageArray[4] = colorArray[2];

            colorArray = Bits.ByteToBit(color.B);//получаем байт цвета и преобразуем в массив бит
            messageArray[5] = colorArray[0];
            messageArray[6] = colorArray[1];
            messageArray[7] = colorArray[2];
            rez[0] = Bits.BitToByte(messageArray); //получаем байт символа, записанного в 1 пикселе
            string m = Encoding.GetEncoding(1251).GetString(rez);
            if (m == "/")
            {
                return true;
            }
            else return false;
        }

        static public void WriteCountText(int count, Bitmap src)
        {
            byte[] CountSymbols = Encoding.GetEncoding(1251).GetBytes(count.ToString());
            for (int i = 0; i < 3; i++)
            {
                BitArray bitCount = Bits.ByteToBit(CountSymbols[i]); //биты количества символов
                Color pColor = src.GetPixel(0, i + 1); //1, 2, 3 пикселы
                BitArray bitsCurColor = Bits.ByteToBit(pColor.R); //бит цветов текущего пикселя
                bitsCurColor[0] = bitCount[0];
                bitsCurColor[1] = bitCount[1];
                byte nR = Bits.BitToByte(bitsCurColor); //новый бит цвета пиксея

                bitsCurColor = Bits.ByteToBit(pColor.G);//бит бит цветов текущего пикселя
                bitsCurColor[0] = bitCount[2];
                bitsCurColor[1] = bitCount[3];
                bitsCurColor[2] = bitCount[4];
                byte nG = Bits.BitToByte(bitsCurColor);//новый цвет пиксея

                bitsCurColor = Bits.ByteToBit(pColor.B);//бит бит цветов текущего пикселя
                bitsCurColor[0] = bitCount[5];
                bitsCurColor[1] = bitCount[6];
                bitsCurColor[2] = bitCount[7];
                byte nB = Bits.BitToByte(bitsCurColor);//новый цвет пиксея

                Color nColor = Color.FromArgb(nR, nG, nB); //новый цвет из полученных битов
                src.SetPixel(0, i + 1, nColor); //записали полученный цвет в картинку
            }
        }

        static public int ReadCountText(Bitmap src)
        {
            byte[] rez = new byte[3]; //массив на 3 элемента, т.е. максимум 999 символов шифруется
            for (int i = 0; i < 3; i++)
            {
                Color color = src.GetPixel(0, i + 1); //цвет 1, 2, 3 пикселей 
                BitArray colorArray = Bits.ByteToBit(color.R); //биты цвета
                BitArray bitCount = Bits.ByteToBit(color.R); ; //инициализация результирующего массива бит
                bitCount[0] = colorArray[0];
                bitCount[1] = colorArray[1];

                colorArray = Bits.ByteToBit(color.G);
                bitCount[2] = colorArray[0];
                bitCount[3] = colorArray[1];
                bitCount[4] = colorArray[2];

                colorArray = Bits.ByteToBit(color.B);
                bitCount[5] = colorArray[0];
                bitCount[6] = colorArray[1];
                bitCount[7] = colorArray[2];
                rez[i] = Bits.BitToByte(bitCount);
            }
            string m = Encoding.GetEncoding(1251).GetString(rez);
            return Convert.ToInt32(m, 10);
        }

        static public void Encrypt(Bitmap bPic, List<byte> bList)
        {
            int index = 0;
            bool st = false;
            for (int i = 4; i < bPic.Width; i++)
            {
                for (int j = 0; j < bPic.Height; j++)
                {
                    Color pixelColor = bPic.GetPixel(i, j);
                    if (index == bList.Count)
                    {
                        st = true;
                        break;
                    }
                    BitArray colorArray = Bits.ByteToBit(pixelColor.R);
                    BitArray messageArray = Bits.ByteToBit(bList[index]);
                    colorArray[0] = messageArray[0]; //меняем
                    colorArray[1] = messageArray[1]; // в нашем цвете биты
                    byte newR = Bits.BitToByte(colorArray);

                    colorArray = Bits.ByteToBit(pixelColor.G);
                    colorArray[0] = messageArray[2];
                    colorArray[1] = messageArray[3];
                    colorArray[2] = messageArray[4];
                    byte newG = Bits.BitToByte(colorArray);

                    colorArray = Bits.ByteToBit(pixelColor.B);
                    colorArray[0] = messageArray[5];
                    colorArray[1] = messageArray[6];
                    colorArray[2] = messageArray[7];
                    byte newB = Bits.BitToByte(colorArray);

                    Color newColor = Color.FromArgb(newR, newG, newB);
                    bPic.SetPixel(i, j, newColor);
                    index++;
                }
                if (st)
                {
                    break;
                }
            }
        }
        static public string Decrypt(Bitmap bPic)
        {
            int countSymbol = ReadCountText(bPic); //считали количество  символов
            byte[] message = new byte[countSymbol];
            int index = 0;
            bool st = false;
            for (int i = 4; i < bPic.Width; i++)
            {
                for (int j = 0; j < bPic.Height; j++)
                {
                    Color pixelColor = bPic.GetPixel(i, j);
                    if (index == message.Length)
                    {
                        st = true;
                        break;
                    }
                    BitArray colorArray = Bits.ByteToBit(pixelColor.R);
                    BitArray messageArray = Bits.ByteToBit(pixelColor.R); ;
                    messageArray[0] = colorArray[0];
                    messageArray[1] = colorArray[1];

                    colorArray = Bits.ByteToBit(pixelColor.G);
                    messageArray[2] = colorArray[0];
                    messageArray[3] = colorArray[1];
                    messageArray[4] = colorArray[2];

                    colorArray = Bits.ByteToBit(pixelColor.B);
                    messageArray[5] = colorArray[0];
                    messageArray[6] = colorArray[1];
                    messageArray[7] = colorArray[2];
                    message[index] = Bits.BitToByte(messageArray);
                    index++;
                }
                if (st)
                {
                    break;
                }
            }
            return Encoding.GetEncoding(1251).GetString(message);
        } 
    }
}
