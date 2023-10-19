using AustralianFall.Classes.VisualElemetns.MovingElements;
using AustralianFall.Interfaces;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        Screen()
        {
            //staticCanvas;
        }
        private void OnGameLoopTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Your event handling logic here
        }

    }
}
