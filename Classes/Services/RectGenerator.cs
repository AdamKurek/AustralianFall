using SkiaSharp;

namespace AustralianFall.Classes.Services
{
    internal static class RectGenerator
    {
        private readonly static Random ran = new();
        private static readonly float Widtho = 1000;

        internal static SKRect GenerateRect(List<SKRect> rects, float height = 100f, float width = 100f, float lowerPt = 700f){
            bool overlaps = true;
            SKRect newRect = new SKRect();
            while (overlaps)
            {
                float left = (float)(ran.NextDouble() * (Widtho - width));
                float top = (float)(ran.NextDouble() * (lowerPt - height));
                newRect = new SKRect(left, top, left + width, top + height);
                overlaps = rects.Any(rect => rect.IntersectsWith(newRect));
            }
            return newRect;
            }
        }
}
