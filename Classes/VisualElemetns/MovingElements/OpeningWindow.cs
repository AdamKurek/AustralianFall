using AustralianFall.Interfaces;
using Microsoft.Maui.Controls;
using SkiaSharp;

namespace AustralianFall.Classes.VisualElemetns.MovingElements
{
    internal class OpeningWindow: IAnimatedObject 
    {
        public OpeningWindow(SKRect Rect, bool flip = false) : base(Rect,new Hitbox[]{
            new Hitbox (new[]{ new SKPoint(0.5289285f, 0.2625896f), new SKPoint(0.98130155f, 0.26595613f), new SKPoint(0.9836214f, 0.7036055f), new SKPoint(0.5312484f, 0.70023894f) }),
            new Hitbox(new[] { new SKPoint(0.5289285f, 0.26595613f), new SKPoint(0.7005983f, 0.13802786f), new SKPoint(0.6982784f, 0.2625896f), new SKPoint(0.98130155f, 0.26595613f), new SKPoint(0.9836214f, 0.7036055f), new SKPoint(0.5289285f, 0.70023894f) }),
            new Hitbox(new[]{new SKPoint(0.5289285f, 0.2625896f),new SKPoint(0.6008442f, 0.08752987f),new SKPoint(0.6008442f, 0.2625896f),new SKPoint(0.9836214f, 0.26932266f),new SKPoint(0.9836214f, 0.7036055f),new SKPoint(0.5289285f, 0.70023894f)}),
            new Hitbox(new[]{new SKPoint(0.46165252f, 0.1817928f),new SKPoint(0.5312484f, 0.2625896f),new SKPoint(0.586925f, 0.25922307f),new SKPoint(0.5962045f, 0.23565733f),new SKPoint(0.65188116f, 0.2423904f),new SKPoint(0.6681202f, 0.2625896f),new SKPoint(0.9789817f, 0.26595613f),new SKPoint(0.9836214f, 0.706972f),new SKPoint(0.5335682f, 0.7036055f),new SKPoint(0.4686121f, 0.605976f)}),
            new Hitbox(new[]{new SKPoint(0.3827772f, 0.12456173f),new SKPoint(0.5335682f, 0.26595613f),new SKPoint(0.98130155f, 0.26595613f),new SKPoint(0.9836214f, 0.706972f),new SKPoint(0.5289285f, 0.7036055f),new SKPoint(0.38509706f, 0.5756772f),new SKPoint(0.38509706f, 0.5386453f),new SKPoint(0.35725874f, 0.5487449f),new SKPoint(0.3410197f, 0.52854574f),new SKPoint(0.35957858f, 0.46458158f),new SKPoint(0.38509706f, 0.46458158f)}),
            new Hitbox(new[]{new SKPoint(0.2667841f, 0.19862546f),new SKPoint(0.5312484f, 0.2625896f),new SKPoint(0.98130155f, 0.26932266f),new SKPoint(0.9836214f, 0.7036055f),new SKPoint(0.5335682f, 0.70023894f),new SKPoint(0.4755717f, 0.6766732f),new SKPoint(0.3827772f, 0.7675696f),new SKPoint(0.36653817f, 0.80796796f),new SKPoint(0.30854163f, 0.85509944f),new SKPoint(0.29694232f, 0.83153373f),new SKPoint(0.3178211f, 0.7810357f),new SKPoint(0.35029915f, 0.77430266f),new SKPoint(0.41757512f, 0.6665736f),new SKPoint(0.26910397f, 0.62280864f)}),
        },flip) { 
        }


    }
}
