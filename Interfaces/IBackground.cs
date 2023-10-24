using SkiaSharp;

namespace AustralianFall.Interfaces
{
    internal abstract class ILevelAssets
    {
        internal abstract SKBitmap LoadBackground();
        internal abstract List<SKBitmap> LoadBackgroundElements();
        internal abstract List<List<SKBitmap>> LoadMovingElements();

    }
}
