using AustralianFall.Classes.Services;
using AustralianFall.Classes.VisualElemetns.MovingElements;
using AustralianFall.Interfaces;
using SkiaSharp;

namespace AustralianFall.Classes.VisualElemetns.StaticVisuals.Backgrounds
{
    internal class Map5 : ILevelAssets
    {
        internal override SKBitmap LoadBackground()
        {
            string resourceID = "RawImages/Backgrounds/Background5.jpg";
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
            for(int i = 0;i < 8;i++){
                float size = (float)Random.NextDouble() * 50f + 50f;
                rects.Add(RectGenerator.GenerateRect(rects,size, size));
            }

            {
                int i = 0;
                foreach (SKRect rect in rects){
                    var flip = i++ % 2 == 0;
                    rect.Offset(0, 300);
                    traps.Add(new Balon(rect));
                }
            }

            return traps;
        }

        internal override void loadTextures(){
            LoadBitmap("Balon");
        }
    }
}
