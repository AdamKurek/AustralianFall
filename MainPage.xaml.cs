using AustralianFall.Classes;
using AustralianFall.Interfaces;
using SkiaSharp;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace AustralianFall
{
    public partial class MainPage : ContentPage
    {
        Circle c = new();
        public MainPage()
        {
            InitializeComponent();


            PaintSurface.PaintSurface += OnPaintAsync;
            PaintSurface.SizeChanged += SizeChanged;
        }

        private void SizeChanged(object sender, EventArgs e)
        {
            //c.Resize((float)PaintSurface.Width, (float)PaintSurface.Height);
            IDisplayable.canvasWidth = (float)PaintSurface.Width;
            IDisplayable.canvasHeight = (float)PaintSurface.Height;
        }
        private async void OnPaintAsync(object sender, SkiaSharp.Views.Maui.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear();
            c.Draw(canvas);
            string resourceID = "fallin.png";
            var bitmap = await ImageLoader.LoadBitmapAsync(resourceID);
            // Or create an SKImage from the stream
           // var image = SKImage.FromEncodedData(data);
            
            canvas.DrawBitmap(bitmap,new SKPoint(1,1));
            bitmap.Dispose();

            //canvas.DrawImage(image, new SKPoint(0, 0));
            //image.Dispose();
        }
    }
}