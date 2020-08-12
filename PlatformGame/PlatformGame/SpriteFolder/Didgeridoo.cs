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
        public Vector2 position = new Vector2(1100, 600);
        private bool isVisible = true;
        private Texture2D texture;
        private int velocity;
        public Rectangle rectangle;
        private float angle;

        public Didgeridoo(int _positionY, int _velocity)
        {
            Load();
            position.Y = _positionY;
            velocity = _velocity;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, new Rectangle(0, 0, 545, 60), Color.White, angle, new Vector2(545 / 2, 60 / 2), .2f, SpriteEffects.None, 0f);
        }

        public override void Load()
        {
            texture = Resources.LoadFile["didgeridoo"];
            rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, texture.Width, texture.Height);
        }

        public override void Update(GameTime gameTime)
        {
            //movement + turning
            angle += .1f;
            position.X -= velocity;

            if (this.position.X < 0)
                this.isVisible = false;
        }
    }
}
