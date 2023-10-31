﻿using AustralianFall.Classes.Services;
using SkiaSharp;
using System.Collections;

namespace AustralianFall.Interfaces
{
    internal abstract class ILevelAssets
    {
        public static Random Random = new Random();
        internal abstract SKBitmap LoadBackground();
        //{
        //    var xd = this.GetType().Name;
        //    var nr = int.Parse(xd.Substring(3, xd.Length - 1));
        //    "RawImages/Backgrounds/Backgroundnr.jpg";
        //}
        internal abstract List<ITrap> LoadBackgroundElements();
        internal abstract List<ITrap> LoadMovingElements();
        internal abstract void loadTextures();
        bool texturesLoaded = false;
        internal Hashtable bitmaps {set; get;} = new ();
        protected async void LoadBitmaps(string path, int count, string extention = "png")
        {
            List<SKBitmap> maps = new();
            for(int i  = 0; i < count; i++) {
                string resourceID = $"RawImages/Entities/{this.GetType().Name}/{path}{i}.{extention}";
                maps.Add(await ImageLoader.LoadBitmapAsync(resourceID));
            }
            bitmaps.Add(path,maps);
            //bitmaps.Add(maps);
        }
    }
}
