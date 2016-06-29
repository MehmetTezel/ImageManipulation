using ImageManipulation.CoreNS;

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
                return;
            }

            if (methodName == "ToGray")
            {
                MyImageTools.ToGray();
                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }


            if (methodName == "ReverseColor")
            {
                MyImageTools.ReverseColor();
                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }
            if (methodName == "RemoveWeakColors")
            {
                MyImageTools.RemoveWeakColors();
                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }

            if (methodName == "Square")
            {
                MyImageTools.Square();
                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }

            if (methodName == "SquareRoot")
            {
                MyImageTools.SquareRoot();
                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }


            if (methodName == "Edge Detection 1")
            {
                KernelMatrix.EdgeDetection1();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }

            if (methodName == "Edge Detection 2")
            {
                KernelMatrix.EdgeDetection2();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }

            if (methodName == "Edge Detection 3")
            {
                KernelMatrix.EdgeDetection3();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }

            if (methodName == "DeltaX")
            {
                KernelMatrix.DeltaX();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }

            if (methodName == "DeltaY")
            {
                KernelMatrix.DeltaY();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }


            if (methodName == "Sharpen")
            {
                KernelMatrix.Sharpen();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }
            if (methodName == "Sharpen 2")
            {
                KernelMatrix.Sharpen2();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }

            
            if (methodName == "BoxBlur")
            {
                KernelMatrix.BoxBlur();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }

            if (methodName == "GaussianBlur")
            {
                KernelMatrix.GaussianBlur();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }
            
            if (methodName == "Edge Detection 4")
            {
                KernelMatrix.EdgeDetaction4();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }

            

            if (methodName == "Sobel Edge Detection")
            {
                KernelMatrix.SobelEdgeDetection();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }

            if (methodName == "Histogram Equalize")
            {
                Histogram histogram = new Histogram();
                histogram.Equalise();

                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }

        }
    }
}
