using AustralianFall.Interfaces;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AustralianFall.Classes.VisualElemetns.MovingElements
{
    internal class Circle// : IDisplayable
    {
        internal float x = 500;
        internal float y = 500;
        internal float radiusX = 250;
        internal float radiusY = 250;/*
        internal float scaledX => x * (canvasWidth / defaultCanvasWidth);
        internal float scaledY => y * (canvasHeight / defaultCanvasHeight);
        internal float scaledRadiusX => radiusX * (canvasWidth / defaultCanvasWidth);
        internal float scaledRadiusY => radiusY * (canvasHeight / defaultCanvasHeight);

        protected override void DrawMainShape(SKCanvas canvas)
        {
            canvas.DrawOval(scaledX, scaledY, scaledRadiusX, scaledRadiusY, new SKPaint() { Color = SKColors.AliceBlue });
        }*/
    }
}
