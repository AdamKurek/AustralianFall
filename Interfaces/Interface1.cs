using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AustralianFall.Interfaces.IDisplayable;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AustralianFall.Interfaces
{
    internal abstract class AnimatedObject:IDisplayable
    {
        protected AnimatedObject() { 
        
        }
        readonly int states;
        readonly SKBitmap[] animationFrames;
        readonly Hitbox[] hitboxFrames;

    }
}
