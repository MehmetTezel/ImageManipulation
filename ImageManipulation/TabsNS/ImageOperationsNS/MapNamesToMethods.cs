using ImageManipulation.CoreNS;
using System;

namespace ImageManipulation.TabsNS.ImageOperationsNS
{
    public static class MapNamesToMethods
    {

        public static void MapName(Method method)
        {

            string methodName = method.Name;
            if(methodName == "ToOneBit")
            {
                MyImageTools.ToOneBit();
                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();
                
            }
            else
            if (methodName == "ToGray")
            {
                MyImageTools.ToGray();
                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                
            }

            else
            if (methodName == "ReverseColor")
            {
                MyImageTools.ReverseColor();
                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                
            }
            else
            if (methodName == "RemoveWeakColors")
            {
                MyImageTools.RemoveWeakColors();
                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                
            }
            else
            if (methodName == "Square")
            {
                MyImageTools.Square();
                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                
            }
            else
            if (methodName == "SquareRoot")
            {
                MyImageTools.SquareRoot();
                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                
            }

            else
            if (methodName == "Edge Detection 2")
            {
                KernelMatrix.EdgeDetection2();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                
            }
            else
            if (methodName == "Edge Detection 3")
            {
                KernelMatrix.EdgeDetection3();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                
            }
            else
            if (methodName == "DeltaX")
            {
                KernelMatrix.DeltaX();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                
            }
            else
            if (methodName == "DeltaY")
            {
                KernelMatrix.DeltaY();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                
            }

            else
            if (methodName == "Sharpen")
            {
                KernelMatrix.Sharpen();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                
            }
            else
            if (methodName == "BoxBlur")
            {
                KernelMatrix.BoxBlur();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                
            }
            else
            if (methodName == "GaussianBlur")
            {
                KernelMatrix.GaussianBlur();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                
            }
            else
            if (methodName == "Edge Detection 4")
            {
                KernelMatrix.EdgeDetaction4();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                
            }

            
            else
            if (methodName == "Sobel Edge Detection")
            {
                KernelMatrix.SobelEdgeDetection();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();
            }
            else
            if (methodName == "Histogram Equalize")
            {
                Histogram histogram = new Histogram();
                histogram.Equalise();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();
            }
            else
            if (methodName == "Contrast")
            {
                Contrast contrast = new Contrast();
                contrast.AdjustContrast();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();
            }
            Array.Copy(CurrentState.currentPixels,CurrentState.pixelsBeforeColorEnhancing,  CurrentState.currentPixels.Length);
        }
    }
}
