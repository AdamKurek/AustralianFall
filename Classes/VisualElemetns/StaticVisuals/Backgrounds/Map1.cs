using AustralianFall.Classes.Services;
using AustralianFall.Interfaces;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AustralianFall.Classes.VisualElemetns.StaticVisuals.Backgrounds
{
    internal class Map1 : ILevelAssets
    {
        internal override SKBitmap LoadBackground()
        {
            string resourceID = "RawImages/Backgrounds/Background1.jpg";
            return ImageLoader.LoadBitmap(resourceID).Result;
        }

        internal override List<SKBitmap> LoadBackgroundElements()
        {
            return new List<SKBitmap>();
        }

        internal override List<ITrap> LoadMovingElements()
        {
            return new List<ITrap>();
        }
    }
}
