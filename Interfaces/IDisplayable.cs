﻿using Clipper2Lib;
using SkiaSharp;
using System;

namespace AustralianFall.Interfaces
{

    internal abstract class IDisplayable : SKDrawable
    {
        protected IDisplayable(){}
        protected IDisplayable(SKRect rc) 
        {
            _DrawingRect = rc;
        }
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


        protected Hitbox FlipHitbox(Hitbox hitbox)
        {
            return hitbox;//TODODODODODODODDODO
        }

        private SKBitmap _Bitmap;

        protected virtual SKBitmap Bitmap
        {
            get => _Bitmap;  set
            {
                _Bitmap = flipped ? FlipBitmap(value) : value;
            }
        }
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

#if ShowHitboxes
            SKPath path = new SKPath();

            var polyScalled = new SKPoint[hitbox.Points.Length];

            for(int i = 0;i < hitbox.Points.Length;i++)
            {
                polyScalled[i] = new SKPoint(hitbox.Points[i].X * scaleX, hitbox.Points[i].Y * scaleY);
            }

            path.AddPoly(polyScalled);
            
            SKPaint paint = new SKPaint() { Color = SKColors.MediumVioletRed};
            canvas.DrawPath(path, paint);
#endif
        }

        protected virtual void AddOffset(float xSpeed, float ySpeed)
        {
            _DrawingRect.Offset(xSpeed, ySpeed);
            _DrawingRectS.Offset(xSpeed * scaleX, ySpeed*scaleY);
        }

        internal SKRect getHitboxRect()
        {
            return DrawingRect;
        }
        internal virtual Hitbox hitbox { get => getDefaultHitbox();}
        internal virtual Hitbox getDefaultHitbox()
        {
            return  new Hitbox() { Points = new SKPoint[] { 
                    new(DrawingRect.Location.X, DrawingRect.Location.Y),
                    new(DrawingRect.Location.X + DrawingRect.Width, DrawingRect.Location.Y), 
                    new(DrawingRect.Location.X + DrawingRect.Width, DrawingRect.Location.Y + DrawingRect.Height),
                    new(DrawingRect.Location.X, DrawingRect.Location.Y + DrawingRect.Height) }
            };
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
            public Hitbox(){
                Points = Array.Empty<SKPoint>();
            }
            public Hitbox(SKPoint[] hitbox)
            {
                Points = hitbox;
            }
            internal SKPoint[] Points;
            public static Hitbox operator +(Hitbox a, SKPoint b)
            {
                var newlist = new SKPoint[a.Points.Length];
                for(int i = 0;i<a.Points.Length;i++)
                {
                    newlist[i] = new(a.Points[i].X + b.X, a.Points[i].Y + b.Y);
                }
                return new Hitbox(newlist);
            }

            public static Hitbox Rotated(Hitbox target, SKPoint center, float angleDegrees)
            {
                float angleRadians = angleDegrees / 180 * MathF.PI;

                SKPoint[] rotatedPoints = new SKPoint[target.Points.Length];

                for (int i = 0; i < target.Points.Length; i++)
                {
                    float xOffset = target.Points[i].X - center.X;
                    float yOffset = target.Points[i].Y - center.Y;

                    float rotatedX = center.X + (xOffset * MathF.Cos(angleRadians) - yOffset * MathF.Sin(angleRadians));
                    float rotatedY = center.Y + (xOffset * MathF.Sin(angleRadians) + yOffset * MathF.Cos(angleRadians));

                    rotatedPoints[i] = new SKPoint(rotatedX, rotatedY);
                }

                return new(rotatedPoints);
            }
            public static Path64 SKPointArrayToPath64(SKPoint[] points)
            {
                Path64 path = new Path64();
                foreach (SKPoint point in points)
                {
                    long x = (long)Math.Round(point.X * 16384);
                    long y = (long)Math.Round(point.Y * 16384);
                    path.Add(new Point64(x, y));
                }
                return path;
            }
            public static Path64 SKPointArrayToPath64(List<SKPoint> points)
            {
                Path64 path = new Path64();
                foreach (SKPoint point in points)
                {
                    long x = (long)Math.Round(point.X * 16384);
                    long y = (long)Math.Round(point.Y * 16384);
                    path.Add(new Point64(x, y));
                }
                return path;
            }
            public static List<SKPoint[]> Path64ToSKPointArrayList(Path64 path)
            {
                List<SKPoint[]> list = new List<SKPoint[]>();
                SKPoint[] points = new SKPoint[path.Count];
                for (int i = 0; i < path.Count; i++)
                {
                    points[i] = new SKPoint((float)path[i].X / 16384, (float)path[i].Y / 16384);
                }
                list.Add(points);
                return list;
            }

            public static double calculateCommonArea(Hitbox p1, Hitbox[] p2)
            {
                Paths64 subject = new Paths64();
                Paths64 clip = new Paths64();
                subject.Add(SKPointArrayToPath64(p1.Points));
                foreach (var figure in p2)
                {
                    clip.Add(SKPointArrayToPath64(figure.Points));
                }
                Paths64 commonArea = Clipper.Intersect(subject, clip, FillRule.NonZero);
                Clipper.Area(commonArea);
                List<SKPoint[]> result = new List<SKPoint[]>();
                foreach (var path in commonArea)
                {
                    result.AddRange(Path64ToSKPointArrayList(path));
                }
                return Clipper.Area(commonArea);
            }
        }
    }
}