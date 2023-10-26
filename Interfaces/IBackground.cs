using AustralianFall.Classes.Services;
using SkiaSharp;
using System.Runtime.CompilerServices;

namespace AustralianFall.Interfaces
{
    internal abstract class ILevelAssets
    {
        internal abstract SKBitmap LoadBackground();
        internal abstract List<SKBitmap> LoadBackgroundElements();
        internal abstract List<ITrap> LoadMovingElements();
        internal abstract void loadTextures();
        bool texturesLoaded = false;
        internal  List<List<SKBitmap>> bitmaps {set; get;} = new List<List<SKBitmap>>();
        protected async void LoadBitmaps(string path, int count, string extention = "png")
        {
            List<SKBitmap> maps = new();
            for(int i  = 0; i < count; i++) {     
                string resourceID = $"RawImages/Entities/{this.GetType().Name}/{path}{i}.{extention}";
                maps.Add(await ImageLoader.LoadBitmapAsync(resourceID));
            }
            bitmaps.Add(maps);
        }
    }
}
