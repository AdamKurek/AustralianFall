using AustralianFall.Classes.Services;
using AustralianFall.Interfaces;
using Microsoft.Maui.Controls;
using SkiaSharp;

namespace AustralianFall.Classes.VisualElemetns.MovingElements
{
    internal class Balon: IAnimatedObject 
    {
        public Balon(SKRect Rect, bool flip = false) : base(Rect,new Hitbox[]{
           new Hitbox(new[]{new SKPoint(0.47708148f, 0.9941306f),new SKPoint(0.5556811f, 0.98983324f),new SKPoint(0.5593369f, 0.95545405f),new SKPoint(0.54471374f, 0.89529055f),new SKPoint(0.62514126f, 0.7778284f),new SKPoint(0.98706514f, 0.36814347f),new SKPoint(0.9651304f, 0.19338275f),new SKPoint(0.6927735f, 0.018622043f),new SKPoint(0.27235687f, 0.03294669f),new SKPoint(0.049353257f, 0.17476071f),new SKPoint(0.016451085f, 0.29222283f),new SKPoint(0.1133297f, 0.5228497f),new SKPoint(0.3692355f, 0.7534765f),new SKPoint(0.48804888f, 0.896723f)}
           )} ,flip) {
            Random r = new Random();
            constSpeedx = ((float)r.NextDouble()) - 0.5f;
        }


 
        protected override void AddOffset(float xSpeed, float ySpeed)
        {
            base.AddOffset(xSpeed, ySpeed);
            totalMoveX += xSpeed;
            totalMoveY += ySpeed;
        }

        protected override void DrawMainShape(SKCanvas canvas)
        {
            //base.DrawMainShape(canvas);
            DrawRotated(canvas, rotation,new(DrawingRectS.Width / 2 + DrawingRectS.Left, DrawingRectS.Height / 2 + DrawingRectS.Top));
        }

        internal override Hitbox hitbox => base.hitbox + new SKPoint(totalMoveX, totalMoveY);


        bool goesRight = true;
        internal float SpeedX = 2;
        internal float SpeedY = -3;
        internal float DeltaX = 0;
        internal float DeltaY = 0;
        internal float totalMoveX = 0;
        internal float totalMoveY = 0;
        float rotation = 30;

        internal float constSpeedx = 0.5f;
        const float minValue = -25f;
        const float maxValue = 25f;
        const float duration = 100f;
        // const float frequency = 1f;//1f goes from min trough max to min
        const float frequency = 1f;//0.5 goes from min to max
        float currentTime = 0f;

        public override void Tick()
        {
            //currentState = screen.tick/20%4;
            var xd = screen.tick % 50;
            var xd1 = screen.tick % 100;

            if (xd == 0) {
                SpeedX = -SpeedX;
            }
            float t = xd / duration;
            rotation = Mathff.Lerp(minValue, maxValue, Mathff.SmoothStep(0, 1, MathF.Sin(t * MathF.PI * frequency)));
            if(SpeedX<0)
            {
                rotation = -rotation;
            }
            currentTime++;

            var honestXSpeed = SpeedX - rotation/ 4 + constSpeedx;

            AddOffset(flipped? honestXSpeed : -honestXSpeed, SpeedY);
        }
    }
}
