using System;
using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ImageManipulation.CoreNS
{
    public static class MyImageTools
    {



        public static unsafe void ConstructPixelBufferFromFile()
        {
            BitmapSource source = CurrentState.bitmapImage as BitmapSource;
            PixelColor[,] pixels = CurrentState.originalPixels;

            fixed (PixelColor* buffer = &pixels[0, 0])
              source.CopyPixels(
                new Int32Rect(0, 0, source.PixelWidth, source.PixelHeight),
                (IntPtr)(buffer),
                pixels.GetLength(0) * pixels.GetLength(1) * sizeof(PixelColor),
                source.PixelWidth * sizeof(PixelColor));
            CurrentState.pixels = new PixelColor[CurrentState.originalPixels.GetLength(0), CurrentState.originalPixels.GetLength(1)];
            Array.Copy(CurrentState.originalPixels, CurrentState.pixels, pixels.Length);
        }

        public static unsafe void SetCurrentState(string fileName, Image image)
        {
            Uri uri = new Uri(fileName, UriKind.RelativeOrAbsolute);
            BitmapImage bitmapImage = new BitmapImage(uri);
            CurrentState.originalPixels = new PixelColor[bitmapImage.PixelHeight, bitmapImage.PixelWidth];
            CurrentState.fullfileName = fileName;
            CurrentState.bitmapImage = bitmapImage;
            CurrentState.image = image;
        }

        public static unsafe WriteableBitmap WritePixelsToBitmap()
        {
            BitmapSource source = CurrentState.bitmapImage as BitmapSource;
            PixelColor[,] pixels = CurrentState.pixels;

            WriteableBitmap writableBitmap = new WriteableBitmap(source);
            int rows = pixels.GetLength(0);
            int cols   = pixels.GetLength(1);
            fixed (PixelColor* buffer = &pixels[0, 0])

            writableBitmap.WritePixels(
                new Int32Rect(0, 0, source.PixelWidth, source.PixelHeight),
                (IntPtr)(buffer),
                pixels.GetLength(0) * pixels.GetLength(1) * sizeof(PixelColor),
                source.PixelWidth * sizeof(PixelColor), 0, 0);

            return writableBitmap;
        }

        public static void SaveImage(string filePath)
        {
            var encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)CurrentState.image.Source));
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
                encoder.Save(stream);
        }


        public static void ChangePixelColor(PixelParameter pixelParam)
        {
            PixelColor[,] pixels = new PixelColor[CurrentState.originalPixels.GetLength(0), CurrentState.originalPixels.GetLength(1)];
            Array.Copy(CurrentState.originalPixels, pixels, pixels.Length);
            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    pixels[i, j].ChangeColors(pixelParam);
                    pixels[i, j].SwitchColors(pixelParam);
                }
            CurrentState.pixels = pixels;
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


        public static void ReverseColor()
        {
            PixelColor[,] pixels = CurrentState.pixels;
            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    pixels[i, j].ReverseColor();
                }
        }

        public static void Square()
        {
            PixelColor[,] pixels = CurrentState.pixels;
            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    CurrentState.pixels[i, j].Square();
                }
        }

        public static void SquareRoot()
        {
        
            for (int i = 0; i < CurrentState.pixels.GetLength(0); i++)
                for (int j = 0; j < CurrentState.pixels.GetLength(1); j++)
                {
                    CurrentState.pixels[i, j].SquareRoot();
                }
        }



        public static void RemoveWeakColors()
        {
            PixelColor[,] pixels = CurrentState.pixels;
            for (int i = 0; i < pixels.GetLength(0); i++)
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    CurrentState.pixels[i, j].RemoveWeakColors();
                }
        }


    }
}
