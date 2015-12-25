using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageManipulation.TabsNS.ImagePropertyNS
{

    public class ImageProperties : INotifyPropertyChanged
    {

        string fullFileName { get; set; }

        double mainWindowWidth { get; set; }
        double mainWindowHeight { get; set; }
        double deviceIndependentWidth { get; set; }
        double deviceIndependentHeight { get; set; }

        int bitsPerPixel { get; set; }
        int pixelHeight { get; set; }
        int pixelWidth { get; set; }
        double dpiX { get; set; }
        double dpiY { get; set; }
        double maxWidth { get; set; }
        double maxHeight { get; set; }
        double opacity { get; set; }




        public string FullFileName
        {
            get { return fullFileName; }
            set
            {
                fullFileName = value;
                RaisePropertyChanged("FullFileName");
            }

        }

        public double MainWindowWidth
        {
            get { return mainWindowWidth; }
            set
            {
                mainWindowWidth = value;
                RaisePropertyChanged("MainWindowWidth");
            }

        }

        public double MainWindowHeight
        {
            get { return mainWindowHeight; }
            set
            {
                mainWindowHeight = value;
                RaisePropertyChanged("MainWindowHeight");
            }
        }

        public double DeviceIndependentWidth
        {
            get { return deviceIndependentWidth; }
            set
            {
                deviceIndependentWidth = value;
                RaisePropertyChanged("DeviceIndependentWidth");
            }
        }

        public double DeviceIndependentHeight
        {
            get { return deviceIndependentHeight; }
            set
            {
                deviceIndependentHeight = value;
                RaisePropertyChanged("DeviceIndependentHeight");
            }
        }

        public int BitsPerPixel
        {
            get { return bitsPerPixel; }
            set
            {
                bitsPerPixel = value;
                RaisePropertyChanged("BitsPerPixel");
            }
        }

        public int PixelHeight { get; set; }
        public int PixelWidth { get; set; }
        public double DpiX { get; set; }
        public double DpiY { get; set; }
        public double MaxWidth { get; set; }
        public double MaxHeight { get; set; }
        public double Opacity { get; set; }

        public  ImageProperties(BitmapImage bmp, Image img, string fileName, MainWindow mainWindow)
        {
            FullFileName = fileName;
            MainWindowWidth = mainWindow.Width;
            MainWindowHeight = mainWindow.Height;
            DeviceIndependentWidth = bmp.Width;
            DeviceIndependentHeight = bmp.Height;
            BitsPerPixel = bmp.Format.BitsPerPixel;
            PixelHeight = bmp.PixelHeight;
            PixelWidth = bmp.PixelWidth;
            DpiX = bmp.DpiX;
            DpiY = bmp.DpiY;
            MaxHeight = img.MaxHeight;
            MaxWidth = img.MaxWidth;
            Opacity = img.Opacity;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
