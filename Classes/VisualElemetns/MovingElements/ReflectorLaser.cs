using AustralianFall.Interfaces;
using SkiaSharp;

namespace AustralianFall.Classes.VisualElemetns.MovingElements
{
    internal class ReflectorLaser: ITrap, ITickable
    {
        int rotation = -30;
        
        SKPoint laserPoint;
        public ReflectorLaser(SKPoint centre, bool flip = false) : base()
        {

            //laserPoint = centre;
            laserPoint = centre;
        }
        protected override void DrawMainShape(SKCanvas canvas)
        {
            var paint = new SKPaint();
            paint.StrokeWidth = 5;
            paint.Style = SKPaintStyle.StrokeAndFill;
            if(laserWidth < 3)
            {
                paint.Color = new SKColor(255, 255, 255, 128);
            }else{
                paint.Color = new SKColor(240, 20, 10, 216);
            }
            if (endXL == 0)
            {
                var rotationRadians = rotation * MathF.PI / 180; 
                var endX = ((MathF.Cos(rotationRadians) * lineLength) + laserPoint.X);
                var endY = ((MathF.Sin(rotationRadians) * lineLength) + laserPoint.Y);
                var endPoint = new SKPoint(endX * scaleX, endY * scaleY);
                canvas.DrawLine(new(laserPoint.X * scaleX, laserPoint.Y * scaleY), new(endPoint.X, endPoint.Y), paint);
                return;
            }
            var trianglePoints = new SKPoint[]
            {
                new SKPoint(laserPoint.X * scaleX, laserPoint.Y * scaleY),
                new SKPoint(endXL* scaleX, endYL * scaleY),
                new SKPoint(endXR* scaleX, endYR * scaleY)
            };
            SKPath path = new SKPath();
            path.AddPoly(trianglePoints);
            canvas.DrawPath(path, paint);
        }
        internal float lineLength = 1500f;
        float laserWidth = 0;
        bool laserGrowing = true;
        float endXL;
        float endYL;
        float endXR;
        float endYR;
        internal override Hitbox hitbox => new(laserWidth<3? Array.Empty<SKPoint>() : new SKPoint[] {
        new(laserPoint.X, laserPoint.Y),
        new(endXL,endYL),
        new(endXR,endYR),
        } ) ;
        public void Tick()
        {
            rotation--;

            if(laserGrowing)
            {
                laserWidth += 0.25f;
                if (laserWidth > 5) {
                    laserGrowing = false;   
                }
            }
            else
            {
                laserWidth -= 0.25f;
                if (laserWidth <= 0)
                {
                    laserGrowing = true;
                }
            }

            var rotationRadiansL = (rotation + laserWidth) * MathF.PI / 180;
            var rotationRadiansR = (rotation - laserWidth) * MathF.PI / 180;

            endXL = ((MathF.Cos(rotationRadiansL) * lineLength) + laserPoint.X);
            endYL = ((MathF.Sin(rotationRadiansL) * lineLength) + laserPoint.Y);
            endXR = ((MathF.Cos(rotationRadiansR) * lineLength) + laserPoint.X);
            endYR = ((MathF.Sin(rotationRadiansR) * lineLength) + laserPoint.Y);
        }
        
        public override bool DoesIntersectWithRect(SKRect rc)
        {
            return true;
        }
    }
}
