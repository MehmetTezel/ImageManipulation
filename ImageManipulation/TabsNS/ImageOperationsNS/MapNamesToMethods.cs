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
            if (methodName == "ToGray2")
            {
                MyImageTools.ToGray2();
                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }
            if (methodName == "ToGray2")
            {
                MyImageTools.ToGray2();
                CurrentState.image.Source = MyImageTools.WritePixelsToBitmap();

                return;
            }


        }
    }
}
