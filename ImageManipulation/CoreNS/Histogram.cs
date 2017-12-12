using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation.CoreNS
{
    class Histogram
    {
        long[] Red = new long[byte.MaxValue + 1];
        long[] Green = new long[byte.MaxValue + 1];
        long[] Blue = new long[byte.MaxValue + 1];

        void CalculateColorCounts()
        {
            for (int i = 0; i < CurrentState.currentPixels.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentState.currentPixels.GetLength(1); j++)
                {
                    Red[CurrentState.currentPixels[i, j].Red]++;
                    Green[CurrentState.currentPixels[i, j].Green]++;
                    Blue[CurrentState.currentPixels[i, j].Blue]++;
                }
            }
        }

        public void Equalise()
        {
            CalculateColorCounts();
            int minRed = GetNinColor(Red);
            int maxRed = GetNaxColor(Red);

            int minGreen = GetNinColor(Green);
            int maxGreen = GetNaxColor(Green);

            int minBlue = GetNinColor(Blue);
            int maxBlue = GetNaxColor(Blue);

            for (int i = 0; i < CurrentState.currentPixels.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentState.currentPixels.GetLength(1); j++)
                {

                    if (maxRed != minRed)
                        CurrentState.currentPixels[i, j].Red =
                                       (byte)((CurrentState.currentPixels[i, j].Red - minRed) * byte.MaxValue / (maxRed - minRed));
                    if (maxGreen != minGreen)
                        CurrentState.currentPixels[i, j].Green =
                                       (byte)((CurrentState.currentPixels[i, j].Green - minGreen) * byte.MaxValue / (maxRed - minGreen));
                    if (maxBlue != minBlue)
                        CurrentState.currentPixels[i, j].Blue =
                                       (byte)((CurrentState.currentPixels[i, j].Blue - minBlue) * byte.MaxValue / (maxBlue - minBlue));
                }
            }

        }
        int GetNinColor(long[] ColorCount)
        {
            int i;
            for (i = 0; i <= byte.MaxValue; i++)
            {
                if (ColorCount[i] != 0)
                    return i;
            }
            return i;
        }

        int GetNaxColor(long[] ColorCount)
        {
            int i;
            for (i = byte.MaxValue; i >= 0; i--)
            {
                if (ColorCount[i] != 0)
                    return i;
            }
            return i;
        }



    }



}
