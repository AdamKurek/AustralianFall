using SkiaSharp;

namespace AustralianFall.Interfaces
{
    internal abstract class IAnimatedObject
        
        
        :ITrap
    {
        public int States { get; protected set; }


        SKBitmap[] animationFrames;
        readonly Hitbox[] hitboxFrames;

    }
}
