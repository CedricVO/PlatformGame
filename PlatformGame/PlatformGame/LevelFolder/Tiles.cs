using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.LevelFolder
{
    class Tiles
    {
        protected Texture2D texture;
        private Rectangle rectangle;
        public Rectangle Rectangle { get { return rectangle; } protected set { rectangle = value; } }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
