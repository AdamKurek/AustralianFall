using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AustralianFall.Classes
{
    internal static class ImageLoader
    {
        internal static async Task<SKBitmap> LoadBitmapAsync(string resourceID = "fallin.png") {

            var jdStream = await Task.FromResult(FileSystem.Current.OpenAppPackageFileAsync(resourceID));
            var data = SKData.Create(jdStream.Result);
            var bitmap = SKBitmap.Decode(data);
            return bitmap;
        }

        /*
            var jdStream = await FileSystem.Current.OpenAppPackageFileAsync(resourceID);
            var data = SKData.Create(await jdStream.ReadAsync());
            var bitmap = SKBitmap.Decode(data);
            return bitmap;
}
         */
        //internal static async Task<SKBitmap> LoadBitmapAsync(string resourceID = "fallin.png")
        //{
        //    var jdStream = await FileSystem.Current.OpenAppPackageFileAsync(resourceID);
        //    var data = SKData.Create(jdStream);
        //    var bitmap = SKBitmap.Decode(data);
        //    return Task.FromResult(bitmap);
        //}
    }
}
