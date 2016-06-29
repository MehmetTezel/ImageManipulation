using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation.CoreNS
{
    class Histogram
    {
        long[] Red = new long[byte.MaxValue+1];
        long[] Green = new long[byte.MaxValue + 1];
        long[] Blue = new long[byte.MaxValue + 1];

        void CalculateColorCounts()
        {
            for(int i=0;i<CurrentState.pixels.GetLength(0);i++)
            {
                for(int j=0;j<CurrentState.pixels.GetLength(1);j++)
                {
                    Red[CurrentState.pixels[i, j].Red]++;
                    Green[CurrentState.pixels[i, j].Green]++;
                    Blue[CurrentState.pixels[i, j].Blue]++;
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

            for (int i = 0; i < CurrentState.pixels.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentState.pixels.GetLength(1); j++)
                {

                    if(maxRed != minRed)
                        CurrentState.pixels[i, j].Red =
                                       (byte)((CurrentState.pixels[i, j].Red - minRed) * byte.MaxValue / (maxRed - minRed));
                    if(maxGreen !=minGreen)
                        CurrentState.pixels[i, j].Green =
                                       (byte)((CurrentState.pixels[i, j].Green - minGreen) * byte.MaxValue / (maxRed - minGreen));
                    if(maxBlue!= minBlue)
                        CurrentState.pixels[i, j].Blue =
                                       (byte)((CurrentState.pixels[i, j].Blue - minBlue) * byte.MaxValue / (maxBlue - minBlue));
                }
            }

        }
        int GetNinColor(long [] ColorCount)
        {
            int i;
            for( i=0;i<=byte.MaxValue;i++)
            {
                if (ColorCount[i] != 0)
                    return i;
            }
            return i;
        }

        int GetNaxColor(long[] ColorCount)
        {
            int i;
            for ( i = byte.MaxValue; i>=0;i--)
            {
                if (ColorCount[i] != 0)
                    return i;
            }
            return i;
        }

    }


}
