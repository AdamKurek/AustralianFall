using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AustralianFall.Interfaces
{
    internal interface IMovable
    {
        float x { get; set; }
        float y { get; set; }

        void updatePosition();
    }
}
