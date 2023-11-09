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
    internal class ReflectorLaser: ITrap, ITickable
    {
        int rotation = 0;
        
        SKPoint laserPoint;
        public ReflectorLaser(SKPoint centre, bool flip = false) : base()
        {

            //laserPoint = centre;
            laserPoint = centre;
        }
        protected override void DrawMainShape(SKCanvas canvas)
        {

            var lineLength = 1000;
            var rotationRadians = rotation * Math.PI / 180; // Convert rotation from degrees to radians

            var endX = (float)(Math.Cos(rotationRadians) * lineLength + laserPoint.X);
            var endY = (float)(Math.Sin(rotationRadians) * lineLength + laserPoint.Y);
            var endPoint = new SKPoint(endX, endY);

            using (var paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Stroke;
                paint.Color = SKColors.Red;
                paint.StrokeWidth = 5;
                canvas.DrawLine(new(laserPoint.X*scaleX,laserPoint.Y*scaleY), new(endPoint.X,endPoint.Y), paint);
            }
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

        public override bool DoesIntersectWithRect(SKRect rc)
        {
            return true;
        }

        float laserRotation = 0;
    }
}
