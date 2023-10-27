using AustralianFall.Interfaces;
using Microsoft.Maui.Controls;
using SkiaSharp;

namespace AustralianFall.Classes.VisualElemetns.MovingElements
{
    internal class OpeningWindow: IAnimatedObject
    {
        public OpeningWindow(SKRect Rect) { 
            DrawingRect = Rect;
        }

       

        protected override SKBitmap Bitmap 
        {
            get 
            {

                switch(activated)
                {
                    case TrapState.sleeping:
                        {
                            if (DrawingRect.Bottom + activationDistance > 1000 - (screen.tick * 5))
                            {
                                TickOfActivation = screen.tick;
                                activated = TrapState.active;
                                goto case TrapState.active;
                            }
                            return animationFrames[0];
                        }
                    case TrapState.active:
                        {
                            int frame = ((screen.tick) - TickOfActivation) * 5 / (activationDistance / States);
                            if(frame == States) {
                                activated = TrapState.done;
                                return animationFrames[States - 1];
                            }
                            return animationFrames[frame];
                        }
                    default:
                        {
                            return animationFrames[States-1];
                        }
                }
            }
            set => base.Bitmap = value; 
        }
    }
}
