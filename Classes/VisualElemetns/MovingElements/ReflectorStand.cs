﻿using AustralianFall.Interfaces;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AustralianFall.Interfaces.IDisplayable;

namespace AustralianFall.Classes.VisualElemetns.MovingElements
{
    internal class ReflectorStand : ITrap
    {
        public ReflectorStand(SKRect rc):base(rc)
        {
            Lamp = new ReflectorLamp(
                
                SKRect.Create(x:rc.Left+ rc.Width / 4, y:rc.Top - rc.Height / 4, width:rc.Width/2,height:rc.Height * 3 / 4)
                , new());

            var hbox = new Hitbox(new[] { new SKPoint(0.16668752f, 0.8996452f), new SKPoint(0.44450006f, 0.71737945f), new SKPoint(0.27781254f, 0.59353215f), new SKPoint(0.5679723f, 0.47669512f), new SKPoint(0.54636467f, 0.08178593f), new SKPoint(0.70996535f, 0.08412267f), new SKPoint(0.70996535f, 0.55848104f), new SKPoint(0.5617987f, 0.60755265f), new SKPoint(0.60501397f, 0.8178593f), new SKPoint(0.7963959f, 0.91833913f) });
            staticHitbox = new();
            staticHitbox.Points = new SKPoint[hbox.Points.Length];

            TranslateHitbox(hbox, ref staticHitbox);

            
        }

        public ReflectorLamp Lamp;


        //internal override Hitbox hitbox => new Hitbox(new[] { new SKPoint(0.17502187f, 0.91523373f), new SKPoint(0.5417344f, 0.97624934f), new SKPoint(0.82093596f, 0.9046224f), new SKPoint(0.61674374f, 0.83564824f), new SKPoint(0.58340627f, 0.6526015f), new SKPoint(0.9542859f, 0.39527488f), new SKPoint(0.85844064f, 0.12733687f), new SKPoint(0.5750719f, 0.01856996f), new SKPoint(0.08334375f, 0.22018667f), new SKPoint(0.075009376f, 0.45629045f), new SKPoint(0.28753594f, 0.5942387f), new SKPoint(0.2667f, 0.67647713f), new SKPoint(0.4375547f, 0.68708855f), new SKPoint(0.4417219f, 0.71892273f), new SKPoint(0.39171562f, 0.7481041f), new SKPoint(0.37504688f, 0.83034253f) });
        internal override Hitbox hitbox => staticHitbox;
        private Hitbox staticHitbox;
            public SKPoint RotationPoint => new SKPoint(0.49697575f * getHitboxRect().Width + getHitboxRect().Location.X,
                                                        0.21264341f * getHitboxRect().Height + getHitboxRect().Location.Y);
            
        //ReflectorLaser laser;
        protected override void DrawMainShape(SKCanvas canvas)
        {
            base.DrawMainShape(canvas);
            //laser.Draw(canvas);
#if ShowHitboxes
            SKPath path = new SKPath();
            var polyScalled = new SKPoint[hitbox.Points.Length];
            for (int i = 0; i < hitbox.Points.Length; i++)
            {
                polyScalled[i] = new SKPoint(hitbox.Points[i].X * scaleX, hitbox.Points[i].Y * scaleY);
            }
            path.AddPoly(polyScalled);
            SKPaint paint = new SKPaint() { Color = SKColors.SlateBlue , StrokeWidth = 10 };
            canvas.DrawPath(path, paint);
            paint.Color = SKColors.CadetBlue;
            canvas.DrawPoint(new(RotationPoint.X * scaleX, RotationPoint.Y * scaleY), paint);
#endif
        }
      

    }
}


