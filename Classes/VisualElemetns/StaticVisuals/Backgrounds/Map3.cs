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
            for(int i = 0;i < 8;i++){
                float width = (float)Random.NextDouble()*100f + 50f;
                float height = (float)Random.NextDouble()*100f + 50f;
                rects.Add(RectGenerator.GenerateRect(rects, width, height));
            }

            {
                int i = 0;
                foreach (SKRect rect in rects)
                {
                  //  traps.Add(new OpeningWindow(rect, i++ % 2 == 0));
                }
            }

            return traps;
        }

        internal override void loadTextures()
        {
            //LoadBitmaps("OpeningWindow",6);
        }
    }
}
