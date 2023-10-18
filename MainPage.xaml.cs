using SkiaSharp;

namespace AustralianFall
{
    public partial class MainPage : ContentPage
    {
        Circle c = new();
        public MainPage()
        {
            InitializeComponent();


            PaintSurface.PaintSurface += OnPaint;
            PaintSurface.SizeChanged += SizeChanged;
        }

        private void SizeChanged(object sender, EventArgs e)
        {
            c.Resize((float)PaintSurface.Width, (float)PaintSurface.Height);    
        }

        private void OnPaint(object sender, SkiaSharp.Views.Maui.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear();
            c.Draw(canvas);

        }
    }
}