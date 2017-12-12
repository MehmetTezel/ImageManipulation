using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ImageManipulation.CoreNS
{
    class CurrentState
    {
        public static Image image;
        public static BitmapImage bitmapImage;
        public static string fullfileName  ;
        public static MainWindow mainWindow;
        public static PixelColor[,] originalPixels; // original bitmap
        public static PixelColor[,] currentPixels; // current pixels
        public static PixelColor[,] pixelsBeforeColorEnhancing; 
        public static void SetFeilds(Image img, BitmapImage bmpImg, string fileName,MainWindow mainWnd )
        {
            image = img;
            bitmapImage = bmpImg;
            fullfileName = fileName;
            mainWindow = mainWnd;
        }

      
    }
}
