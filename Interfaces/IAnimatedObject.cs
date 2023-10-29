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
                if (flipped == true)
                {
                    _animationFrames = new SKBitmap[value.Length];
                    for (int i = 0;i<value.Length;i++)
                    {
                        _animationFrames[i] = FlipBitmap(value[i]);
                    }
                    return;
                }
                                
                _animationFrames = value;
                
            }
        }
        public Hitbox[] hitboxFrames;
        internal int[] animationTreholds;

        internal override void Flip()
        {
            flipped = true;
        }

    }
}
