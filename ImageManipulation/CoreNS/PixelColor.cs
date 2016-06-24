using System;
using ImageManipulation.CoreNS.Controls;
namespace ImageManipulation.CoreNS
{

    public class PixelParameter
    {
        public double Blue;
        public double Green;
        public double Red;


        public bool EnableSwitchColors = false;
        public bool SwitchGreenAndBlue = false;
        public bool SwitchRedAndBlue = false;
        public bool SwitchGreenAndRed = false;


    }

    public struct PixelColor
    {
        public byte Blue;
        public byte Green;
        public byte Red;
        public byte Alpha;
       




        public void ChangeColors(PixelParameter pixelParam)
        {

            Blue = GetColorValue((byte)pixelParam.Blue, Blue);
            Green = GetColorValue((byte)pixelParam.Green, Green);
            Red = GetColorValue((byte)pixelParam.Red, Red);

        }


        private byte GetColorValue(byte sliderValue, byte colorByte)
        {
            double percent = 1.0;
            if (sliderValue > Slider.SliderDefaults.InitialValue)
            {
                percent += (sliderValue - Slider.SliderDefaults.InitialValue) / Slider.SliderDefaults.powerValue;

            }
            else
            {
                percent += (Slider.SliderDefaults.InitialValue - sliderValue) / Slider.SliderDefaults.powerValue;
            }
            if (sliderValue > Slider.SliderDefaults.InitialValue)
                return (byte)(colorByte * percent > 255 ? 255 : colorByte * percent);
            else
                return (byte)(colorByte / percent);

        }

        //public void ChangeColorsSMW(PixelParameter pixelParameter)
        //{

        //    double temp;
        //    if (pixelParameter.IsPercentage)
        //    {
        //        if (pixelParameter.IsBlueEnabled)
        //        {
        //            temp = NewMethod(pixelParameter);
        //        }
        //        if (pixelParameter.IsGreenEnabled)
        //        {
        //            if (Green > Blue && Green > Red) // if strong
        //            {
        //                temp = Green * pixelParameter.Blue / 255;
        //                if (temp > 255)
        //                    Green = 255;
        //                else
        //                    Green = (byte)temp;
        //            }
        //            else if (Green < Blue && Green < Red) // if weak
        //            {
        //                temp = Green * pixelParameter.Red / 255;
        //                if (temp > 255)
        //                    Green = 255;
        //                else
        //                    Green= (byte)temp;
        //            }
        //            else  // if middle
        //            {
        //                temp = Green * pixelParameter.Green / 255;
        //                if (temp > 255)
        //                    Green = 255;
        //                else
        //                    Green = (byte)temp;
        //            }
        //        }
        //        if (pixelParameter.IsRedEnabled)
        //        {
        //            if (Red > Green && Red > Blue) // if strong
        //            {
        //                temp = Red * pixelParameter.Blue / 255;
        //                if (temp > 255)
        //                    Red = 255;
        //                else
        //                    Red = (byte)temp;
        //            }
        //            else if (Red < Green && Red < Blue) // if weak
        //            {
        //                temp = Red * pixelParameter.Red / 255;
        //                if (temp > 255)
        //                    Red = 255;
        //                else
        //                    Red = (byte)temp;
        //            }
        //            else  // if middle
        //            {
        //                temp = Red * pixelParameter.Green / 255;
        //                if (temp > 255)
        //                    Red = 255;
        //                else
        //                    Red = (byte)temp;
        //            }
        //        }

        //    }
        //    else
        //    {
        //        if (pixelParameter.IsBlueEnabled)
        //            Blue = (byte)(pixelParameter.Blue / 2);
        //        if (pixelParameter.IsGreenEnabled)
        //            Green = (byte)(pixelParameter.Green / 2);
        //        if (pixelParameter.IsRedEnabled)
        //            Red = (byte)(pixelParameter.Red / 2);
        //    }

        //}

        private double NewMethod(PixelParameter pixelParameter)
        {
            double temp;
            if (Blue > Green && Blue > Red) // if strong
            {
                temp = Blue * pixelParameter.Blue / 255;
                if (temp > 255)
                    Blue = 255;
                else
                    Blue = (byte)temp;
            }
            else if (Blue < Green && Blue < Red) // if weak
            {
                temp = Blue * pixelParameter.Red / 255;
                if (temp > 255)
                    Blue = 255;
                else
                    Blue = (byte)temp;
            }
            else  // if middle
            {
                temp = Blue * pixelParameter.Green / 255;
                if (temp > 255)
                    Blue = 255;
                else
                    Blue = (byte)temp;
            }

            return temp;
        }

        public void SwitchColors(PixelParameter pixelParameter)
        {


            byte temp = Blue;
            if (pixelParameter.SwitchGreenAndBlue)
            {
                temp = Blue;
                Blue = Green;
                Green = temp;
                return;
            }

            if (pixelParameter.SwitchRedAndBlue)
            {
                temp = Blue;
                Blue = Red;
                Red = temp;
                return;
            }

            if (pixelParameter.SwitchGreenAndRed)
            {
                temp = Green;
                Green = Red;
                Red = temp;
                return;
            }


        }



        public void ToOneBit()
        {
            if (Blue + Green + Red > 3 * byte.MaxValue / 2)
            {
                Blue = byte.MaxValue;
                Green = byte.MaxValue;
                Red = byte.MaxValue;
            }

            else
            {
                Blue = byte.MinValue;
                Green = byte.MinValue;
                Red = byte.MinValue;

            }
        }



        public void ToGray()
        {

            int total = Blue + Green + Red;
            Blue = (byte)(total / 3);
            Green = (byte)(total / 3);
            Red = (byte)(total / 3);

        }

        public void ToGray2()
        {
            Colors StrongestColor;

            if (Blue > Green)
                StrongestColor = Colors.Blue;
            else
                StrongestColor = Colors.Green;
            if (StrongestColor == Colors.Blue)
            {
                if (Red > Blue)
                    StrongestColor = Colors.Red;
            }
            else
                if (Red > Green)
                StrongestColor = Colors.Red;

            switch (StrongestColor)
            {
                case Colors.Blue:
                    Red = Green = Blue;

                    break;
                case Colors.Green:
                    Blue = Red = Green;
                    break;
                case Colors.Red:
                    Blue = Green = Red;
                    break;

            }
        }

        public void ToGray3()
        {
            Colors StrongestColor;

            if (Blue > Green)
                StrongestColor = Colors.Blue;
            else
                StrongestColor = Colors.Green;
            if (StrongestColor == Colors.Blue)
            {
                if (Red > Blue)
                    StrongestColor = Colors.Red;
            }
            else
                if (Red > Green)
                StrongestColor = Colors.Red;

            switch (StrongestColor)
            {
                case Colors.Blue:
                    Red = Green = (byte)(Blue / 5 / 3);
                    break;
                case Colors.Green:
                    Blue = Red = (byte)(Green / 5 / 3);
                    break;
                case Colors.Red:
                    Blue = Red = (byte)(Red / 5 / 3);
                    break;

            }
        }
        public void ToGray4()
        {
            Colors StrongestColor;

            if (Blue > Green)
                StrongestColor = Colors.Blue;
            else
                StrongestColor = Colors.Green;
            if (StrongestColor == Colors.Blue)
            {
                if (Red > Blue)
                    StrongestColor = Colors.Red;
            }
            else
                if (Red > Green)
                StrongestColor = Colors.Red;

            switch (StrongestColor)
            {
                case Colors.Blue:
                    Red = Green = (byte)(Blue / 1.2);
                    break;
                case Colors.Green:
                    Blue = Red = (byte)(Green / 1.3);
                    break;
                case Colors.Red:
                    Blue = Red = (byte)(Red / 1.4);
                    break;

            }
        }
        /// <summary>
        ///  if blue is biger than 128, it is intensified (shifted)by amout else reduced
        /// </summary>
        /// <param name="quality">0 = 8 bit gray 1=9 bit gray 2 = 10 bit </param>
        public void IntensifyHighBitsReduceLowBits(byte quality)
        {

            if (Blue < 128)
                Blue >>= quality;
            else
                Blue <<= quality;

            if (Green < 128)
                Green >>= quality;
            else
                Green <<= quality;

            if (Red < 128)
                Red >>= quality;
            else
                Red <<= quality;

        }
        public void ReverseColor()
        {
            Blue = (byte)(byte.MaxValue - Blue);
            Green = (byte)(byte.MaxValue  - Green);
            Red = (byte)(byte.MaxValue  - Red);
        }

        public void Square()
        {
            Blue = (byte)(Blue * Blue > byte.MaxValue ? byte.MaxValue : Blue * Blue);
            Green = (byte)(Green * Green > byte.MaxValue ? byte.MaxValue : Green * Green);
            Red = (byte)(Red * Red > byte.MaxValue ? byte.MaxValue : Red * Red);

        }

        public void SquareRoot()
        {
            Blue = (byte)Math.Sqrt(Blue + 1);
            Green = (byte)Math.Sqrt(Green + 1);
            Red = (byte)Math.Sqrt(Red + 1);

        }

        public void Logaritma()
        {
            Blue = (byte)(Math.Log(Blue + 1));
            Green = (byte)(Math.Log(Green + 1));
            Red = (byte)(Math.Log(Red + 1));
        }

        public void InverseLogaritma()
        {
            Blue = (byte)(Math.Log(Blue + 1));
            Green = (byte)(Math.Log(Green + 1));
            Red = (byte)(Math.Log(Red + 1));
        }


        public void AddBrightness(byte brightness)
        {
            if (Blue + brightness <= byte.MaxValue)
            {
                Blue += brightness;
            }

            else
            {
                Blue = byte.MaxValue;

            }

            if (Green + brightness <= byte.MaxValue)
            {
                Green += brightness;
            }

            else
            {
                Green = byte.MaxValue;

            }
            if (Red + brightness <= byte.MaxValue)
            {
                Red += brightness;
            }

            else
            {
                Red = byte.MaxValue;

            }

        }

        public void AddRedBrightness(byte brightness)
        {
            if (Red + brightness <= byte.MaxValue)
            {
                Red += brightness;
            }

            else
            {
                Red = byte.MaxValue;

            }

        }

        public void IntensifyRed1(byte amount)
        {
            if (Red >= 125 & Green < 100 & Blue < 100)
            {
                if (Red + amount <= byte.MaxValue)

                    Red += amount;
                else
                    Red = byte.MaxValue;

                Blue /= 2;
                Green /= 2;
            }

        }

        public void RemoveWeakColors()
        {
            Colors StrongestColor;

            if (Blue > Green)
                StrongestColor = Colors.Blue;
            else
                StrongestColor = Colors.Green;
            if (StrongestColor == Colors.Blue)
            {
                if (Red > Blue)
                    StrongestColor = Colors.Red;
            }
            else
                if (Red > Green)
                StrongestColor = Colors.Red;

            switch (StrongestColor)
            {
                case Colors.Blue:
                    Green = 0;
                    Red = 0;
                    break;
                case Colors.Green:
                    Blue = 0;
                    Red = 0;
                    break;
                case Colors.Red:
                    Blue = 0;
                    Green = 0;
                    break;
            }
        }
        public void IntensifyStrongestColor(byte amount)
        {
            Colors StrongestColor;

            if (Blue > Green)
                StrongestColor = Colors.Blue;
            else
                StrongestColor = Colors.Green;
            if (StrongestColor == Colors.Blue)
            {
                if (Red > Blue)
                    StrongestColor = Colors.Red;
            }
            else
                if (Red > Green)
                StrongestColor = Colors.Red;

            switch (StrongestColor)
            {
                case Colors.Blue:
                    if (amount + Blue < byte.MaxValue)
                        Blue += amount;
                    else
                        Blue = byte.MaxValue;
                    break;
                case Colors.Green:
                    if (amount + Green < byte.MaxValue)
                        Green += amount;
                    else
                        Green = byte.MaxValue;
                    break;
                case Colors.Red:
                    if (amount + Red < byte.MaxValue)
                        Red += amount;
                    else
                        Red = byte.MaxValue;
                    break;

            }
        }

    }
    [Flags]
    enum Colors
    {
        Blue,
        Red,
        Green
    }

    public struct PixelColorSMW
    {
        public byte Strong;
        public byte Middle;
        public byte Weak;
        public byte Alpha;
    }
}

