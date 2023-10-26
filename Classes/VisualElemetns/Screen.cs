using AustralianFall.Classes.VisualElemetns.MovingElements;
using AustralianFall.Interfaces;
using SkiaSharp;
using System.Timers;
using AustralianFall.Classes.VisualElemetns.StaticVisuals.Backgrounds;

namespace AustralianFall.Classes.VisualElemetns
{
    internal class Screen
    {
        internal List<ITrap> Traps;
        //internal List<IMovable> Movables;
        //internal List<IAnimatedObject> Animations;
        internal ILevelAssets levelAssets;
        internal Australian australian;

        private SKBitmap staticBitmap;
        internal SKBitmap getBackgroundWithTraps { get {
                return staticBitmap;
            } 
        }
            
        internal void resize()
        {
            var info = staticBitmap.Info;
            info.Width = (int)IDisplayable.canvasWidth;
            info.Height = (int)IDisplayable.canvasHeight;
            staticBitmap = staticBitmap.Resize(info, SKFilterQuality.High);
        }
        internal Screen(int level)//todo make it async loading in background
        {

            //Type type = Type.GetType("AustralianFall.Classes.VisualElemetns.StaticVisuals.Backgrounds.Map1");
            string xd = $"AustralianFall.Classes.VisualElemetns.StaticVisuals.Backgrounds.Map{++level}";
            Type type = Type.GetType(xd);


            //Type type = Type.GetType($"AustralianFall.Classes.VisualElemetns.StaticVisuals.Backgrounds.Map{level}");
            if (type == null){
                type = Type.GetType("AustralianFall.Classes.VisualElemetns.StaticVisuals.Backgrounds.MapDefault");
            }
            levelAssets = (ILevelAssets)Activator.CreateInstance(type);
            
          
            {
                staticBitmap = levelAssets.LoadBackground();
                levelAssets.loadTextures();
                Traps = levelAssets.LoadMovingElements();
            }




        }
        private void OnGameLoopTimerElapsed(object sender, ElapsedEventArgs e)
        {
            foreach (IMovable movableElement  in Traps)
            {
                movableElement.updatePosition();
            }
        }

        internal void DrawTraps(SKCanvas canvas)
        {
            foreach (var t in Traps)
            {
                t.Draw(canvas);
            }
        }
    }
}
