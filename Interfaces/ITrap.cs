using SkiaSharp;

namespace AustralianFall.Interfaces
{
    internal abstract class ITrap:IDisplayable
    {
        internal SKRect getHitboxRect()
        {
            return DrawingRect;
        }
        internal SKRect getEffectiveHitbox()
        {
            return getHitboxRect();
        }
    }
}
