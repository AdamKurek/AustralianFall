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
        int rotation = -30;
        
        SKPoint laserPoint;
        public ReflectorLaser(SKPoint centre, bool flip = false) : base()
        {

            //laserPoint = centre;
            laserPoint = centre;
        }
        protected override void DrawMainShape(SKCanvas canvas)
        {

            var lineLength = 100f;// * MathF.Cos(scaleX) * MathF.Sin(scaleY);
            
            
            var paint = new SKPaint();
            paint.Style = SKPaintStyle.Stroke;
            paint.Color = SKColors.Red;
            paint.StrokeWidth = 5;
            paint.Style = SKPaintStyle.Stroke;

            if (false)
            {
                var rotationRadians = rotation * MathF.PI / 180; 

                var endX = ((MathF.Cos(rotationRadians) * lineLength) + laserPoint.X);
                var endY = ((MathF.Sin(rotationRadians) * lineLength) + laserPoint.Y);
                var endPoint = new SKPoint(endX * scaleX, endY * scaleY);
                canvas.DrawLine(new(laserPoint.X * scaleX, laserPoint.Y * scaleY), new(endPoint.X, endPoint.Y), paint);
                return;
            }

            var rotationRadiansL = (rotation +20) * MathF.PI / 180; 
            var rotationRadiansR = (rotation -20) * MathF.PI / 180;

            var endXL = ((MathF.Cos(rotationRadiansL) * lineLength) + laserPoint.X);
            var endYL = ((MathF.Sin(rotationRadiansL) * lineLength) + laserPoint.Y);
            var endXR = ((MathF.Cos(rotationRadiansR) * lineLength) + laserPoint.X);
            var endYR = ((MathF.Sin(rotationRadiansR) * lineLength) + laserPoint.Y);

            var trianglePoints = new SKPoint[]
            {
                new SKPoint(laserPoint.X * scaleX, laserPoint.Y * scaleY),
                new SKPoint(endXL* scaleX, endYL * scaleY),
                new SKPoint(endXR* scaleX, endYR * scaleY)
            };

            SKPath path = new SKPath();
            path.AddPoly(trianglePoints);

         
            canvas.DrawPath(path, paint);

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
    }
}
