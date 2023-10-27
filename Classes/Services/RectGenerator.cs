using SkiaSharp;

namespace AustralianFall.Classes.Services
{
    internal static class RectGenerator
    {
        private readonly static Random ran = new();
        private static readonly float Widtho = 1000;

        internal static void GenerateRect(ref List<SKRect> rects, float minHeight = 100f, float minWidth = 100f, float maxHeight = 200f, float maxWidth = 200f, float lowerPt = 700f){
                Random rand = new Random();
                bool overlaps = true;
                SKRect newRect = new SKRect();
                while (overlaps)
                {
                    float width = (float)(rand.NextDouble() * (maxWidth - minWidth) + minWidth);
                    float height = (float)(rand.NextDouble() * (maxHeight - minHeight) + minHeight);
                    float left = (float)(rand.NextDouble() * (Widtho - width));
                    float top = (float)(rand.NextDouble() * (lowerPt - height));

                    newRect = new SKRect(left, top, left + width, top + height);
                    overlaps = rects.Any(rect => rect.IntersectsWith(newRect));
                }
                rects.Add(newRect);
            }
        }
}
