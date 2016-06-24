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

            if (methodName == "ToGray2")
            {
                MyImageTools.ToGray2();
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

            if (methodName == "Logaritma")
            {
                MyImageTools.Logaritma();
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

        }
    }
}
