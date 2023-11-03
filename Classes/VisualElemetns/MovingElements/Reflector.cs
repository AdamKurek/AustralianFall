using AustralianFall.Interfaces;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AustralianFall.Interfaces.IDisplayable;

namespace AustralianFall.Classes.VisualElemetns.MovingElements
{
    internal class Reflector : IAnimatedObject
    {
        public Reflector(SKRect rc, int rotation) : base(rc,
        new Hitbox[]{new Hitbox(new[] { new SKPoint(0.17502187f, 0.91523373f), new SKPoint(0.5417344f, 0.97624934f), new SKPoint(0.82093596f, 0.9046224f), new SKPoint(0.61674374f, 0.83564824f), new SKPoint(0.58340627f, 0.6526015f), new SKPoint(0.9542859f, 0.39527488f), new SKPoint(0.85844064f, 0.12733687f), new SKPoint(0.5750719f, 0.01856996f), new SKPoint(0.08334375f, 0.22018667f), new SKPoint(0.075009376f, 0.45629045f), new SKPoint(0.28753594f, 0.5942387f), new SKPoint(0.2667f, 0.67647713f), new SKPoint(0.4375547f, 0.68708855f), new SKPoint(0.4417219f, 0.71892273f), new SKPoint(0.39171562f, 0.7481041f), new SKPoint(0.37504688f, 0.83034253f)})})
        {
            laser = new ReflectorLaser(new SKRect(0, 0, IDisplayable.canvasWidth, rc.MidY), 
                new(getHitboxRect().MidX, getHitboxRect().MidY));
        }
        ReflectorLaser laser;
        protected override void DrawMainShape(SKCanvas canvas)
        {
            base.DrawMainShape(canvas);
            laser.Draw(canvas);
        }
        private class ReflectorLaser : ITrap, ITickable
        {
            SKPoint laserPoint;
            public ReflectorLaser(SKRect sKrc, SKPoint centre , bool flip = false) : base(sKrc)
            {
                laserPoint = centre;
            }
            protected override void DrawMainShape(SKCanvas canvas)
            {
                canvas.DrawLine(
                    new (laserPoint.X*scaleX, laserPoint.Y * scaleY),
                    new SKPoint(800 * scaleX, 0),
                    new SKPaint() { StrokeWidth = 10, Color = SKColors.Red });

                //canvas.DrawCircle(new(laserPoint.X * IDisplayable.canvasWidth, laserPoint.Y * IDisplayable.canvasHeight), 30, new SKPaint() { Color = SKColors.AliceBlue });
            }

            public void Tick()
            {
                
            }

            float laserRotation = 0;
        }

    }
}


