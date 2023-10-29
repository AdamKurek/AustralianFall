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
        private SKBitmap _Bitmap;
        protected virtual SKBitmap Bitmap { get => _Bitmap; set => _Bitmap = flipped ? FlipBitmap(value) : value; }
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

        internal virtual void Flip()
        {
            Bitmap = FlipBitmap(Bitmap);
            //Bitmap = RotateBitmap(Bitmap, 180);
            //Thread.Sleep(1000);
        
        }
        internal bool flipped = false;
        internal static SKBitmap RotateBitmap(SKBitmap bitmap, double angle)
        {
            double radians = Math.PI * angle / 180;
            float sine = (float)Math.Abs(Math.Sin(radians));
            float cosine = (float)Math.Abs(Math.Cos(radians));
            int originalWidth = bitmap.Width;
            int originalHeight = bitmap.Height;
            int rotatedWidth = (int)(cosine * originalWidth + sine * originalHeight);
            int rotatedHeight = (int)(cosine * originalHeight + sine * originalWidth);

            var rotatedBitmap = new SKBitmap(rotatedWidth, rotatedHeight);

            using (var surface = new SKCanvas(rotatedBitmap))
            {
                surface.Clear();
                surface.Translate(rotatedWidth / 2, rotatedHeight / 2);
                surface.RotateDegrees((float)angle);
                surface.Translate(-originalWidth / 2, -originalHeight / 2);
                surface.DrawBitmap(bitmap, new SKPoint());
            }

            return rotatedBitmap;
        }

        internal static SKBitmap FlipBitmap(SKBitmap bitmap)
        {
            var flippedBitmap = new SKBitmap(bitmap.Width, bitmap.Height);
            using (var surface = new SKCanvas(flippedBitmap))
            {
                surface.Clear();
                var matrix = SKMatrix.CreateScale(-1, 1);
                matrix.TransX = bitmap.Width;

                surface.SetMatrix(matrix);

                surface.DrawBitmap(bitmap, new SKPoint());
            }

            return flippedBitmap;
        }
        internal class Hitbox
        {
            internal List<SKRect> Points;
        }
    }
}