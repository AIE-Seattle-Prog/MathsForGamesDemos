using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Colour
    {
        public UInt32 colour;

        // constructor
        public Colour (byte red, byte green, byte blue, byte alpha)
        {
            colour = ((UInt32)red << 24) | ((UInt32)green << 16) | ((UInt32)blue << 8) | alpha;
        }

        // red
        public byte Red
        {
            get
            {
                return (byte)(colour >> 24);
            }
            set
            {
                colour = colour & 0x00FFFFFF;
                colour |= (UInt32)value << 24;
            }
        }

        // green
        public byte Green
        {
            get
            {
                return (byte)(colour >> 16);
            }
            set
            {
                colour = colour & 0xFF00FFFF;
                colour |= (UInt32)value << 16;
            }
        }

        // blue
        public byte Blue
        {
            get
            {
                return (byte)(colour >> 8);
            }
            set
            {
                colour = colour & 0xFFFF00FF;
                colour |= (UInt32)value << 8;
            }
        }

        // alpha
        public byte Alpha
        {
            get
            {
                return (byte)colour;
            }
            set
            {
                colour = colour & 0xffffff00;
                colour = colour | value;
            }
        }
    }
}
