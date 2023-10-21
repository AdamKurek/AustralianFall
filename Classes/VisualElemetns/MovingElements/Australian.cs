using AustralianFall.Classes.Services;
using AustralianFall.Interfaces;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AustralianFall.Classes.VisualElemetns.MovingElements
{
    internal class Australian : IDisplayable, IMovable, IPossessable
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
            if (x < 0) x += 1000;
            if (x > 1000) x += -1000;

        }

        public void Tick(MovementControl.keyHeld direction)
        {
            switch (direction)
            {
                case MovementControl.keyHeld.right:{
                        if (xSpeed < 5){
                            xSpeed += 2.5f;
                        }
                        return;
                    }
                case MovementControl.keyHeld.left:{
                        if (xSpeed > -5){
                            xSpeed -= 2.5f;
                        }
                        return;
                    }
                default:{
                        if (xSpeed == 0f){
                            return;
                        }
                        if (xSpeed > 0f){
                            xSpeed -= 2.5f;
                        }
                        else{
                            xSpeed += 2.5f;
                        }
                        return;
                    }
            }
        }
    }
}