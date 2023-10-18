using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AustralianFall.Interfaces
{

    internal abstract class IDisplayable : SKDrawable
    {

        static internal float defaultCanvasWidth = 1000;
        static internal float defaultCanvasHeight = 1000;
        internal float canvasWidth = 1000;
        internal float canvasHeight = 1000;

        protected float scaleX => (canvasWidth / defaultCanvasWidth);

        protected float scaleY => (canvasHeight / (defaultCanvasHeight));
        internal void Resize(float Width, float Height)
        {
            if (Width <= 0 || Height <= 0)
                return;
            ResizePrecize(Width, Height);
            canvasWidth = Width;
            canvasHeight = Height;
        }
        protected virtual void ResizePrecize(float Width, float Height) { }

        internal void Draw(SKCanvas canvas)
        {
            DrawMainShape(canvas);
        }
        protected abstract void DrawMainShape(SKCanvas canvas);
    }
}