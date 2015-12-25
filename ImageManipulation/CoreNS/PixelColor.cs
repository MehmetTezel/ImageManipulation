using System;

namespace ImageManipulation.CoreNS
{
    public struct PixelColor
    {
        public byte Blue;
        public byte Green;
        public byte Red;
        public byte Alpha;



        public void ChangeColors(PixelColor pixelColor, PixelColorSMW pixelColorSMW)
        {
            Blue = pixelColor.Blue;
            Green = pixelColor.Green;
            Red = pixelColor.Red;
        }

        public void ChangeColors(PixelColor pixelColor)
        {
            Blue = (byte)(Blue*pixelColor.Blue);
            Green = pixelColor.Green;
            Red = pixelColor.Red;
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
            Blue = (byte)Math.Abs(Blue - byte.MaxValue);
            Green = (byte)Math.Abs(Green - byte.MaxValue);
            Red = (byte)Math.Abs(Red - byte.MaxValue);
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

