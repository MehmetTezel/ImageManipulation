using System.Windows;
using System.Windows.Controls;
using ImageManipulation.CoreNS;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ImageManipulation.TabsNS.ImageOperationsNS
{
    /// <summary>
    /// Interaction logic for AddMethodsUC.xaml
    /// </summary>
    public partial class AddMethodsUC : UserControl
    {

        private ObservableCollection<Method> methods;
        public AddMethodsUC()
        {
            InitializeComponent();
            SetSliderInitialValues();

            methods = MethodData.GetBuiltInMethods();
            ListBoxWithMethods.ItemsSource = methods;
            ListBoxWithMethods.Items.SortDescriptions.Add(
            new System.ComponentModel.SortDescription("Name",
            System.ComponentModel.ListSortDirection.Ascending));

        }





        private PixelParameter GetPixelColorsFromSliders()
        {
            PixelParameter pixelParam = new PixelParameter();
            pixelParam.Blue = blueSlider.Value;
            pixelParam.Green = greenSlider.Value;
            pixelParam.Red = redSlider.Value;




            GetColorSwitches(pixelParam);

            return pixelParam;
        }

        private void GetColorSwitches(PixelParameter pixelParam)
        {
            if (NoSwitching.IsChecked == true)
            {
                return;
            }
            else
            {
                pixelParam.EnableSwitchColors = true;
            }

            if (SwitchGreenAndBlue.IsChecked == true)
            {
                pixelParam.SwitchGreenAndBlue = true;
            }
            if (SwitchRedAndBlue.IsChecked == true)
            {
                pixelParam.SwitchRedAndBlue = true;
            }

            if (switchRedAndGreen.IsChecked == true)
            {
                pixelParam.SwitchGreenAndRed = true;
            }

        }



        private void SetSliderInitialValues()
        {
            redSlider.Value = greenSlider.Value = blueSlider.Value = CoreNS.Controls.Slider.SliderDefaults.InitialValue;
            redSlider.Maximum = greenSlider.Maximum = blueSlider.Maximum = CoreNS.Controls.Slider.SliderDefaults.Maximum;
        }
    

        private void blueSlider_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangePixels();
        }


        private void greenSlider_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangePixels();
        }

        private void redSlider_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChangePixels();
        }

        private void ChangePixels()
        {
            if (CurrentState.image == null)
                return;
            MyImageTools.ChangePixelColor(GetPixelColorsFromSliders());
        }


        private void resetOriginalPicture_Click(object sender, RoutedEventArgs e)
        {
            SetSlidersToDefaultValues();
            MyImageTools.ResetOriginalPicture();
        }

        private void SetSlidersToDefaultValues()
        {
            redSlider.Value = greenSlider.Value = blueSlider.Value = ImageManipulation.CoreNS.Controls.Slider.SliderDefaults.InitialValue;

        }

        private void SwitchGreenAndBlue_Checked(object sender, RoutedEventArgs e)
        {
            ChangePixels();
        }

        private void SwitchRedAndBlue_Checked(object sender, RoutedEventArgs e)
        {
            ChangePixels();
        }

        private void switchRedAndGreen_Checked(object sender, RoutedEventArgs e)
        {
            ChangePixels();
        }

        private void ListBoxWithMethods_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (ListBoxWithMethods.SelectedItem == null)
                return;
            if (CurrentState.image == null)
                return;
            Method selectedMethod = (Method)ListBoxWithMethods.SelectedItem;
            Cursor originalCursor = this.Cursor;
            this.Cursor = Cursors.Wait;
            MapNamesToMethods.MapName(selectedMethod);
            this.Cursor = originalCursor;
            
           
        }

    }
}
