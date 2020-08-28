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
    public class Didgeridoo : Sprite, IDidgeridoo
    {
        private Texture2D _texture;
        private float _angle;
        private float _rotation = .1f;

        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Rectangle Rectangle { get; set; }


        public Didgeridoo(int positionY, Vector2 velocity)
        {
            Load();

            Position = new Vector2(1700, positionY);

            Velocity = velocity;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Color.White, _angle, new Vector2(_texture.Width / 2, _texture.Height / 2), .2f, SpriteEffects.None, 0);
        }

        public override void Load()
        {
            _texture = Resources.LoadFile["didgeridoo"];
        }

        public override void Update(GameTime gameTime)
        {
            //update Rectangle every frame
            Rectangle = new Rectangle((int)this.Position.X, (int)this.Position.Y, _texture.Width/4, _texture.Height/4);
            //movement + turning
            _angle -= _rotation;
            Position -= Velocity;
        }
    }
}
