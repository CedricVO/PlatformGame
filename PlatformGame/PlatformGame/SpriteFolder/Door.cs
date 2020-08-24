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
    public class Door : Sprite
    {
        private Texture2D _texture;

        public Rectangle Rectangle;
        public Vector2 Position { get; set; } = new Vector2(1420, 802);


        public Door()
        {
            Load();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        public override void Load()
        {
            _texture = Resources.LoadFile["door"];
            Rectangle = new Rectangle((int)this.Position.X, (int)this.Position.Y, _texture.Width, _texture.Height);
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle = new Rectangle((int)this.Position.X, (int)this.Position.Y, _texture.Width, _texture.Height);
        }
    }
}
