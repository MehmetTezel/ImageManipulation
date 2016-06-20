using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation.CoreNS.Controls
{
    class MainControlsData
    {
        bool IsGroupSliderColorEnabled {get; set;}

        public GroupSliderColor GroupSliderColor { get; set; }
        public GroupSliderSMW   GroupSliderSMW { get; set; }

        public bool IsGroupSliderSMWEnabled {get; set; }
        
    }

    public class BlueColorUsageClass : INotifyPropertyChanged
    {
        BlueColorUsageEnum blueColorUsage;

        public BlueColorUsageEnum BlueColorUsage
        {
            get
            {
                return blueColorUsage;
            }

            set
            {
                this.blueColorUsage = value;
                OnPropertyChanged("BlueColorUsage");
            }
        }

        public BlueColorUsageClass()
        {
            this.BlueColorUsage = BlueColorUsageEnum.AsItself;
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


    public class GreenColorUsageClass : INotifyPropertyChanged
    {
        GreenColorUsageEnum greenColorUsage;

        public GreenColorUsageEnum GreenColorUsage
        {
            get
            {
                return greenColorUsage;
            }

            set
            {
                this.greenColorUsage = value;
                OnPropertyChanged("GreenColorUsage");
            }
        }

        public GreenColorUsageClass()
        {
            this.GreenColorUsage = GreenColorUsageEnum.AsItself;
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




        public class RedColorUsageClass : INotifyPropertyChanged
    {
        RedColorUsageEnum redColorUsage;

        public RedColorUsageEnum RedColorUsage
        {
            get
            {
                return redColorUsage;
            }

            set
            {
                this.redColorUsage = value;
                OnPropertyChanged("RedColorUsage");
            }
        }

        public RedColorUsageClass()
        {
            this.RedColorUsage = RedColorUsageEnum.AsItself;
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

    public enum BlueColorUsageEnum
    {
        AsItself,
        AsGreen,
        AsRed
    }

    public enum GreenColorUsageEnum
    {
        AsItself,
        AsBlue,
        AsRed
    }

    public enum RedColorUsageEnum
    {
        AsItself,
        AsBlue,
        AsGreen
    }
}
