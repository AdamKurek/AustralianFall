using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Windows.ApplicationModel.Chat;
using Windows.Media.Core;
using Timer = System.Timers.Timer;

namespace AustralianFall.Classes.Services
{
    internal class GameLoop
    {
        Timer timer;
        internal int frames {private set; get; } = 0;

        public GameLoop()
        {
            timer = new Timer(1000 / 60); // Update game 60 times per second
            timer.Elapsed += OnTimerElapsed;
        }
        public void Start()
        {
            timer.Start();
            frames = 0;
        }

        public void Stop()
        {
            timer.Stop();
        }

        public event ElapsedEventHandler TimerElapsed
        {
            add { timer.Elapsed += value; }
            remove { timer.Elapsed -= value; }
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            frames++;
        }
    }
}
