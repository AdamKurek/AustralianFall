﻿using AustralianFall.Classes.Services;
using AustralianFall.Interfaces;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AustralianFall.Classes.VisualElemetns.MovingElements
{
    internal class Australian : IDisplayable, ITickable, IPossessable
    {

        //internal static int tick = 0;
        internal Australian(SKBitmap b) : base(new(475, 1300, 525, 1400))
        {
            var info = new SKImageInfo() { Width = 50, Height = 50, ColorSpace = b.ColorSpace };
            Bitmap = new SKBitmap(50, 50);
            b.ScalePixels(Bitmap, SKFilterQuality.None);
            //DrawingRect.Location = new(475, 1000);
           // DrawingRect.Location.X = 0;
            //bitmap.Info = info;
            //bitmap.Resize()
        }


        internal float xSpeed = 0f;
        internal float ySpeed = -7f;

        public float X => DrawingRect.Location.X;
        public float Y => DrawingRect.Location.Y;//1000 + (ySpeed * tick);
        //DrawingRect.Location.Y;

        public bool Alive { get; internal set; } = false;

       

        internal event EventHandler ChangeScreen;
        public void Tick(){
            if (Alive){
                //tick++;
                AddOffset(xSpeed, ySpeed);
            }
            if (Y < 0){
                //DrawingRect.Offset(0, 1000f);
                //SetLocation(450f, 1000f);
                AddOffset(0, 1000f);
                //tick = 0;
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