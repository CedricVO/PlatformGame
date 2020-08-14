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
    class Didgeridoo : Sprite
    {
        public Vector2 position = new Vector2(1650, 0);
        private Texture2D texture;
        public Vector2 velocity;
        private float angle;
        private float rotation = .1f;
        public Rectangle rectangle;

        public Didgeridoo(int _positionY, Vector2 _velocity)
        {
            Load();

            position.Y = _positionY;

            velocity = _velocity;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, angle, new Vector2(texture.Width / 2, texture.Height / 2), .2f, SpriteEffects.None, 0);
        }

        public override void Load()
        {
            texture = Resources.LoadFile["didgeridoo"];
        }

        public override void Update(GameTime gameTime)
        {
            //update rectangle every frame
            rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, texture.Width, texture.Height);
            //movement + turning
            angle -= rotation;
            position -= velocity;
        }
    }
}
