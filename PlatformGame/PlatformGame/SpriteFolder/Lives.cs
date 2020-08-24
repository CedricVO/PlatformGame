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
    public class Lives
    {
        private Texture2D _texture;
        private int _lives = 3;

        public Vector2 position = new Vector2(0, 0);
        public Rectangle rectangle;
        public Lives()
        {
            Load();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < _lives; i++)
            {
                spriteBatch.Draw(_texture, position, new Rectangle(0, 0, 254, 254), Color.White, 0f, new Vector2(0, 0), .1f, SpriteEffects.None, 0f);
                position.X += 30;
            }
        }

        public void Load()
        {
            _texture = Resources.LoadFile["Heart"];
            rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, _texture.Width, _texture.Height);
        }

        public void Update(GameTime gameTime, float playerXPos, float playerYPos)
        {
            position.X = playerXPos;
            position.Y = playerYPos - 50;
        }

        public void Damage()
        {
            _lives--;
        }

        public bool DiedOfDamage()
        {
            if (_lives <= 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
