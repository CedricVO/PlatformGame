using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.GameFolder
{
    public class Camera
    {
        private Matrix _transform;
        public Vector2 _center;
        private Viewport _viewPort;

        public Matrix Transform
        {
            get { return _transform; }
        }
        public Camera(Viewport newViewPort)
        {
            _viewPort = newViewPort;
        }

        public void Update(Vector2 position, int xOffset, int yOffset)
        {
            if (position.X < _viewPort.Width / 2)
            {
                _center.X = _viewPort.Width / 2;
            }
            else if (position.X > xOffset - (_viewPort.Width / 2))
            {
                _center.X = xOffset - (_viewPort.Width / 2);
            }
            else _center.X = position.X;

            if (position.Y < _viewPort.Height / 2)
            {
                _center.Y = _viewPort.Height / 2;
            }
            else if (position.Y > yOffset - (_viewPort.Height / 2))
            {
                _center.Y = yOffset - (_viewPort.Height / 2);
            }
            else _center.Y = position.Y;

            _transform = Matrix.CreateTranslation(new Vector3(-_center.X + (_viewPort.Width / 2), -_center.Y + (_viewPort.Height / 2), 0));
        }
    }
}
