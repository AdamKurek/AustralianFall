using AustralianFall.Classes.VisualElemetns;
using SkiaSharp;

namespace AustralianFall.Interfaces
{
    internal abstract class IAnimatedObject:ITrap,ITickable
    {
        protected IAnimatedObject(SKRect sKrc, Hitbox[] hitboxesPercentages, bool flip = false):base(sKrc){
            if(flip)
            {
                Flip();
            }
            _hitboxFrames = new Hitbox[hitboxesPercentages.Length]; 
            for (int i = 0;i< hitboxesPercentages.Length;i++) {
                SKPoint[] pts = new SKPoint[hitboxesPercentages[i].Points.Length]; 
                for (int j = 0;j < hitboxesPercentages[i].Points.Length; j++)
                {
                    if (flipped)// flipped)
                    {
                        pts[j] = new SKPoint(
                            hitboxesPercentages[i].Points[j].X * (1-getHitboxRect().Width) + getHitboxRect().Width + getHitboxRect().Location.X,
                            hitboxesPercentages[i].Points[j].Y * getHitboxRect().Height + getHitboxRect().Location.Y);
                    }
                    else
                    {
                        pts[j] = new SKPoint(
                            hitboxesPercentages[i].Points[j].X * getHitboxRect().Width + getHitboxRect().Location.X,
                            hitboxesPercentages[i].Points[j].Y * getHitboxRect().Height + getHitboxRect().Location.Y);
                    }
                }
                _hitboxFrames[i] = new Hitbox(pts);
            }
        }
        public int States { get; protected set; }
        private int _currentState =0;
        internal int currentState { get => _currentState;set 
            {
                _currentState = value;
                    } }

        protected override SKBitmap Bitmap
        {
            get
            {
                return _animationFrames[currentState];
            }
            set => base.Bitmap = value;
        }

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

        private Hitbox[] _hitboxFrames;
        public Hitbox[] hitboxFrames
        {
            get => hitboxFrames;
            set
            {
                _hitboxFrames = value;
            }
        }
        internal override Hitbox hitbox { get => _hitboxFrames[currentState]; }
        internal override void Flip()
        {
            flipped = true;
        }

        public void Tick()
        {
            switch (activated)
            {
            case TrapState.sleeping:
                {
                    if (DrawingRect.Bottom + activationDistance > screen.australian.Y)// 1000 - (screen.tick * 5))
                    {
                        TickOfActivation = screen.tick;
                        activated = TrapState.active;
                        goto case TrapState.active;
                    }
                    currentState = 0;
                    break;
                }
            case TrapState.active:
                {
                    int frame = ((screen.tick) - TickOfActivation) * 5 / (activationDistance / States);
                    if (frame >= States)
                    {
                            activated = TrapState.done;
                            goto case TrapState.done;
                    }
                    currentState = frame;
                    break;
                }
                case TrapState.done:
                {
                    currentState = States - 1;
                    break;
                }
            }
        }
    }
}
