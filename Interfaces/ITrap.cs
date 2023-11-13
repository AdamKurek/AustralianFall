using AustralianFall.Classes.VisualElemetns;
using SkiaSharp;

namespace AustralianFall.Interfaces
{
    internal abstract class ITrap:IDisplayable
    {
        internal enum TrapState { 
            sleeping, active, done
        }
        protected ITrap() : base()
        {
        }
        protected ITrap(SKRect rc):base(rc)
        {
        }
       
        internal Screen screen;
        internal TrapState activated = TrapState.sleeping;
        internal int TickOfActivation;
        internal int activationDistance = 200;

        protected void TranslateHitbox(Hitbox hbox, ref Hitbox newHitbox){
            for (int i = 0; i < hbox.Points.Length; i++)  {
                newHitbox.Points[i] = new SKPoint(
                hbox.Points[i].X * getHitboxRect().Width + getHitboxRect().Location.X,
                hbox.Points[i].Y * getHitboxRect().Height + getHitboxRect().Location.Y);
            }
        }
        internal void SetBitmap(SKBitmap sKBitmap){
            Bitmap = sKBitmap;
        }

        public virtual bool DoesIntersectWithRect(SKRect rc) {
            return getHitboxRect().IntersectsWith(rc);
        }

        protected void DrawRotated(SKCanvas canvas, float rotation, SKPoint translate)
        {
            SKMatrix rotationMatrix = SKMatrix.CreateRotationDegrees(rotation);
            //float xTranslate = DrawingRectS.Width / 2 + DrawingRectS.Left;
            //float yTranslate = DrawingRectS.Height / 2 + DrawingRectS.Top;
            SKMatrix totalMatrix = SKMatrix.CreateTranslation(-translate.X, -translate.Y);
            totalMatrix = totalMatrix.PostConcat(rotationMatrix);
            totalMatrix = totalMatrix.PostConcat(SKMatrix.CreateTranslation(translate.X, translate.Y));
            canvas.Concat(ref totalMatrix);
            canvas.DrawBitmap(Bitmap, DrawingRectS);
            //base.DrawMainShape(canvas);
            canvas.ResetMatrix();

#if ShowHitboxes
            SKPath path = new SKPath();

            var polyScalled = new SKPoint[hitbox.Points.Length];

            for (int i = 0; i < hitbox.Points.Length; i++)
            {
                polyScalled[i] = new SKPoint(hitbox.Points[i].X * scaleX, hitbox.Points[i].Y * scaleY);
            }

            path.AddPoly(polyScalled);

            SKPaint paint = new SKPaint() { Color = SKColors.MediumVioletRed };
            canvas.DrawPath(path, paint);
#endif

        }
    }

}
