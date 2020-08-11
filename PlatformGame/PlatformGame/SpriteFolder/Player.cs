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
    class Player : Sprite
    {
        private Texture2D texture;
        private Vector2 position = new Vector2(100, 100);
        private Vector2 velocity;
        public Rectangle rectangle;
        private SpriteEffects spriteEffect;
        private bool hasJumped = false;
        Remote remote;
        public Vector2 Position
        {
            get { return position; }
        }
        public Player(Remote _remote)
        {
            this.remote = _remote;
            //Run animation
            //PlayerAnimation.CreateRunAnimation();
            //Idle animation
            //PlayerAnimation.CreateAnimationIdle();
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
