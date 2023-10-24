using SkiaSharp;

namespace AustralianFall.Interfaces
{

    internal abstract class IDisplayable : SKDrawable
    {

        static internal float defaultCanvasWidth = 1000;
        static internal float defaultCanvasHeight = 1000;
        internal static float canvasWidth = 1000;
        internal static float canvasHeight = 1000;
        protected float scaleX => (canvasWidth / defaultCanvasWidth);
        protected float scaleY => (canvasHeight / (defaultCanvasHeight));
        protected SKRect Rect;
        internal void Resize(float Width, float Height)
        {
            if (Width <= 0 || Height <= 0)
                return;
            ResizePrecize(Width, Height);
           // canvasWidth = Width;
           // canvasHeight = Height;
        }
        protected virtual void ResizePrecize(float Width, float Height) { }
        internal void Draw(SKCanvas canvas)
        {
            DrawMainShape(canvas);
        }
        protected abstract void DrawMainShape(SKCanvas canvas);

        internal class Hitbox
        {
            internal List<SKRect> Points;
        }
    }
}