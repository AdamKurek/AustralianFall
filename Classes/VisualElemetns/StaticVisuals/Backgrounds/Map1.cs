using AustralianFall.Classes.Services;
using AustralianFall.Classes.VisualElemetns.MovingElements;
using AustralianFall.Interfaces;
using SkiaSharp;

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
            var xd = new List<SKBitmap>();
            return xd;
        }

        internal override List<ITrap> LoadMovingElements()
        {
            var xd = new List<ITrap>();
            var re = new SKRect(100, 100, 200, 200);
            re.Location = new SKPoint(100, 100);
            var wdw = new OpeningWindow(re);
            xd.Add(wdw);
            return xd;
        }

        internal override void loadTextures()
        {
            LoadBitmaps("OpeningWindow",6);
        }
    }
}
