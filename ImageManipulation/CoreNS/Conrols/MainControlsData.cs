using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation.CoreNS.Conrols
{
    class MainControlsData
    {
        bool pixelColorEnabled;
        PixelColorUsage pixelColorUsage;
        PixelColor pixelColor;

        bool pixelColorSMWEnabled;
        PixelColorUsage pixelColorSMWUsage;
        PixelColorSMW pixelColorSMW;
        
        
        bool  colorSwtichingEnabled;
        BlueColorUsage blueColorUsage ;
        GreenColorUsage greenColorUsage ;
        RedColorUsage redColorUsage ;
    }

    enum PixelColorUsage
    {
        AsSliderPercentage,
        AsSliderValue    
    }

    enum BlueColorUsage
    {
        AsItself,
        AsGreen,
        AsRed
    }

    enum GreenColorUsage
    {
        AsItself,
        AsBlue,
        AsRed
    }

    enum RedColorUsage
    {
        AsItself,
        AsBlue,
        AsGreen
    }
}
