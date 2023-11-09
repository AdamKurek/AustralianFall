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
    }

}
