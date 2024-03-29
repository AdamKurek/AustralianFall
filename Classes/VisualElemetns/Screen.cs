﻿using AustralianFall.Classes.VisualElemetns.MovingElements;
using AustralianFall.Interfaces;
using SkiaSharp;
using System.Timers;
using AustralianFall.Classes.VisualElemetns.StaticVisuals.Backgrounds;
using Microsoft.Maui.Animations;

namespace AustralianFall.Classes.VisualElemetns
{
    internal class Screen
    {
        internal int tick = 0;
        private List<ITrap> _traps;
        internal List<ITrap> Traps {get => _traps;
            set
            {
                Movables = new();
                foreach(var t in value)
                {
                    var tt = t as ITickable;
                    if(tt == null) { continue; }
                    Movables.Add(tt);
                }
                _traps = value;
            }
        }
        internal List<ITickable> Movables;
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
            foreach(ITrap t in Traps)
            {
                t.Resize();
            }
        }
        internal Screen(int level)
        {
            if(level!=0)
            level = 5;
            /////////
            Type type = Type.GetType($"AustralianFall.Classes.VisualElemetns.StaticVisuals.Backgrounds.Map{level}");
            if (type == null){
                type = Type.GetType("AustralianFall.Classes.VisualElemetns.StaticVisuals.Backgrounds.MapDefault");
            }
            levelAssets = (ILevelAssets)Activator.CreateInstance(type);
            {
                staticBitmap = levelAssets.LoadBackground();
                levelAssets.loadTextures();
                Traps = levelAssets.LoadMovingElements();
                foreach(ITrap trap in Traps) {
                    trap.Resize();
                    if (levelAssets.bitmaps.ContainsKey(trap.GetType().Name)){
                        var animatedtrap = trap as IAnimatedObject;
                        if (animatedtrap == null){
                            //  animatedtrap.animationFrames = ((List<SKBitmap>)levelAssets.bitmaps[trap.GetType().Name]).ToArray();
                            trap.SetBitmap(levelAssets.bitmaps[trap.GetType().Name][0]);
                            continue;
                        }
                        if (levelAssets.bitmaps != null){
                            animatedtrap.animationFrames = ((List<SKBitmap>)levelAssets.bitmaps[trap.GetType().Name]).ToArray();
                        }
                    }
                }
                BindTraps();
                resize();
            }
        }
        internal void OnGameTick(object sender, ElapsedEventArgs e)
        {
            foreach (var movableElement in Movables)
            {
                movableElement.Tick();
            }
            tick++;
        }

        internal void DrawTraps(SKCanvas canvas)
        {
            foreach (var t in Traps)
            {
                t.Draw(canvas);
            }
        }

        private void BindTraps()
        {
            foreach(var t in Traps)
            {
                t.screen = this;
            }
        }

        internal void checkColisions(){
            var xd =australian.getHitboxRect().Location.Y;
            if (australian.getHitboxRect().Location.Y>700) { return; }
            
            foreach(var t in Traps){
                if (t.DoesIntersectWithRect(australian.getHitboxRect())) {
                    IDisplayable.Hitbox[] lsss = new IDisplayable.Hitbox[1];
                    lsss[0] = australian.hitbox;
                    if (IDisplayable.Hitbox.calculateCommonArea(t.hitbox, lsss) >10) { 
                        australian.Alive = false;
                    }
                }
            }
        }
    }
}
