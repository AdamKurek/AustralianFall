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
            c.Resize((float)PaintSurface.Width, (float)PaintSurface.Height);    
        }
        private async void OnPaintAsync(object sender, SkiaSharp.Views.Maui.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear();
            c.Draw(canvas);

            //svg.Load("fallingGuy.svg");

            // Draw the SVG document to the canvas
            //new SKFileStream("FallinGuyLogo")
            string resourceID = "fallin.png";
            var jdStream = FileSystem.Current.OpenAppPackageFileAsync(resourceID).Result;
            var data = SKData.Create(jdStream);
            var bitmap = SKBitmap.Decode(data);

            // Or create an SKImage from the stream
           // var image = SKImage.FromEncodedData(data);
            if(bitmap.DrawsNothing)
            {
                bitmap.Dispose();
            }
            try { 
                canvas.DrawBitmap(bitmap,new SKPoint(1,1));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            bitmap.Dispose();

            //canvas.DrawImage(image, new SKPoint(0, 0));
            //image.Dispose();
        }
    }
}