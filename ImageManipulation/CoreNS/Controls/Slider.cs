using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace ImageManipulation.CoreNS.Controls
{
    public class Slider : INotifyPropertyChanged
    {
        public static class SliderDefaults
        {
            public static double Maximum = 255;
            public static double InitialValue = 128;
            public static double powerValue = 32; //increase one hundred percent per powerValue

        }

        double maximum;

        public double Maximum
        {
            get
            {
                return maximum;
            }

            set
            {
                maximum = value;
                OnPropertyChanged("Maximum");
            }
        }



        double sliderValue;

        public double SliderValue
        {
            get
            {
                return sliderValue;
            }

            set
            {
                sliderValue = value;
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

        public Slider()
        {
            this.Maximum = Slider.SliderDefaults.Maximum;
            this.sliderValue = Slider.SliderDefaults.InitialValue;
        }
    }


}
