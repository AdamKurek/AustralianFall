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


        internal Australian(SKBitmap b){
            var info = new SKImageInfo() { Width = 50, Height = 50, ColorSpace = b.ColorSpace };
            bitmap = new SKBitmap(50, 50);
            b.ScalePixels(bitmap, SKFilterQuality.None);
            Rect.Location = new(475, 1000);
            //bitmap.Info = info;
            //bitmap.Resize()
        }

        internal float xSpeed = 0f;
        internal float ySpeed = -5f;

        public float x => Rect.Location.X;
        public float y => Rect.Location.Y;

        public bool Alive { get; internal set; } = false;

        protected override void DrawMainShape(SKCanvas canvas){
            canvas.DrawBitmap(bitmap, x * scaleX, y * scaleY);
        }

        internal event EventHandler ChangeScreen;
        public void updatePosition(){
            Rect.Offset(xSpeed, ySpeed);
            if (y < 0){
                Rect.Offset(0, 1000f);
                ChangeScreen.Invoke(this, new EventArgs());
            }
        }

        public void Tick(MovementControl.keyHeld direction) {
            switch (direction){
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