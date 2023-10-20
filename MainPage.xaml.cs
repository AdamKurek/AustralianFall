using AustralianFall.Classes.Services;
using AustralianFall.Classes.VisualElemetns;
using AustralianFall.Classes.VisualElemetns.MovingElements;
using AustralianFall.Interfaces;
using SkiaSharp;
using System.Timers;
#if WINDOWS
using System.Windows.Input;
using Windows.ApplicationModel.Core;
using Windows.System;
using Windows.UI.Core;
using Dapplo.Windows.Input.Keyboard;
using Dapplo.Windows.Input.Enums;
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
        public MainPage()
        {
            InitializeComponent();
            string resourceID = "fallin.png";
            //var bitmap = await ImageLoader.LoadBitmapAsync(resourceID);
            var bitmap = ImageLoader.LoadBitmap(resourceID).Result;
            australian = new(bitmap);
            PaintSurface.PaintSurface += OnPaintAsync;
            PaintSurface.SizeChanged += SizeChanged;
            PaintSurface.EnableTouchEvents = true;
            PaintSurface.Touch += touch;
            clockerTicker = new GameLoop();
            
            clockerTicker.TimerElapsed += OnGameLoopTimerElapsed;
            clockerTicker.Start();
            currentScreen = new();






#if WINDOWSxd

            var keyboardHook = KeyboardHook.KeyboardEvents;

            keyboardHook.Subscribe(combination =>
            {
                if (combination.Key == VirtualKeyCode.Right)
                {
                    australian.xSpeed = 5f;
                }
                else if (combination.Key == VirtualKeyCode.Left)
                {
                    australian.xSpeed = -5f;
                }
                else australian.xSpeed = 0;
                   
             });


            //keyboardHook.
            // Start observing
            
            // var keyboardObserver = new KeyboardObserver();
            //            SIL.Keyboarding.Keyboard.Controller;
#endif
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            australian.Alive = true;
            //Task.Run(() => gameLoaded());
        }

        private void keyDown() {
        //    if(args.VirtualKey == VirtualKey.Right)
        //    {
        //        australian.xSpeed = 5f;
        //    }
        //    else if(args.VirtualKey == VirtualKey.Left)
        //    {
        //        australian.xSpeed = -5f;
        //    }
        //    else
        //    {
        //        australian.xSpeed = 0f;
        //    }

        }

        private void touch(object sender, SkiaSharp.Views.Maui.SKTouchEventArgs e)
        {


            if (e.Location.X > IDisplayable.canvasWidth)
            {
                australian.xSpeed = -5;
            }
            else
            {
            }
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
        private async void OnPaintAsync(object sender, SkiaSharp.Views.Maui.SKPaintSurfaceEventArgs e)
        {



            if (currentlyDrawing) { return; }


            if (australian.Alive)
            {
#if WINDOWS
                if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Right))
                {
                    australian.xSpeed = 5f;
                }
                else if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Left))
                {
                    australian.xSpeed = -5f;
                }
                else
                {
                    australian.xSpeed = 0f;
                }
#endif
            }


            currentlyDrawing = true;
           
            //PaintSurface.InvalidateSurface();
            //canvas = currentScreen.getCanvas;
            var canvas = e.Surface.Canvas;
            canvas.Clear();
            //canvas.Save();
            ///var xd = currentScreen.getCanvas;
            australian.Draw(canvas);
            //canvas.Restore();

            currentlyDrawing = false;
        }
        private void OnGameLoopTimerElapsed(object sender, ElapsedEventArgs e)
        {
           

           australian.updatePosition();
            try { 
                PaintSurface?.InvalidateSurface();
            }catch (Exception ex) {; }

        }
    }
}