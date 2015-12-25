using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ImageManipulation.CoreNS;
using ImageManipulation.CoreNS.Controls;
namespace ImageManipulation.TabsNS.ImageOperationsNS
{
    /// <summary>
    /// Interaction logic for AddMethodsUC.xaml
    /// </summary>
    public partial class AddMethodsUC : UserControl
    {
        private ObservableCollection<Method> methods;
        private ObservableCollection<Method> filteredMethods = new ObservableCollection<Method>();

        private ObservableCollection<Method> usedMethods = new ObservableCollection<Method>();

        public AddMethodsUC()
        {
            InitializeComponent();
            SetSliders();
            methods = MethodData.GetTasks();
            ListBoxWithMethods.ItemsSource = methods;
            ListBoxWithMethods.Items.SortDescriptions.Add(
            new System.ComponentModel.SortDescription("Name",
            System.ComponentModel.ListSortDirection.Ascending));

            ListBoxUsedMethodList.ItemsSource = usedMethods;
            ComboBoxFilters.ItemsSource = GettingTaskFilters();
            CreateUniformGrid();
            if (ListBoxWithMethods.Items.Count == 0)
            {
                ButtonDelete.IsEnabled = false;
                ButtonUpdate.IsEnabled = false;
            }

        }
        public void CreateUniformGrid()
        {
            for (int i = 0; i < 25; i++)
            {
                TextBox tb = new TextBox();
                tb.Height = 23;
                tb.Width = 23;
                tb.Margin = new Thickness(2);
                uniformGrid.Children.Add(tb);

            }
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxName.Text == "" || TextBoxName.Text == "Fill this field")
            {
                TextBoxName.Text = "Fill this field";
                TextBoxName.Background = Brushes.Gold;
            }
            else
            {
                SetMethodSliderValuesFromSliders((Method)ListBoxWithMethods.SelectedItem);
                MethodData.UpdateTask((Method)ListBoxWithMethods.SelectedItem);
                Filtering();
            }

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxAddName.Text == "" || TextBoxAddName.Text == "Fill this field")
            {
                TextBoxAddName.Text = "Fill this field";
                TextBoxAddName.Background = Brushes.Gold;
            }
            else
            {
                TextBoxAddName.Background = Brushes.White;
                Method method = new Method();
                method.Name = TextBoxAddName.Text;
                method.Description = TextBoxAddDescription.Text;
                if (CheckBoxAddIsImportant.IsChecked != null)
                    method.IsImportant = (bool)CheckBoxAddIsImportant.IsChecked;

                SetMethodSliderValuesFromSliders(method);
                methods.Add(method);
                MethodData.AddTask(method);
                Filtering();
                if (ComboBoxFilters.SelectedIndex == -1)
                {
                    ButtonDelete.IsEnabled = true;
                    ButtonUpdate.IsEnabled = true;
                }
               TextBoxAddName.Text = string.Empty;
               TextBoxAddDescription.Text = string.Empty;
               CheckBoxAddIsImportant.IsChecked = false;
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            MethodData.DeleteTask((Method)ListBoxWithMethods.SelectedItem);
            methods.Remove((Method)ListBoxWithMethods.SelectedItem);
            if (ListBoxWithMethods.Items.Count == 0)
            {
                ButtonDelete.IsEnabled = false;
                ButtonUpdate.IsEnabled = false;
            }
            Filtering();
        }

        private void ComboBoxFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtering();
        }

        private List<MethodFilter> GettingTaskFilters()
        {
            List<MethodFilter> tf = new List<MethodFilter>();

            AllTasksFilter allTasksFilter = new AllTasksFilter();

            JustImportanTasksFilter justImportanTasksFilter = new JustImportanTasksFilter();

            tf.Add(allTasksFilter);

            tf.Add(justImportanTasksFilter);
            return tf;
        }

        private void Filtering()
        {
            if (filteredMethods.Count != 0) filteredMethods.Clear();

            if (ComboBoxFilters.SelectedIndex != -1)
            {
                foreach (var method in methods)
                    if (((MethodFilter)ComboBoxFilters.SelectedItem).IsMatched(method))
                        filteredMethods.Add(method);

                ListBoxWithMethods.ItemsSource = filteredMethods;
                if(filteredMethods.Count==0)
                {
                    ButtonDelete.IsEnabled = false;
                    ButtonUpdate.IsEnabled = false;
                }
                else
                {
                    ButtonDelete.IsEnabled = true;
                    ButtonUpdate.IsEnabled = true;
                }
            }
        }

        private void ListBoxWithMethods_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (ListBoxWithMethods.SelectedItem == null)
                return;
            if (CurrentState.image == null)
                return;
            Method selectedMethod = (Method)ListBoxWithMethods.SelectedItem;
            usedMethods.Add(selectedMethod);
            MapNamesToMethods.MapName(selectedMethod);
        }

        private void resetSliders_Click(object sender, RoutedEventArgs e)
        {
            redSlider.Value= greenSlider.Value= blueSlider.Value = ControlDefaults.Slider.Value;
            
        }

        private void resetSlidersSW_Click(object sender, RoutedEventArgs e)
        {
            strongSlider.Value = middleSlider.Value = weakSlider.Value = ControlDefaults.Slider.Value;
        }


        private void ResetSliderValues()
        {
            redSlider.Value = greenSlider.Value = blueSlider.Value = 
            strongSlider.Value = middleSlider.Value = weakSlider.Value= ControlDefaults.Slider.Value;
             
        }
        private void SetSliders()
        {
            redSlider.Maximum = greenSlider.Maximum = blueSlider.Maximum = 
            strongSlider.Maximum = middleSlider.Maximum = weakSlider.Maximum= ControlDefaults.Slider.Maximum ;

            redSlider.Width = blueSlider.Width = greenSlider.Width =
            strongSlider.Width = weakSlider.Width = middleSlider.Width = ControlDefaults.Slider.Width;


            redSlider.Value = greenSlider.Value = blueSlider.Value = 
            strongSlider.Value = middleSlider.Value = weakSlider.Value = ControlDefaults.Slider.Value;

             
        }

        private void SetMethodSliderValuesFromSliders(Method method)
        {
          
            method.BlueSliderValue = (short)blueSlider.Value;
            method.GreenSliderValue = (short)greenSlider.Value;
            method.RedSliderValue = (short)redSlider.Value;

            method.StrongSliderValue = (short)strongSlider.Value;
            method.MiddleSliderValue = (short)middleSlider.Value;
            method.WeakSliderValue = (short)weakSlider.Value;
            method.ConstructSliderValues();
        }

        private PixelColor GetPixelColorsFromSliders()
        {
            PixelColor pixelColor = new PixelColor();

            pixelColor.Blue = (byte) blueSlider.Value ;
            pixelColor.Green = (byte)greenSlider.Value;
            pixelColor.Red = (byte)redSlider.Value ;

            return pixelColor;
        }




        private void ListBoxWithMethods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxWithMethods.SelectedItems.Count == 0)
                return;
            Method method = (Method)((ListBox)(sender)).SelectedItem;
            ModifySliderValuesFromMethod(method);
            CopySellectedItemToAddPanel();
        }

        private void ModifySliderValuesFromMethod(Method method)
        {
            
            blueSlider.Value = method.BlueSliderValue;
            greenSlider.Value = method.GreenSliderValue;
            redSlider.Value = method.RedSliderValue;

            strongSlider.Value = method.StrongSliderValue;
            middleSlider.Value = method.MiddleSliderValue;
            weakSlider.Value = method.WeakSliderValue;

        }

        private void CopySellectedItemToAddPanel()
        {
            TextBoxAddName.Text = TextBoxName.Text;
            TextBoxAddDescription.Text = TextBoxDescription.Text;
            if (CheckBoxAddIsImportant.IsChecked != null)
                CheckBoxAddIsImportant.IsChecked = CheckBoxIsImportant.IsChecked;

        }

        private void blueSlider_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (CurrentState.image == null)
                return;
            MyImageTools.ChangePixelColor(GetPixelColorsFromSliders());
        }


        private void greenSlider_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (CurrentState.image == null)
                return;

            MyImageTools.ChangePixelColor(GetPixelColorsFromSliders());
        }

        private void redSlider_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (CurrentState.image == null)
                return;

            MyImageTools.ChangePixelColor(GetPixelColorsFromSliders());
        }

        private void checkBoxBlueSlider_Checked(object sender, RoutedEventArgs e)
        {
            blueSlider.IsEnabled = false;
        }

        private void checkBoxGreenSlider_Checked(object sender, RoutedEventArgs e)
        {
            greenSlider.IsEnabled = false;
        }

        private void checkBoxRedSlider_Checked(object sender, RoutedEventArgs e)
        {
            redSlider.IsEnabled = false;
        }

        private void checkBoxStrongSlider_Checked(object sender, RoutedEventArgs e)
        {
            strongSlider.IsEnabled = false;
        }

        private void checkBoxMiddleSlider_Checked(object sender, RoutedEventArgs e)
        {
            middleSlider.IsEnabled = false;
        }

        private void checkBoxWeakSlider_Checked(object sender, RoutedEventArgs e)
        {
            weakSlider.IsEnabled = false;
        }

        private void checkBoxBlueSlider_Unchecked(object sender, RoutedEventArgs e)
        {
            blueSlider.IsEnabled = true;
        }

        private void checkBoxGreenSlider_Unchecked(object sender, RoutedEventArgs e)
        {
            
            greenSlider.IsEnabled = true;
        }

        private void checkBoxRedSlider_Unchecked(object sender, RoutedEventArgs e)
        {
            redSlider.IsEnabled = true;
        }

        private void checkBoxStrongSlider_Unchecked(object sender, RoutedEventArgs e)
        {
            strongSlider.IsEnabled = true;
        }

        private void checkBoxMiddleSlider_Unchecked(object sender, RoutedEventArgs e)
        {
            middleSlider.IsEnabled = true;
        }

        private void checkBoxWeakSlider_Unchecked(object sender, RoutedEventArgs e)
        {
            weakSlider.IsEnabled = true;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            colorSwitchingGroupBox.IsEnabled = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            colorSwitchingGroupBox.IsEnabled = false;
        }
    }
}
