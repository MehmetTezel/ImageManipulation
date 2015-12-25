using System;
using System.Collections;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ImageManipulation.CoreNS
{
    public static class MyImageTools
    {
        public static unsafe void CopyBitmapToPixelsBuffer()
        {
            BitmapSource source = CurrentState.bitmapImage as BitmapSource;
            PixelColor[,] pixels = CurrentState.pixels;

            fixed (PixelColor* buffer = &pixels[0, 0])
              source.CopyPixels(
                new Int32Rect(0, 0, source.PixelWidth, source.PixelHeight),
                (IntPtr)(buffer),
                pixels.GetLength(0) * pixels.GetLength(1) * sizeof(PixelColor),
                source.PixelWidth * 4);
        }

        public static unsafe WriteableBitmap WritePixelsToBitmap()
        {
            BitmapSource source = CurrentState.bitmapImage as BitmapSource;
            PixelColor[,] pixels = CurrentState.pixels;

            WriteableBitmap writableBitmap = new WriteableBitmap(source);
            fixed (PixelColor* buffer = &pixels[0, 0])
            writableBitmap.WritePixels(
                new Int32Rect(0, 0, source.PixelWidth, source.PixelHeight),
                (IntPtr)(buffer),
                pixels.GetLength(0) * pixels.GetLength(1) * sizeof(PixelColor),
                source.PixelWidth * sizeof(PixelColor), 0, 0);

            return writableBitmap;
        }


        public static void ChangePixelColor(PixelColor pixelColor)
        {
            PixelColor[,] pixels = CurrentState.pixels;

            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    pixels[i, j].ChangeColors(pixelColor);
                }
            CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();
        }



        public static void ToOneBit()
        {
            PixelColor[,] pixels = CurrentState.pixels;

            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    pixels[i, j].ToOneBit();
                }
        }

        public static void ToGray()
        {
            PixelColor[,] pixels = CurrentState.pixels;

            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    pixels[i, j].ToGray();
                }

        }
        public static void ToGray2()
        {
            PixelColor[,] pixels = CurrentState.pixels;

            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    pixels[i, j].ToGray2();
                }
        }

        public static void ToGray3()
        {
            PixelColor[,] pixels = CurrentState.pixels;

            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    pixels[i, j].ToGray3();
                }
        }
        public static void ToGray4()
        {
            PixelColor[,] pixels = CurrentState.pixels;

            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    pixels[i, j].ToGray4();
                }
        }
        public static void IntensifyHighBitsReduceLowBits(byte amount)
        {
            PixelColor[,] pixels = CurrentState.pixels;

            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    pixels[i, j].IntensifyHighBitsReduceLowBits(amount);
                }

        }
        public static void AddBrightness(byte brightness)
        {
            PixelColor[,] pixels = CurrentState.pixels;
            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    pixels[i, j].AddBrightness(brightness);
                }
        }

        public static void AddRedBrightness(byte brightness)
        {
            PixelColor[,] pixels = CurrentState.pixels;
            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    pixels[i, j].AddBrightness(brightness);
                }
        }

        public static void IntensifyRed( byte amount)
        {
            PixelColor[,] pixels = CurrentState.pixels;
            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    pixels[i, j].IntensifyRed1(amount);
                }
        }

        public static void ReverseColor()
        {
            PixelColor[,] pixels = CurrentState.pixels;
            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    pixels[i, j].ReverseColor();
                }
        }
        public static void RemoveWeakColors()
        {
            PixelColor[,] pixels = CurrentState.pixels;
            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    pixels[i, j].RemoveWeakColors();
                }
        }

        public static void IntensifyStrongestColor( byte amount)
        {
            PixelColor[,] pixels = CurrentState.pixels;
            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    pixels[i, j].IntensifyStrongestColor(amount);
                }
        }

    }
}
