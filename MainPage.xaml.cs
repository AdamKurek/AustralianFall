using AustralianFall.Classes.Services;
using AustralianFall.Classes.VisualElemetns.MovingElements;
using AustralianFall.Interfaces;
using SkiaSharp;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Timers;

namespace AustralianFall
{
    public partial class MainPage : ContentPage
    {
        Circle c = new();
        Australian australian;
        GameLoop clockerTicker;
        bool currentlyDrawing = false;
        public MainPage()
        {
            InitializeComponent();
            string resourceID = "fallin.png";
            //var bitmap = await ImageLoader.LoadBitmapAsync(resourceID);
            var bitmap = ImageLoader.LoadBitmap(resourceID).Result;
            australian = new(bitmap);
            PaintSurface.PaintSurface += OnPaintAsync;
            PaintSurface.SizeChanged += SizeChanged;
            clockerTicker = new GameLoop();
            
            clockerTicker.TimerElapsed += OnGameLoopTimerElapsed;
            clockerTicker.Start();
        }


        private void SizeChanged(object sender, EventArgs e)
        {
            //c.Resize((float)PaintSurface.Width, (float)PaintSurface.Height);
            IDisplayable.canvasWidth = (float)PaintSurface.Width;
            IDisplayable.canvasHeight = (float)PaintSurface.Height;
        }
        private async void OnPaintAsync(object sender, SkiaSharp.Views.Maui.SKPaintSurfaceEventArgs e)
        {
            if (currentlyDrawing) { return; }
            currentlyDrawing = true;
            var canvas = e.Surface.Canvas;
            canvas.Clear();
            australian.Draw(canvas);
            currentlyDrawing = false;
        }
        private void OnGameLoopTimerElapsed(object sender, ElapsedEventArgs e)
        {
            australian.updatePosition();
            PaintSurface.InvalidateSurface();

        }
    }
}