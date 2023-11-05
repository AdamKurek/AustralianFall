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
        SKPoint laserPoint;
        public ReflectorLamp(SKRect sKrc, SKPoint centre, bool flip = false) : base(sKrc)
        {
            laserPoint = centre;
        }
        protected override void DrawMainShape(SKCanvas canvas)
        {
            SKMatrix rotationMatrix = SKMatrix.CreateRotationDegrees(45);

            // Calculate the center of the image
            float xTranslate = Bitmap.Width / 2;
            float yTranslate = Bitmap.Height / 2;

            // Create the total transformation matrix
            SKMatrix totalMatrix = SKMatrix.MakeTranslation(-xTranslate, -yTranslate);
            totalMatrix = totalMatrix.PostConcat(rotationMatrix);
            totalMatrix = totalMatrix.PostConcat(SKMatrix.MakeTranslation(xTranslate, yTranslate));

            // Apply the transformation to the canvas
            canvas.Concat(ref totalMatrix);

            // Draw the bitmap
            canvas.DrawBitmap(Bitmap, 0, 0);
            //canvas.DrawLine(
            //    new(laserPoint.X * scaleX, laserPoint.Y * scaleY),
            //    new SKPoint(800 * scaleX, 0),
            //    new SKPaint() { StrokeWidth = 10, Color = SKColors.Red });
            //canvas.DrawCircle(new(laserPoint.X * IDisplayable.canvasWidth, laserPoint.Y * IDisplayable.canvasHeight), 30, new SKPaint() { Color = SKColors.AliceBlue });
        }

        public void Tick()
        {

        }

        float laserRotation = 0;
    }
}
