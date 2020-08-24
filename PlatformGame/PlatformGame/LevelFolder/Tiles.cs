using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.LevelFolder
{
    public class Tiles
    {
        protected Texture2D _texture;
        private Rectangle _rectangle;
        public Rectangle Rectangle { get { return _rectangle; } protected set { _rectangle = value; } }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, Color.White);
        }
    }
}
