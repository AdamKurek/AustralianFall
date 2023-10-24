using AustralianFall.Classes.VisualElemetns.MovingElements;
using AustralianFall.Interfaces;
using SkiaSharp;
using System.Timers;

namespace AustralianFall.Classes.VisualElemetns
{
    internal class Screen
    {
        internal List<IMovable> movableElements;
        internal List<IDisplayable> staticElements;
        internal ILevelAssets levelAssets;
        internal Australian australian;

        private SKBitmap staticBitmap;
        internal SKBitmap getCanvas { get {
                return staticBitmap; 
            } 
        }
            
        internal Screen(int level)
        {

            //Type type = Type.GetType("Namespace.ClassName");
            //object instance = Activator.CreateInstance(type);
        }
        private void OnGameLoopTimerElapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var movableElement in movableElements)
            {
                movableElement.updatePosition();
            }
        }

    }
}
