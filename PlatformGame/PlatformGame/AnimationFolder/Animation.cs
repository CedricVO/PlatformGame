using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.AnimationFolder
{
    class Animation
    {
        private List<AnimationFrame> _frames;
        private double _xOffset;
        private int _counter = 0, _speed;

        public AnimationFrame CurrentFrame { get; set; }

        public Animation(int speed)
        {
            _frames = new List<AnimationFrame>();
            _xOffset = 0;
            _speed = speed;
        }
        public void AddFrame(Rectangle rectangle)
        {
            AnimationFrame frame = new AnimationFrame()
            {
                SourceRectangle = rectangle
            };
            _frames.Add(frame);
            CurrentFrame = _frames[0];
        }
        public void Update(GameTime gameTime)
        {
            _xOffset += CurrentFrame.SourceRectangle.Width * gameTime.ElapsedGameTime.Milliseconds / _speed;
            if (_xOffset >= CurrentFrame.SourceRectangle.Width)
            {
                _counter++;
                if (_counter >= _frames.Count)
                {
                    _counter = 0;
                }
                CurrentFrame = _frames[_counter];
                _xOffset = 0;
            }
        }
    }
}
