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
    class Door : Sprite
    {
        private Vector2 _position = new Vector2(1420,802); //1420,802
        private Texture2D _texture;

        public Rectangle Rectangle;
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }


        public Door()
        {
            Load();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }

        public override void Load()
        {
            _texture = Resources.LoadFile["door"];
            Rectangle = new Rectangle((int)this._position.X, (int)this._position.Y, _texture.Width, _texture.Height);
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle = new Rectangle((int)this._position.X, (int)this._position.Y, _texture.Width, _texture.Height);
        }
    }
}
