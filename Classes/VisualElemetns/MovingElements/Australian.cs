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

        SKBitmap bitmap;

        public Australian(SKBitmap b)
        {
            bitmap = b;
        }

        public float xSpeed = 0f;
        public float ySpeed = -5f;

        public float x { get; set; } = 500f;
        public float y { get; set; } = 900f;

        protected override void DrawMainShape(SKCanvas canvas)
        {
            canvas.DrawBitmap(bitmap, x * scaleX, y * scaleY);
        }

        public void updatePosition()
        {
            x += xSpeed;
            y += ySpeed%1000;
        }
    }
}