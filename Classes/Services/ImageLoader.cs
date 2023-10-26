using SkiaSharp;

namespace AustralianFall.Classes.Services
{
    internal static class ImageLoader
    {
        internal static async Task<SKBitmap> LoadBitmapAsync(string resourceID) => await LoadBitmap(resourceID);

        internal static async Task<SKBitmap> LoadBitmap(string resourceID)
        {
            var jdStream = await Task.FromResult(FileSystem.Current.OpenAppPackageFileAsync(resourceID));
            var data = SKData.Create(jdStream.Result);
            var bitmap = SKBitmap.Decode(data);
            return bitmap;
        }
    }
}
