using System;
using ImageManipulation.CoreNS;
namespace ImageManipulation.TabsNS.ImageOperationsNS
{
    public class Method
    {
        private string name;
        private string description;
        private bool isImportant;

        private string sliderValues;
        private short redSliderValue;
        private short greenSliderValue;
        private short blueSliderValue;

        private short strongSliderValue;
        private short middleSliderValue;
        private short weakSliderValue;

        private Guid id;

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
        public bool IsImportant
        {
            get { return isImportant; }
            set { isImportant = value; }
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

        public short StrongSliderValue
        {
            get { return strongSliderValue; }
            set { strongSliderValue = value; }
        }
        public short MiddleSliderValue
        {
            get { return middleSliderValue; }
            set { middleSliderValue = value; }
        }
        public short WeakSliderValue
        {
            get { return weakSliderValue; }
            set { weakSliderValue = value; }
        }

        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }

        public Method(string _name, string _description, DateTime _expirationDate, bool _isImportant)
        {
            id = Guid.NewGuid();
            name = _name;
            description = _description;
            isImportant = _isImportant;
        }

        public Method()
        {
            id = Guid.NewGuid();
        }

        public  void ConvertSliderValues()
        {
          string[] numbers =  SliderValues.Split(' ');
            BlueSliderValue = short.Parse(numbers[0]);
            GreenSliderValue = short.Parse(numbers[1]);
            RedSliderValue = short.Parse(numbers[2]); 

            StrongSliderValue = short.Parse(numbers[3]);
            MiddleSliderValue = short.Parse(numbers[4]);
            WeakSliderValue   = short.Parse(numbers[5]);
        }

        public void ConstructSliderValues()
        {
           // blueSliderValue = 
            SliderValues = BlueSliderValue.ToString() + " " +
                           GreenSliderValue.ToString() + " " +
                           RedSliderValue.ToString() + " " +

                           StrongSliderValue.ToString() + " " +
                           MiddleSliderValue.ToString() + " " +
                           WeakSliderValue.ToString();
        }

        public void ToPixelColorAsPercentage(PixelColor pixelColor,PixelColorSMW pixelColorSMW)
        {
            pixelColor.Blue = (byte)((this.BlueSliderValue/513)*255);
            pixelColor.Green = (byte)((this.GreenSliderValue / 513) * 255);
            pixelColor.Red = (byte)((this.RedSliderValue / 513) * 255);

            pixelColorSMW.Strong = (byte)((this.StrongSliderValue / 513) * 255);
            pixelColorSMW.Middle = (byte)((this.MiddleSliderValue / 513) * 255);
            pixelColorSMW.Weak= (byte)((this.WeakSliderValue / 513) * 255);
        }
    }
}
