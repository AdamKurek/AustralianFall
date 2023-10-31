using AustralianFall.Classes.Services;
using AustralianFall.Classes.VisualElemetns.MovingElements;
using AustralianFall.Interfaces;
using SkiaSharp;

namespace AustralianFall.Classes.VisualElemetns.StaticVisuals.Backgrounds
{
    internal class Map2 : ILevelAssets
    {
        internal override SKBitmap LoadBackground()
        {
            string resourceID = "RawImages/Backgrounds/Background2.jpg";
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
            for(int i = 0;i < 15;i++){
                float size = (float)Random.NextDouble() * 100f + 100f;
                rects.Add(RectGenerator.GenerateRect(rects,size, size));
            }

            {
                int i = 0;
                foreach (SKRect rect in rects)
                {
                    traps.Add(new OpeningWindow(rect, i++ % 2 == 0 ? true : false));
                }
            }

            return traps;
        }

        internal override void loadTextures()
        {
            LoadBitmaps("OpeningWindow",6);
        }
    }
}
