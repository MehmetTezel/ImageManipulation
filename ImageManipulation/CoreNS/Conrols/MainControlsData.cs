using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulation.CoreNS.Conrols
{
    class MainControlsData
    {
        PixelColor pixelColor;
        PixelColorSMW pixelColorSMW;
        PixelColorUsage pixelColorUsage;
        PixelColorUsage pixelColorSMWUsage;
        bool ColorSwtichingEnabled;
    }

    enum PixelColorUsage
    {
        AsSliderPercentage,
        AsSliderValue    
    }
}
