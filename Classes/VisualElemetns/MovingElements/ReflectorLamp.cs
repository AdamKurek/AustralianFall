using AustralianFall.Interfaces;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AustralianFall.Classes.VisualElemetns.MovingElements
{
    internal class ReflectorLamp: ITrap, ITickable
    {
        int rotation = 0;
        SKPoint laserPoint;
        internal ReflectorLaser Laser;
        public ReflectorLamp(SKRect sKrc, SKPoint centre, bool flip = false) : base(sKrc)
        {

            //laserPoint = centre;
            laserPoint = new(getHitboxRect().MidX, getHitboxRect().MidY);
            Laser = new(laserPoint);
        }
        protected override void DrawMainShape(SKCanvas canvas)
        {
            DrawRotated(canvas,rotation,new(DrawingRectS.Width / 2 + DrawingRectS.Left, DrawingRectS.Height / 2 + DrawingRectS.Top));
#if ShowHitboxes
            canvas.DrawPoint(new(xTranslate, yTranslate), SKColors.Blue);
#endif
         }

       

        //canvas.DrawLine(
        //    new(laserPoint.X * scaleX, laserPoint.Y * scaleY),
        //    new SKPoint(800 * scaleX, 0),
        //    new SKPaint() { StrokeWidth = 10, Color = SKColors.Red });
        //canvas.DrawCircle(new(laserPoint.X * IDisplayable.canvasWidth, laserPoint.Y * IDisplayable.canvasHeight), 30, new SKPaint() { Color = SKColors.AliceBlue });

        public void Tick()
        {
            rotation--;
        }

        float laserRotation = 0;
    }
}
