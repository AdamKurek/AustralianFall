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
        
        private SKRect _DrawingRect;
        protected SKRect DrawingRect { 
            get {
                return _DrawingRect;
            } 
            set 
            {
                _DrawingRect = value;
                RescaleRect();
            }
        }
        private void RescaleRect()
        {
            _DrawingRectS = new SKRect(_DrawingRect.Left * scaleX, _DrawingRect.Top * scaleY, _DrawingRect.Right * scaleX, _DrawingRect.Bottom * scaleY);
        }
        protected SKRect _DrawingRectS;
        protected SKRect DrawingRectS
        {
            get
            {
                var xd = _DrawingRectS;
                return xd;
            }
            set
            {
                _DrawingRectS = value;
            }
        }

        protected void SetLocation(float XX, float YY)
        {
            _DrawingRect.Location = new SKPoint(XX, YY);
            _DrawingRectS.Location = new SKPoint(XX * scaleX, YY * scaleY);
        }
        protected virtual SKBitmap Bitmap { get; set; }
        internal void Resize()
        {
           // if (Width <= 0 || Height <= 0)
           //     return;
            ResizePrecize(canvasWidth, canvasHeight);
            RescaleRect();
           // canvasWidth = Width;
           // canvasHeight = Height;
        }
        protected virtual void ResizePrecize(float Width, float Height) { }
        internal void Draw(SKCanvas canvas)
        {
            DrawMainShape(canvas);
        }
        protected virtual void DrawMainShape(SKCanvas canvas)
        {
            canvas.DrawBitmap(Bitmap, DrawingRectS);
        }

        protected void AddOffset(float xSpeed, float ySpeed)
        {
            _DrawingRect.Offset(xSpeed, ySpeed);
            _DrawingRectS.Offset(xSpeed * scaleX, ySpeed*scaleY);
        }
        internal class Hitbox
        {
            internal List<SKRect> Points;
        }
    }
}