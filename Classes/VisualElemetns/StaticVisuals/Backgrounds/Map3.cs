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

            //xd.Add();
            return xd;
        }

        internal override List<ITrap> LoadMovingElements()
        {
            List<ITrap> traps = new List<ITrap>();
            List<SKRect> rects = new List<SKRect>();
            rects.Add(SKRect.Create(new SKPoint(500, 700), new SKSize(50, 70)));
            {
                int i = 0;
                foreach (SKRect rect in rects)
                {
                    traps.Add(new ReflectorStand(rect, 0));
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
