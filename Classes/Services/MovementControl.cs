using AustralianFall.Interfaces;

namespace AustralianFall.Classes.Services
{
    internal class MovementControl
    {
        public MovementControl(IPossessable posesed)
        {
             possessed = posesed;
        }

        internal IPossessable possessed;
        public enum keyHeld
        {
            left,
            none,
            right,
        }
#if IOS || ANDROID
        internal keyHeld CurrentKeyHeld = keyHeld.none;
#endif

        internal void tick ()
        {
#if ANDROID || IOS
            possessed.Tick(CurrentKeyHeld);
#elif WINDOWS
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Right))
            {
                possessed.Tick(keyHeld.right);
            }
            else if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Left))
            {
                possessed.Tick(keyHeld.left);
            }
            else possessed.Tick(keyHeld.none);
#endif

        }
    }    
}
