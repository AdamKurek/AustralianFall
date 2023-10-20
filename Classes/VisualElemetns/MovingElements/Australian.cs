using AustralianFall.Interfaces;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AustralianFall.Classes.VisualElemetns.MovingElements
{
    internal class Australian : IDisplayable, IMovable
    {

        private SKBitmap bitmap;

        internal Australian(SKBitmap b)
        {
            var info = new SKImageInfo() { Width = 100, Height = 100, ColorSpace = b.ColorSpace };
            bitmap = new SKBitmap(100,100);
            b.ScalePixels(bitmap, SKFilterQuality.None);
            //bitmap.Info = info;
            //bitmap.Resize()
        }

        internal float xSpeed = 0f;
        internal float ySpeed = -5f;

        public float x { get; set; } = 450f;
        public float y { get; set; } = 900f;
        public bool Alive { get; internal set; } = false;

        protected override void DrawMainShape(SKCanvas canvas)
        {
            canvas.DrawBitmap(bitmap, x * scaleX, y * scaleY);
        }

        public void updatePosition()
        {
            x += xSpeed;
            y += ySpeed;
            if(y<0) y += 1000;
        }
    }
}