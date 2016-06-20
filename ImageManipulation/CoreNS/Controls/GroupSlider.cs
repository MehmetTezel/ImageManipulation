using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation.CoreNS.Controls
{
    public class GroupSliderColor
    {
       
        public Slider BlueSlider { get; set; }
        public Slider GreenSlider { get; set; }
        public Slider RedSlider { get; set; }

        public PixelColorUsageClass PixelColorUsege;
        public  GroupSliderColor()
        {
            BlueSlider = new Slider();
            GreenSlider = new Slider();
            RedSlider = new Slider();
        }
    }

    public class GroupSliderSMW
    {

        public Slider StrongSlider { get; set; }
        public Slider MiddleSlider { get; set; }
        public Slider WeakSlider { get; set; }

        public PixelColorUsageClass PixelColorUsege;

        public GroupSliderSMW()
        {
            StrongSlider = new Slider();
            MiddleSlider = new Slider();
            WeakSlider = new Slider();
        }
    }

    public class PixelColorUsageClass :INotifyPropertyChanged
    {
        PixelColorUsageEnum pixelColorUsage;

        public PixelColorUsageEnum PixelColorUsage
        {
            get
            {
                return pixelColorUsage;
            }

            set
            {
                this.pixelColorUsage = value;
                OnPropertyChanged("SliderValue");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
    public enum PixelColorUsageEnum
    {
        AsSliderPercentage,
        AsSliderValue
    }
}
