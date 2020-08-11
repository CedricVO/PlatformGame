using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.AnimationFolder;
using PlatformGame.GameFolder;

namespace PlatformGame.SpriteFolder
{
    class Player : Sprite
    {
        private Texture2D texture;
        private Vector2 position = new Vector2(300, 300);
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
            PlayerAnimation.CreateAnimationRun();
            //Idle animation
            PlayerAnimation.CreateAnimationIdle();
            //Death animation
            PlayerAnimation.CreateAnimationDeath();
            //Jump animation
            PlayerAnimation.CreateAnimationJump();
        }
        private void Input(GameTime gameTime)
        {
            if (remote.Right)
            {
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;

                PlayerAnimation.currentAnimation = PlayerAnimation.runAnimation;
                spriteEffect = SpriteEffects.None;
            }
            else if (remote.Left)
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;

                PlayerAnimation.currentAnimation = PlayerAnimation.runAnimation;
                spriteEffect = SpriteEffects.FlipHorizontally;
            }
            else velocity.X = 0f;

            if (remote.Jump && hasJumped == false)
            {
                position.Y -= 5f;
                velocity.Y = -9f;
                hasJumped = true;
            }

            if (remote.Idle)
            {
                PlayerAnimation.currentAnimation = PlayerAnimation.idleAnimation;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, PlayerAnimation.currentAnimation.currentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), .5f, spriteEffect, 0f);
        }

        public override void Load()
        {
            texture = Resources.LoadFile["spritesheet-2"];
        }

        public override void Update(GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, PlayerAnimation.currentAnimation.currentFrame.SourceRectangle.Width, PlayerAnimation.currentAnimation.currentFrame.SourceRectangle.Height);

            Input(gameTime);
            remote.Update();

            if (velocity.Y < 10)
            {
                velocity.Y += 0.4f;
            }

            PlayerAnimation.currentAnimation.Update(gameTime);
        }
    }
}
