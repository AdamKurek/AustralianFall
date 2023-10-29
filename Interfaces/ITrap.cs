﻿using AustralianFall.Classes.VisualElemetns;
using SkiaSharp;

namespace AustralianFall.Interfaces
{
    internal abstract class ITrap:IDisplayable
    {
        internal enum TrapState { 
            sleeping,active,done
        }
        protected ITrap(Screen screen = null)
        {
            this.screen = screen;
        }

        
       
        internal Screen screen;
        internal TrapState activated = TrapState.sleeping;
        internal int TickOfActivation;
        internal int activationDistance = 200;
    }

}
