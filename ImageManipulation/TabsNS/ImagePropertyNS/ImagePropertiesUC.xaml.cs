using System.Windows.Controls;
using ImageManipulation.CoreNS;
namespace ImageManipulation.TabsNS.ImagePropertyNS
{
    /// <summary>
    /// Interaction logic for ImagePropertiesUCxaml.xaml
    /// </summary>
    public partial class ImagePropertiesUC : UserControl
    {
        public ImageProperties imageProperties;
        public ImagePropertiesUC()
        {
            InitializeComponent();
            imageProperties = new ImageProperties(CurrentState.bitmapImage,CurrentState.image,CurrentState.fullfileName,CurrentState.mainWindow);
            this.DataContext = imageProperties;
        }
    }
}
