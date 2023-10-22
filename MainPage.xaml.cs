using AustralianFall.Classes.Services;
using AustralianFall.Classes.VisualElemetns;
using AustralianFall.Classes.VisualElemetns.MovingElements;
using AustralianFall.Interfaces;
using Microsoft.Maui.Platform;
using SkiaSharp;
using System.Timers;
#if ANDROID
#endif

namespace AustralianFall
{
    public partial class MainPage : ContentPage
    {
        Circle c = new();
        Australian australian;
        GameLoop clockerTicker;
        bool currentlyDrawing = false;
        Screen currentScreen;
        SKPaint paint;
        MovementControl controller;
        public MainPage()
        {
            InitializeComponent();
            string resourceID = "fallin.png";
            //var bitmap = await ImageLoader.LoadBitmapAsync(resourceID);
            var bitmap = ImageLoader.LoadBitmap(resourceID).Result;
            australian = new(bitmap);
            PaintSurface.PaintSurface += OnPaintAsync;
            PaintSurface.SizeChanged += SizeChanged;
           // PaintSurface.Touch += touch;
            PaintSurface.EnableTouchEvents = true;
            TapGestureRecognizer rec = new TapGestureRecognizer();
            controller = new(australian);

            clockerTicker = new GameLoop();

            clockerTicker.TimerElapsed += OnGameLoopTimerElapsed;
            clockerTicker.Start();
            currentScreen = new();

#if ANDROID || IOS

            var leftButton = new Button
            {
                Opacity = 0.0,
                BackgroundColor = Colors.Green,
                
            };
            leftButton.Pressed += LeftTap;
            leftButton.Released += LeftRelease;

            var rightButton = new Button{
                Opacity = 0,
                BackgroundColor = Colors.Transparent
            };
            
            rightButton.Pressed += RightTap;
            rightButton.Released += RightRelease;

            BackgroundGrid.Add(leftButton,0,0);
            BackgroundGrid.Add(rightButton, 1, 0);

#endif


        }
#if ANDROID || IOS

      
        private void LeftTap(object sender, EventArgs e)
        {
            controller.CurrentKeyHeld = MovementControl.keyHeld.left;
        }
        private void LeftRelease(object sender, EventArgs e)
        {
            if(controller.CurrentKeyHeld == MovementControl.keyHeld.left){
                controller.CurrentKeyHeld = MovementControl.keyHeld.none;
            }
        }

        private void RightTap(object sender, EventArgs e)
        {
            controller.CurrentKeyHeld = MovementControl.keyHeld.right;
        }
        private void RightRelease(object sender, EventArgs e)
        {
            if(controller.CurrentKeyHeld == MovementControl.keyHeld.right){
                controller.CurrentKeyHeld = MovementControl.keyHeld.none;
            }
        }
        

   
#endif


        protected override void OnAppearing() {
            base.OnAppearing();
            australian.Alive = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            clockerTicker.Stop();
        }

 
        private async Task gameLoaded()
        {
         //   base.
            //var window = CoreWindow.GetForCurrentThread();
            //window.KeyDown += keyDown;
        }

        private void SizeChanged(object sender, EventArgs e)
        {
            //c.Resize((float)PaintSurface.Width, (float)PaintSurface.Height);
            IDisplayable.canvasWidth = (float)PaintSurface.Width;
            IDisplayable.canvasHeight = (float)PaintSurface.Height;
        }
        int frames = 0;
        int frames2 = 0;
        private void OnPaintAsync(object sender, SkiaSharp.Views.Maui.SKPaintSurfaceEventArgs e)
        {
            frames++;

            if (currentlyDrawing) { return; }
#if WINDOWS
            controller.tick();
#endif
            frames2++;

           
            currentlyDrawing = true;
            var canvas = e.Surface.Canvas;
            canvas.Clear();
            australian.Draw(canvas);
            currentlyDrawing = false;
        }
        private void OnGameLoopTimerElapsed(object sender, ElapsedEventArgs e)
        {
#if ANDROID || IOS
            controller.tick();
#endif
            australian.updatePosition();
            // try { 

            Dispatcher.Dispatch(() =>
            {
                PaintSurface.InvalidateSurface();
            });
           // .InvalidateSurface();
            //catch (Exception ex) {; }

        }
    }
}