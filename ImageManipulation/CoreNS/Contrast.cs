using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation.CoreNS
{
    class Contrast
    {
        long[] Red = new long[byte.MaxValue + 1];
        long[] Green = new long[byte.MaxValue + 1];
        long[] Blue = new long[byte.MaxValue + 1];

        static double percent = 0.1;
        double contrastDecrease = 0.9;
        double contrastIncrease = 1.1;
        
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

        int GetContrastMinColor(long[] ColorCount)
        {
            int i;
            long total = CurrentState.currentPixels.Length;
            long percent = (long)( total * Contrast.percent);
            
            long totalPercent = 0;
            for (i = 0; i <= byte.MaxValue; i++)
            {
                totalPercent += ColorCount[i];
                if (totalPercent >= percent)
                    return i;
            }
            return i;
        }

        int GetContrasMaxColor(long[] ColorCount)
        {
            int i;
            long total = CurrentState.currentPixels.Length;
            long percent = (long)(total * Contrast.percent);
            
            long totalPercent = 0;
            for (i = byte.MaxValue; i >= 0; i--)
            {
                totalPercent += ColorCount[i];
                if (totalPercent >= percent)
                    return i;
            }
            return i;
        }

        byte GetMinColorValue(byte colorValue)
        {
            return (byte)(colorValue * contrastDecrease);
        }
        byte GetMaxColorValue(byte colorValue)
        {
            if (colorValue * contrastIncrease > 255)
                return 255;
            else
                return colorValue;

        }

        public void AdjustContrast()
        {
            CalculateColorCounts();
            int minRed = GetContrastMinColor(Red);
            int maxRed = GetContrasMaxColor(Red);

            int minGreen = GetContrastMinColor(Green);
            int maxGreen = GetContrasMaxColor(Green);

            int minBlue = GetContrastMinColor(Blue);
            int maxBlue = GetContrasMaxColor(Blue);
            Contrast.percent = Contrast.percent * 1.1;
            for (int i = 0; i < CurrentState.currentPixels.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentState.currentPixels.GetLength(1); j++)
                {
                    if (minRed < maxRed)
                    {
                        if (CurrentState.currentPixels[i, j].Red <= minRed)
                            CurrentState.currentPixels[i, j].Red = GetMinColorValue(CurrentState.currentPixels[i, j].Red);
                        else if (CurrentState.currentPixels[i, j].Red >= maxRed)
                            CurrentState.currentPixels[i, j].Red = GetMaxColorValue(CurrentState.currentPixels[i, j].Red);
                    }

                    if (minGreen < maxGreen)
                    {
                        if (CurrentState.currentPixels[i, j].Green <= minGreen)
                            CurrentState.currentPixels[i, j].Green = GetMinColorValue(CurrentState.currentPixels[i, j].Green);
                        else if (CurrentState.currentPixels[i, j].Green >= maxGreen)
                            CurrentState.currentPixels[i, j].Green = GetMaxColorValue(CurrentState.currentPixels[i, j].Green);
                    }

                    if (minBlue < maxBlue)
                    {
                        if (CurrentState.currentPixels[i, j].Blue <= minBlue)
                            CurrentState.currentPixels[i, j].Blue = GetMinColorValue(CurrentState.currentPixels[i, j].Blue);
                        else if (CurrentState.currentPixels[i, j].Blue >= maxBlue)
                            CurrentState.currentPixels[i, j].Blue = GetMaxColorValue(CurrentState.currentPixels[i, j].Blue);
                    }
                }
            }

        }

    }



}
