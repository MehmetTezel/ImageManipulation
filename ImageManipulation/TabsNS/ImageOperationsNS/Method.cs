using System;
using ImageManipulation.CoreNS;
using System.Collections.ObjectModel;

namespace ImageManipulation.TabsNS.ImageOperationsNS
{
    public class Method
    {
        private string name;
        private string description;
        private string sliderValues;
        private short redSliderValue;
        private short greenSliderValue;
        private short blueSliderValue;


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != null)
                    name = value;
                else
                    name = "";
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                if (value != null)
                    description = value;
                else
                    description = "";
            }
        }

        public string SliderValues
        {
            get { return sliderValues; }
            set
            {
                if (value != null)
                    sliderValues = value;
                else
                    sliderValues = "";
            }
        }

        public short RedSliderValue
        {
            get { return redSliderValue; }
            set { redSliderValue = value; }
        }

        public short GreenSliderValue
        {
            get { return greenSliderValue; }
            set { greenSliderValue = value; }
        }
        public short BlueSliderValue
        {
            get { return blueSliderValue; }
            set { blueSliderValue = value; }
        }
    }

    class MethodData
    {

        public static ObservableCollection<Method> GetBuiltInMethods()
        {
            ObservableCollection<Method> methodList = new ObservableCollection<Method>();

            Method method = new Method();
            method.Name = "ToOneBit";
            method.Description = "";
            methodList.Add(method);

            method = new Method();
            method.Name = "ToGray";
            method.Description = "";
            methodList.Add(method);


            method = new Method();
            method.Name = "ReverseColor";
            method.Description = "";
            methodList.Add(method);

            method = new Method();
            method.Name = "RemoveWeakColors";
            method.Description = "";
            methodList.Add(method);

            method = new Method();
            method.Name = "Square";
            method.Description = "";
            methodList.Add(method);

            method = new Method();
            method.Name = "SquareRoot";
            method.Description = "";
            methodList.Add(method);

            method = new Method();
            method.Name = "Edge Detection 2";
            method.Description = "";
            methodList.Add(method);

            method = new Method();
            method.Name = "Edge Detection 3";
            method.Description = "";
            methodList.Add(method);

            //method = new Method();
            //method.Name = "DeltaX";
            //method.Description = "";
            //methodList.Add(method);


            //method = new Method();
            //method.Name = "DeltaY";
            //method.Description = "";
            //methodList.Add(method);

            method = new Method();
            method.Name = "Sharpen";
            method.Description = "";
            methodList.Add(method);

            //method = new Method();
            //method.Name = "Sharpen 2";
            //method.Description = "";
            //methodList.Add(method);

            method = new Method();
            method.Name = "BoxBlur";
            method.Description = "";
            methodList.Add(method);

            method = new Method();
            method.Name = "GaussianBlur";
            method.Description = "";
            methodList.Add(method);

            method = new Method();
            method.Name = "Edge Detection 4";
            method.Description = "";
            methodList.Add(method);

            
            method = new Method();
            method.Name = "Histogram Equalize";
            method.Description = "";
            methodList.Add(method);
            

            method = new Method();
            method.Name = "Sobel Edge Detection";
            method.Description = "";
            methodList.Add(method);


            method = new Method();
            method.Name = "Contrast";
            method.Description = "";
            methodList.Add(method);

            return methodList;
        }

    }
}
