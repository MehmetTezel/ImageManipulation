using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Windows.Data;
using ImageManipulation.CoreNS;

using ImageManipulation.TabsNS.ImagePropertyNS;

namespace ImageManipulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        TabItem propertiesTabItem=null;
        public MainWindow()
        {
            InitializeComponent();

        }
        private void buttonLoadImage_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {

                Uri uri = new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute);
                BitmapImage bitmapImage = new BitmapImage(uri);
                CurrentState.pixels = new PixelColor[bitmapImage.PixelWidth, bitmapImage.PixelHeight];
                CurrentState.fullfileName = openFileDialog.FileName;
                CurrentState.bitmapImage = bitmapImage;
                CurrentState.image = image1;
                CurrentState.mainWindow = this;

                MyImageTools.CopyBitmapToPixelsBuffer();

                //MyImageTools.ToGray2(pixels);
                image1.Source = MyImageTools.WritePixelsToBitmap() as BitmapSource;

                if (tabConrtol1.Items.Contains(propertiesTabItem))
                {
                    tabConrtol1.Items.Remove(propertiesTabItem);
                }
                propertiesTabItem = new TabItem();
                propertiesTabItem.Header = "Properties";
                propertiesTabItem.Content = new ImagePropertiesUC();

                tabConrtol1.Items.Add(propertiesTabItem);

            }

        }


        private void image1_MouseWheel(object sender, MouseWheelEventArgs e)
        {


            Matrix renderMatrix = ((Image)sender).RenderTransform.Value;

            if (e.Delta > 0)
            {

                renderMatrix.ScaleAt(1.2, 1.2, e.GetPosition(this).X, e.GetPosition(this).Y);
            }
            else
            {
                renderMatrix.ScaleAt(1.0 / 1.2, 1.0 / 1.2, e.GetPosition(this).X, e.GetPosition(this).Y);

            }

            ((Image)sender).RenderTransform = new MatrixTransform(renderMatrix);
        }


    }
}

