using AustralianFall.Classes.Services;
using AustralianFall.Classes.VisualElemetns.MovingElements;
using AustralianFall.Interfaces;
using SkiaSharp;

namespace AustralianFall.Classes.VisualElemetns.StaticVisuals.Backgrounds
{
    internal class Map4 : ILevelAssets
    {
        internal override SKBitmap LoadBackground()
        {
            string resourceID = "RawImages/Backgrounds/Background4.jpg";
            return ImageLoader.LoadBitmap(resourceID).Result;
        }

        internal override List<ITrap> LoadBackgroundElements()
        {
            var xd = new List<ITrap>();
            return xd;
        }

        internal override List<ITrap> LoadMovingElements(){
            List<ITrap> traps = new List<ITrap>();
            List<SKRect> rects = new List<SKRect>();
            for(int i = 0;i < 10;i++){
                float size = (float)Random.NextDouble() * 100f + 100f;
                rects.Add(RectGenerator.GenerateRect(rects,size, size));
            }

            {
                int i = 0;
                foreach (SKRect rect in rects){
                    var rotate = i++ % 2 == 0;
                    rect.Offset(rotate? -750: 750, 0);
                    traps.Add(new Plane(rect, rotate));
                }
            }

            return traps;
        }

        internal override void loadTextures(){
            LoadBitmaps("Plane",4);
        }
    }
}
