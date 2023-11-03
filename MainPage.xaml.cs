using AustralianFall.Classes.Services;
using AustralianFall.Classes.VisualElemetns;
using AustralianFall.Classes.VisualElemetns.MovingElements;
using AustralianFall.Interfaces;
using SkiaSharp;
using System.Timers;
#if ANDROID
#endif

namespace AustralianFall
{
    public partial class MainPage : ContentPage
    {

     
    Australian australian;
        GameLoop clockerTicker;
        bool currentlyDrawing = false;
        Screen currentScreen;
        Screen nextScreen;
        MovementControl controller;
        int screenIndex = 0;
        public MainPage()
        {
            InitializeComponent();
            string resourceID = "RawImages/Entities/fallin.png";
            var bitmap = ImageLoader.LoadBitmap(resourceID).Result;
            australian = new(bitmap);
            australian.ChangeScreen += ChangeScreen;
            PaintSurface.PaintSurface += OnPaintAsync;
            PaintSurface.SizeChanged += SizeChanged;
            PaintSurface.EnableTouchEvents = true;
            TapGestureRecognizer rec = new TapGestureRecognizer();
            controller = new(australian);
            currentScreen = new(screenIndex) { australian = australian };
            nextScreen = new(++screenIndex) { australian = australian };
            clockerTicker = new GameLoop();
            clockerTicker.TimerElapsed += OnGameLoopTimerElapsed;
            clockerTicker.TimerElapsed += currentScreen.OnGameTick;
        

            clockerTicker.Start();
            //SkiaSharp.Views.Maui.Controls.SKGLView ciew = new SkiaSharp.Views.Maui.Controls.SKGLView();
            //ciew.PaintSurface += onPaintskg;
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

        private void ChangeScreen(object sender, EventArgs e)
        {
            clockerTicker.TimerElapsed -= currentScreen.OnGameTick;
            currentScreen = nextScreen;
            nextScreen = new Screen(++screenIndex) {australian = australian};
            clockerTicker.TimerElapsed += currentScreen.OnGameTick;
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
            currentScreen.resize();
            nextScreen.resize();
            australian.Resize();

        }

        private void OnPaintAsync(object sender, SkiaSharp.Views.Maui.SKPaintSurfaceEventArgs e)
        {
            if (currentlyDrawing) { return; }
#if WINDOWS
            controller.tick();
#endif
            currentlyDrawing = true;
            var canvas = e.Surface.Canvas;
            canvas.Clear();

            e.Surface.Canvas.DrawBitmap(currentScreen.getBackgroundWithTraps,0f,0f);
            currentScreen.DrawTraps(canvas);
            australian.Draw(canvas);
            canvas.DrawText(currentScreen.levelAssets.GetType().ToString(), new(100, 100), new() { Color = SKColors.IndianRed });
            currentlyDrawing = false;
        }
        private void OnGameLoopTimerElapsed(object sender, ElapsedEventArgs e)
        {
#if ANDROID || IOS
            controller.tick();
#endif
            australian.Tick();
            currentScreen.checkColisions();
            Dispatcher.Dispatch(PaintSurface.InvalidateSurface);
        }
    }
}