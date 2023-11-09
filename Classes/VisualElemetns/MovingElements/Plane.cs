using AustralianFall.Interfaces;
using Microsoft.Maui.Controls;
using SkiaSharp;

namespace AustralianFall.Classes.VisualElemetns.MovingElements
{
    internal class Plane: IAnimatedObject 
    {
        public Plane(SKRect Rect, bool flip = false) : base(Rect,new Hitbox[]{
            new Hitbox(new[]{new SKPoint(0.3195712f, 0.4232651f),new SKPoint(0.34301165f, 0.49478635f),new SKPoint(0.5203776f, 0.47368172f),new SKPoint(0.6672709f, 0.5217534f),new SKPoint(0.75634456f, 0.4912689f),new SKPoint(0.7782223f, 0.41974765f),new SKPoint(0.81182027f, 0.4232651f),new SKPoint(0.8204151f, 0.56396264f),new SKPoint(0.8079135f, 0.58037734f),new SKPoint(0.6703963f, 0.6085169f),new SKPoint(0.56647706f, 0.6565885f),new SKPoint(0.3141018f, 0.59210217f),new SKPoint(0.32660332f, 0.6647959f),new SKPoint(0.30394426f, 0.69997025f),new SKPoint(0.29066133f, 0.6003095f),new SKPoint(0.2656582f, 0.6694858f),new SKPoint(0.24768722f, 0.6003095f),new SKPoint(0.27894112f, 0.51354605f),new SKPoint(0.25628203f, 0.44319725f),new SKPoint(0.29066133f, 0.38574576f),new SKPoint(0.29613078f, 0.4912689f) }),
            new Hitbox(new[]{new SKPoint(0.33046874f, 0.50058615f),new SKPoint(0.465625f, 0.50058615f),new SKPoint(0.52265626f, 0.47596717f),new SKPoint(0.6039063f, 0.5099648f),new SKPoint(0.6796875f, 0.5193435f),new SKPoint(0.74140626f, 0.4982415f),new SKPoint(0.78125f, 0.41735053f),new SKPoint(0.8109375f, 0.42086753f),new SKPoint(0.8226563f, 0.5556858f),new SKPoint(0.8046875f, 0.5861665f),new SKPoint(0.6703125f, 0.61313015f),new SKPoint(0.56640625f, 0.6565064f),new SKPoint(0.3359375f, 0.60609615f),new SKPoint(0.31796876f, 0.6553341f),new SKPoint(0.2953125f, 0.58499414f),new SKPoint(0.2828125f, 0.56858146f),new SKPoint(0.26875f, 0.6658851f),new SKPoint(0.253125f, 0.62016416f),new SKPoint(0.26796874f, 0.56154746f),new SKPoint(0.265625f, 0.53927314f),new SKPoint(0.2796875f, 0.5275498f),new SKPoint(0.253125f, 0.5052755f),new SKPoint(0.2640625f, 0.45252052f),new SKPoint(0.2875f, 0.51348186f),new SKPoint(0.30234376f, 0.50644785f),new SKPoint(0.3125f, 0.40797186f),new SKPoint(0.3375f, 0.45603752f)}),
            new Hitbox(new[]{new SKPoint(0.32578126f, 0.4513482f),new SKPoint(0.3390625f, 0.4982415f),new SKPoint(0.4671875f, 0.4947245f),new SKPoint(0.5140625f, 0.46776083f),new SKPoint(0.5992187f, 0.5111372f),new SKPoint(0.67578125f, 0.52403283f),new SKPoint(0.7453125f, 0.49706918f),new SKPoint(0.7789062f, 0.4161782f),new SKPoint(0.8125f, 0.42203987f),new SKPoint(0.825f, 0.56154746f),new SKPoint(0.8070313f, 0.58147717f),new SKPoint(0.67109376f, 0.61313015f),new SKPoint(0.5671875f, 0.66002345f),new SKPoint(0.31953126f, 0.5955451f),new SKPoint(0.32890624f, 0.6412661f),new SKPoint(0.30390626f, 0.68933177f),new SKPoint(0.290625f, 0.5767878f),new SKPoint(0.2625f, 0.6506448f),new SKPoint(0.2453125f, 0.5896835f),new SKPoint(0.2796875f, 0.5627198f),new SKPoint(0.2640625f, 0.5404455f),new SKPoint(0.27421874f, 0.5275498f),new SKPoint(0.25703126f, 0.42790154f),new SKPoint(0.2734375f, 0.41148886f),new SKPoint(0.28515625f, 0.51348186f),new SKPoint(0.303125f, 0.50762016f) }),
            new Hitbox(new[]{new SKPoint(0.31875f, 0.5052755f),new SKPoint(0.4625f, 0.50058615f),new SKPoint(0.5132812f, 0.46776083f),new SKPoint(0.678125f, 0.52403283f),new SKPoint(0.74609375f, 0.49237984f),new SKPoint(0.778125f, 0.41735053f),new SKPoint(0.81171876f, 0.42438453f),new SKPoint(0.825f, 0.5592028f),new SKPoint(0.809375f, 0.5861665f),new SKPoint(0.6664063f, 0.6154748f),new SKPoint(0.55625f, 0.6647128f),new SKPoint(0.49921876f, 0.6506448f),new SKPoint(0.4859375f, 0.6342321f),new SKPoint(0.33828124f, 0.6096131f),new SKPoint(0.328125f, 0.64478314f),new SKPoint(0.29921874f, 0.58382183f),new SKPoint(0.28671876f, 0.6764361f),new SKPoint(0.26015624f, 0.63188744f),new SKPoint(0.27734375f, 0.5650645f),new SKPoint(0.26484376f, 0.5416178f),new SKPoint(0.284375f, 0.52286047f),new SKPoint(0.25546876f, 0.49706918f),new SKPoint(0.27109376f, 0.42790154f),new SKPoint(0.2953125f, 0.5087925f),new SKPoint(0.30234376f, 0.50644785f),new SKPoint(0.31015626f, 0.41148886f),new SKPoint(0.328125f, 0.45252052f)}),
        },flip) {}

        internal float Speed = 5;
        internal float totalMove = 0;
        protected override void AddOffset(float xSpeed, float ySpeed)
        {
            base.AddOffset(xSpeed, ySpeed);
            totalMove += xSpeed;
        }

        internal override Hitbox hitbox => base.hitbox+new SKPoint(totalMove,0);
        public override void Tick()
        {

            currentState = screen.tick/20%4;
            AddOffset(flipped?Speed:-Speed, 0f);
        }
    }
}
