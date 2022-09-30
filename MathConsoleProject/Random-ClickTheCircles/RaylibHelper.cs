using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;

using MathLibrary;

namespace GameFramework
{
    public static class RaylibHelper
    {
        public static Color FromColour(Colour colour)
        {
            return new Color(colour.Red, colour.Green, colour.Blue, colour.Alpha);
        }
    }
}
