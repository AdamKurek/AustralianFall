using AustralianFall.Classes.VisualElemetns.MovingElements;
using AustralianFall.Interfaces;
using SkiaSharp;
using System.Timers;

namespace AustralianFall.Classes.VisualElemetns
{
    internal class Screen
    {
        internal List<IMovable> movableElements;
        internal List<IDisplayable> staticTraps;
        //internal Background background;
        internal Australian australian;

        private SKCanvas staticCanvas;
        internal SKCanvas getCanvas { get {
                staticCanvas.Save();
                return staticCanvas; 
            } 
        }
            
        internal Screen()
        {
            //staticCanvas;
        }
        private void OnGameLoopTimerElapsed(object sender, ElapsedEventArgs e)
        {
            staticCanvas.Restore();
            foreach (var movableElement in movableElements)
            {
                movableElement.updatePosition();
            }
        }

    }
}
