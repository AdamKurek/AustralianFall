using AustralianFall.Classes.Services;
using AustralianFall.Classes.VisualElemetns.MovingElements;
using AustralianFall.Interfaces;
using SkiaSharp;

namespace AustralianFall.Classes.VisualElemetns.StaticVisuals.Backgrounds
{
    internal class Map3 : ILevelAssets
    {
        internal override SKBitmap LoadBackground()
        {
            string resourceID = "RawImages/Backgrounds/Background3.jpg";
            return ImageLoader.LoadBitmap(resourceID).Result;
        }

        internal override List<ITrap> LoadBackgroundElements()
        {
            var xd = new List<ITrap>();
            return xd;
        }

        internal override List<ITrap> LoadMovingElements()
        {
            List<ITrap> traps = new List<ITrap>();
            List<SKRect> rects = new List<SKRect>
            {
                SKRect.Create(new SKPoint(900, 700), new SKSize(50, 70))
            };
            {
                foreach (SKRect rect in rects)
                {
                    var xd = new ReflectorStand(rect);
                    traps.Add(xd.Lamp.Laser);
                    traps.Add(xd.Lamp);
                    traps.Add(xd);
                    //  traps.Add(new OpeningWindow(rect, i++ % 2 == 0));
                }
            }

            return traps;
        }

        internal override void loadTextures()
        {
            LoadBitmap("ReflectorLamp");
            LoadBitmap("ReflectorStand");
        }
    }
}
