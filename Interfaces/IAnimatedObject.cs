using AustralianFall.Classes.VisualElemetns;
using SkiaSharp;

namespace AustralianFall.Interfaces
{
    internal abstract class IAnimatedObject:ITrap
    {
        //protected IAnimatedObject()  {}
        public int States { get; protected set; }
        private SKBitmap[] _animationFrames;
        public SKBitmap[] animationFrames
        {
            get => _animationFrames;
            set
            {
                States = value.Length;
                _animationFrames = value;
            }
        }
        public Hitbox[] hitboxFrames;
        internal int[] animationTreholds;

        internal override void Revert()
        {
            for(int i=0;i<States;i++) {
                _animationFrames[i] = FlipBitmap(_animationFrames[i]);
            }
        }

    }
}
