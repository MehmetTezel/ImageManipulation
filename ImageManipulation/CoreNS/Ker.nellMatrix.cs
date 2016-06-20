namespace ImageManipulation.CoreNS
{
    class KernelMatrix
    {
       static int [,] edgeDetection1 = new int[,] { { 1, 0,-1 }, 
                                                    { 0, 0, 0 }, 
                                                    {-1, 0, 1 } };

       static int[,] edgeDetection2 = new int[,] { { 0, 1, 0 },
                                                    { 1,-4, 1 },
                                                    { 0, 1, 0 } };

        static int[,] edgeDetection3 = new int[,] { {-1,-1,-1 },
                                                    {-1, 8,-1 },
                                                    {-1,-1,-1 } };

        static int[,] Sharpen = new int[,]        { { 0,-1, 0 },
                                                    {-1, 5,-1 },
                                                    { 0,-1, 0 } };
        static int BoxBlurDivider = 9;
        static int[,] BoxBlur = new int[,]        { { 1, 1, 1 },
                                                    { 1, 1, 1 },
                                                    { 1, 1, 1 } };
        static int GaussianBlurDivider = 16;
        static int[,] GaussianBlur =   new int[,] { { 1, 2, 1 },
                                                    { 2, 4, 2 },
                                                    { 1, 2, 1 } };

        static void ApplyMatrix(int[,], PixelColor[,] pixels, ConvolutionType)
        {

        }

       
    }
    enum ConvolutionType
    {
        EdgeDetection1,
        EdgeDetection2,
        EdgeDetection3,
        Sharpen,
        BoxBlur,
        GaussianBlur
    }
}
