using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.GameFolder;

namespace PlatformGame.SpriteFolder
{
    class Lives
    {
        public Vector2 position = new Vector2(0,0);
        private Texture2D texture;
        public Rectangle rectangle;
        private int lives = 3;
        public Lives()
        {
            Load();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < lives; i++)
            {
                spriteBatch.Draw(texture, position, new Rectangle(0, 0, 254, 254), Color.White, 0f, new Vector2(0, 0), .1f, SpriteEffects.None, 0f);
                position.X += 30;
            }
        }

        public void Load()
        {
            texture = Resources.LoadFile["Heart"];
            rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, texture.Width, texture.Height);
        }

        public void Update(GameTime gameTime, float playerXPos, float playerYPos)
        {
            position.X = playerXPos;
            position.Y = playerYPos - 50;
        }

        public void Damage()
        {
            lives--;
        }

        public bool DiedOfDamage()
        {
            if (lives <= 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
