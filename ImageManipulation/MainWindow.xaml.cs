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
using System.IO;
using System.Collections.Generic;

namespace ImageManipulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<string> fileList;
        DockPanel maximiseStackPanel;
        TabItem propertiesTabItem = null;

        Image myImage;
        public MainWindow()
        {
            InitializeComponent();
            buttonSaveImage.IsEnabled = false;
        }

        private void buttonLoadImage_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                OpenImage(openFileDialog.FileName);
            }

        }

        private void OpenImage(string fileName)
        {
            
            CurrentState.mainWindow = this;

            myImage = new Image();
            
            MyImageTools.SetCurrentState(fileName, myImage);
            MyImageTools.ConstructPixelBufferFromFile();

            zoomBorder.Child = myImage;
            myImage.Source = MyImageTools.WritePixelsToBitmap() as BitmapSource;

            if (tabConrtol1.Items.Contains(propertiesTabItem))
            {
                tabConrtol1.Items.Remove(propertiesTabItem);
            }
            propertiesTabItem = new TabItem();
            propertiesTabItem.Header = "Properties";
            propertiesTabItem.Content = new ImagePropertiesUC();
            
            tabConrtol1.Items.Add(propertiesTabItem);
            buttonSaveImage.IsEnabled = true;
        }

       


        private void buttonSaveImage_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                if (saveFileDialog.FileName != null)
                    MyImageTools.SaveImage(saveFileDialog.FileName + ".png");
            }
        }

        private void MaximiseToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            myDockPanel.Children.Remove(MenuStackPanel);
            
            myGrid.Children.Remove(zoomBorder);

            maximiseStackPanel = new DockPanel();
            maximiseStackPanel.Children.Add(MenuStackPanel);
            
            maximiseStackPanel.Children.Add(zoomBorder);
            this.Content = maximiseStackPanel;
           

        }

        private void MaximiseToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            maximiseStackPanel.Children.RemoveRange(0, 2);
            myDockPanel.Children.Insert(0, MenuStackPanel);
            
            myGrid.Children.Insert(0, zoomBorder);
            this.Content = myDockPanel;
        }

        private void buttonNextImage_Click(object sender, RoutedEventArgs e)
        {
            MoveNextImage();
        }

        private void MoveNextImage()
        {
            CreateFileInfos();

            int i;
            for (i = 0; i < fileList.Count; i++)
            {

                if (fileList[i] == CurrentState.fullfileName)
                {
                    break;
                }
            }
            if (i == fileList.Count - 1)
            {
                i = 0;
            }
            else
                i++;
            MyImageTools.SetCurrentState(fileList[i], myImage);
            OpenImage(CurrentState.fullfileName);
        }

        private void buttonPreviousImage_Click(object sender, RoutedEventArgs e)
        {
            MovePreviousImage();
        }

        private void MovePreviousImage()
        {
            CreateFileInfos();

            int i;
            for (i = 0; i < fileList.Count; i++)
            {

                if (fileList[i] == CurrentState.fullfileName)
                {
                    break;
                }
            }
            if (i == 0 )
            {
                i = fileList.Count-1;
            }
            else
                i--;
            MyImageTools.SetCurrentState(fileList[i], myImage); 
            OpenImage(CurrentState.fullfileName);
        }

        private void CreateFileInfos()
        {
            DirectoryInfo dirInfo = System.IO.Directory.GetParent(CurrentState.fullfileName);


            if (fileList == null || Path.GetDirectoryName(fileList[0]) != dirInfo.Name )
            {
                if (fileList == null)
                    fileList = new List<string>();

                fileList.Clear();

                FileInfo[] files = dirInfo.GetFiles("*.*");
                foreach (FileInfo f in files)
                {
                    string xx = Path.GetExtension(f.Name).ToLower();
                    
                    if (Path.GetExtension(f.Name).ToLower() == ".jpg" ||
                        Path.GetExtension(f.Name).ToLower() == ".jpeg" ||
                        Path.GetExtension(f.Name).ToLower() == ".jpe" ||
                        Path.GetExtension(f.Name).ToLower() == ".jfif" ||
                        Path.GetExtension(f.Name).ToLower() == ".bmp" ||
                        Path.GetExtension(f.Name).ToLower() == ".dib" ||
                        Path.GetExtension(f.Name).ToLower() == ".gif" || //?
                        Path.GetExtension(f.Name).ToLower() == ".ico" || //? problem ?
                        Path.GetExtension(f.Name).ToLower() == ".png" ||
                        Path.GetExtension(f.Name).ToLower() == ".tiff" ||
                        Path.GetExtension(f.Name).ToLower() == ".tif" ||
                        Path.GetExtension(f.Name).ToLower() == ".wmp"
                        )
                    {
                        fileList.Add(f.FullName);
                    }
                }
            }
        }

        

    }
}

