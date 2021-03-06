﻿using System;

namespace ImageManipulation.CoreNS
{
    class KernelMatrix
    {

        static int[,] edgeDetection2 = new int[,] { { 0, 1, 0 },
                                                    { 1,-4, 1 },
                                                    { 0, 1, 0 } };

        static int[,] edgeDetection3 = new int[,] { {-1,-1,-1 },
                                                    {-1, 8,-1 },
                                                    {-1,-1,-1 } };

        static int[,] SobelX = new int[,]          { { -1, 0, 1 },
                                                     { -2,-0, 2 },
                                                     { -1, 0, 1 } };

        static int[,] SobelY = new int[,]          { { 1, 2, 1 },
                                                     { 0, 0, 0 },
                                                     {-1,-2, -1 } };


        static int[,] EdgeDetectiın4 = new int[,]            {  { 1, 1, 1, 1, 1},
                                                                { 1, 2, 2 , 2, 1 },
                                                                { 1, 2,-32, 2, 1 },
                                                                { 1, 2, 2, 2, 1 },
                                                                { 1, 1, 1, 1, 1} };

        static int[,] sharpen = new int[,]        { { 0,-1, 0 },
                                                    {-1, 5,-1 },
                                                    { 0,-1, 0 } };




        static int boxBlurDivider = 9;
        static int[,] boxBlur = new int[,]        { { 1, 1, 1 },
                                                    { 1, 1, 1 },
                                                    { 1, 1, 1 } };
        static int GaussianBlurDivider = 16;
        static int[,] gaussianBlur = new int[,] {   { 1, 2, 1 },
                                                    { 2, 4, 2 },
                                                    { 1, 2, 1 } };


        static int WeightedMeanFilterDivider = 1;






        static PixelColor[,] ApplyMatrix(int[,] convMatrix,  int divider)
        {
            PixelColor[,] pixels2 = new PixelColor[CurrentState.currentPixels.GetLength(0), CurrentState.currentPixels.GetLength(1)];
            Array.Copy(CurrentState.currentPixels, pixels2, CurrentState.currentPixels.Length);

            for (int i = 1; i < CurrentState.currentPixels.GetLength(0) - convMatrix.GetLength(0)+2; i++)
            {
                for (int j = 1; j < CurrentState.currentPixels.GetLength(1) - convMatrix.GetLength(0) + 2; j++)
                {
                    int totalBlue = 0;
                    int totalGreen = 0;
                    int totalRed = 0;
                    for (int ind1 = 0; ind1 < convMatrix.GetLength(0); ind1++)
                    {
                        for (int ind2 = 0; ind2 < convMatrix.GetLength(1); ind2++)
                        {
                            
                            totalBlue = totalBlue + (convMatrix[ind1, ind2] * CurrentState.currentPixels[i - 1 + ind1, j - 1 + ind2].Blue);
                            totalGreen += convMatrix[ind1, ind2] * CurrentState.currentPixels[i - 1 + ind1, j - 1 + ind2].Green;
                            totalRed += convMatrix[ind1, ind2] * CurrentState.currentPixels[i - 1 + ind1, j - 1 + ind2].Red;
                        }
                    }
                    totalBlue = totalBlue / divider;
                    if (totalBlue < 0)
                        totalBlue = 0;
                    if (totalBlue > 255)
                        totalBlue = 255;
                    pixels2[i, j].Blue = (byte)totalBlue;


                    totalGreen = totalGreen / divider;
                    if (totalGreen < 0)
                        totalGreen = 0;
                    if (totalGreen > 255)
                        totalGreen = 255;
                    pixels2[i, j].Green = (byte)totalGreen;

                    totalRed = totalRed / divider;
                    if (totalRed < 0)
                        totalRed = 0;
                    if (totalRed > 255)
                        totalRed = 255;
                    pixels2[i, j].Red = (byte)totalRed;
                    //pixels2[i, j].Alpha = 255;
                    

                }
            }
           return pixels2;
            
        }







        public static void DeltaX()
        {
            
            long width = CurrentState.currentPixels.GetLongLength(0); ///width
            long height = CurrentState.currentPixels.GetLongLength(1);  //height
            for (int i = 0; i < width-1; i++)
            {
                for (int j = 0; j < height-1; j++)
                {
                    int delta = CurrentState.currentPixels[i, j].Blue - CurrentState.currentPixels[i+1, j].Blue;
                    if (delta < 0)
                        delta = -delta;

                    CurrentState.currentPixels[i, j].Blue = (byte) delta;


                    delta = CurrentState.currentPixels[i, j].Green - CurrentState.currentPixels[i+1, j] .Green;
                    if (delta < 0)
                        delta = -delta;
                    CurrentState.currentPixels[i, j].Green = (byte)delta;

                    delta = CurrentState.currentPixels[i, j].Red - CurrentState.currentPixels[i+1, j ].Red;
                    if (delta < 0)
                        delta = -delta;
                    CurrentState.currentPixels[i, j].Red = (byte)delta;
                    

                }
            }

        }

        public static void DeltaY()
        {
            for (int i = 0; i < CurrentState.currentPixels.GetLength(0)-1; i++)
            {
                for (int j = 0; j < CurrentState.currentPixels.GetLength(1) ; j++)
                {
                    int delta = CurrentState.currentPixels[i, j].Blue - CurrentState.currentPixels[i+1, j ].Blue;
                    if (delta < 0)
                        delta = -delta;
                    CurrentState.currentPixels[i, j].Blue = (byte)delta;


                    delta = CurrentState.currentPixels[i, j].Green - CurrentState.currentPixels[i+1, j ].Green;
                    if (delta < 0)
                        delta = -delta;
                    CurrentState.currentPixels[i, j].Green = (byte)delta;

                    delta = CurrentState.currentPixels[i, j].Red - CurrentState.currentPixels[i+1, j ].Red;
                    if (delta < 0)
                        delta = -delta;
                    CurrentState.currentPixels[i, j].Red = (byte)delta;

                }
            }
        }

       

        public static void EdgeDetection2()
        {
            CurrentState.currentPixels = ApplyMatrix(edgeDetection2,  1);
        }

        public static void EdgeDetection3()
        {
            CurrentState.currentPixels = ApplyMatrix(edgeDetection3,  1);
        }

        public static void EdgeDetaction4()
        {
            CurrentState.currentPixels = ApplyMatrix(EdgeDetectiın4, WeightedMeanFilterDivider);
        }

        public static  void SobelEdgeDetection()
        {
            PixelColor[,] pixels2 = new PixelColor[CurrentState.currentPixels.GetLength(0), CurrentState.currentPixels.GetLength(1)];
            Array.Copy(CurrentState.currentPixels, pixels2, CurrentState.currentPixels.Length); 
            PixelColor[,] pixelsX = ApplyMatrix(SobelX, 1);
            PixelColor[,] pixelsY = ApplyMatrix(SobelY, 1);

            for (int i = 0; i < CurrentState.currentPixels.GetLength(0) ; i++)
            {
                for (int j = 0; j < CurrentState.currentPixels.GetLength(1); j++)
                {
                    pixels2[i, j].Red = GetSquaredValue(pixelsX[i, j].Red, pixelsY[i, j].Red);
                    pixels2[i, j].Green = GetSquaredValue(pixelsX[i, j].Green, pixelsY[i, j].Green);
                    pixels2[i, j].Blue = GetSquaredValue(pixelsX[i, j].Blue, pixelsY[i, j].Blue);

                }
            }
            CurrentState.currentPixels = pixels2;
        }

        public static byte GetSquaredValue(byte pixelX,byte pixelY)
        {
            int squareRoot = (int)Math.Sqrt(pixelX * pixelX + pixelY * pixelY);
            if (squareRoot > 255)
                return 255;
            else
                return (byte)squareRoot;
        }
        public static void Sharpen()
        {
            CurrentState.currentPixels = ApplyMatrix(sharpen, 1);
        }


        public static void BoxBlur()
        {
            CurrentState.currentPixels = ApplyMatrix(boxBlur, boxBlurDivider);
        }

        public static void GaussianBlur()
        {
            CurrentState.currentPixels = ApplyMatrix(gaussianBlur,  GaussianBlurDivider);
        }

    }


}
public enum ConvolutionType
{
    EdgeDetection1,
    EdgeDetection2,
    EdgeDetection3,
    Sharpen,
    BoxBlur,
    GaussianBlur
}

