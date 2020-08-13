using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.AnimationFolder;
using PlatformGame.CollisionFolder;
using PlatformGame.GameFolder;
using System.Diagnostics;

namespace PlatformGame.SpriteFolder
{
    class Player : Sprite
    {
        private Texture2D texture;
        private Vector2 _position = new Vector2(50, 750);
        public Vector2 velocity;
        public Rectangle rectangle;
        private SpriteEffects spriteEffect;
        private bool hasJumped = false;
        public bool isDead = false;
        private bool getsDamage = false;
        private bool immune = false;
        private bool deathAnimationPlaying = false;
        private Color playerColor = Color.White;
        private bool colorSwitch = true;
        private float waitSec = 0;
        Remote remote;

        Lives lives;
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Player(Remote _remote)
        {
            lives = new Lives();
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
                PlayerAnimation.currentAnimation = PlayerAnimation.jumpAnimation;
                _position.Y -= 5f;
                velocity.Y = -10f;
                hasJumped = true;
            }

            if (remote.Idle && deathAnimationPlaying == false)
            {
                PlayerAnimation.currentAnimation = PlayerAnimation.idleAnimation;
            }

            if (deathAnimationPlaying)
            {
                PlayerAnimation.currentAnimation = PlayerAnimation.deathAnimation; //Speelt niet af
                if (waitSec >= 1.5)
                {
                    isDead = true;
                    waitSec = 0;
                }
            }
        }
        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (rectangle.TouchTopOf(newRectangle))
            {
                rectangle.Y = newRectangle.Y - rectangle.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }
            if (rectangle.TouchLeftOf(newRectangle))
            {
                _position.X = newRectangle.X - rectangle.Width - 2;
            }
            if (rectangle.TouchRightOf(newRectangle))
            {
                _position.X = newRectangle.X + newRectangle.Width + 2;
            }
            if (rectangle.TouchBottomOf(newRectangle))
            {
                velocity.Y = 1f;
            }
            if (_position.X < 0)
            {
                _position.X = 0;
            }
            if (_position.Y < 0)
            {
                velocity.Y = 1f;
            }
            if (_position.Y > yOffset - rectangle.Height)
            {
                _position.Y = yOffset - rectangle.Height;
            }
            if (_position.X > xOffset - rectangle.Width)
            {
                _position.X = xOffset - rectangle.Width;
            }
        }

        #region Didgeridoo Collision 2
        //private bool IsTouchingLeft(Didgeridoo didgeridoo)
        //{
        //    return this.rectangle.Right > didgeridoo.rectangle.Left &&
        //        this.rectangle.Left < didgeridoo.rectangle.Left &&
        //        this.rectangle.Bottom > didgeridoo.rectangle.Top &&
        //        this.rectangle.Top < didgeridoo.rectangle.Bottom;
        //}
        //private bool IsTouchingRight(Didgeridoo didgeridoo)
        //{
        //    return this.rectangle.Left < didgeridoo.rectangle.Right &&
        //        this.rectangle.Right > didgeridoo.rectangle.Right &&
        //        this.rectangle.Bottom > didgeridoo.rectangle.Top &&
        //        this.rectangle.Top < didgeridoo.rectangle.Bottom;
        //}
        //private bool IsTouchingTop(Didgeridoo didgeridoo)
        //{
        //    return this.rectangle.Bottom + this.velocity.Y > didgeridoo.rectangle.Top &&
        //        this.rectangle.Top < didgeridoo.rectangle.Top &&
        //        this.rectangle.Right > didgeridoo.rectangle.Left &&
        //        this.rectangle.Left < didgeridoo.rectangle.Right;
        //}
        //private bool IsTouchingBottom(Didgeridoo didgeridoo)
        //{
        //    return this.rectangle.Top + this.velocity.Y < didgeridoo.rectangle.Bottom &&
        //        this.rectangle.Bottom > didgeridoo.rectangle.Bottom &&
        //        this.rectangle.Right > didgeridoo.rectangle.Left &&
        //        this.rectangle.Left < didgeridoo.rectangle.Right;
        //}

        //public bool DidgeridooCollision2(Didgeridoo didgeridoo)
        //{
        //    if ((this.velocity.X > 0 && this.IsTouchingLeft(didgeridoo)) ||
        //        (this.velocity.X < 0 && this.IsTouchingRight(didgeridoo)))
        //    {
        //        //Touch
        //        Debug.WriteLine("Touch Left or Right");
        //        return true;
        //    }
        //    if ((this.velocity.Y > 0 && this.IsTouchingTop(didgeridoo)) ||
        //        this.velocity.Y < 0 && this.IsTouchingBottom(didgeridoo))
        //    {
        //        //Touch
        //        Debug.WriteLine("Touch Top or Bottom");
        //        return true;
        //    }
        //    return false;
        //}
        #endregion

        #region Didgeridoo Collision Try 1
        //public void DidgeridooCollision(Rectangle newRectangle)
        //{
        //    if (rectangle.TouchTopOf(newRectangle) || rectangle.TouchBottomOf(newRectangle) || rectangle.TouchLeftOf(newRectangle) || rectangle.TouchRightOf(newRectangle))
        //    {
        //        this.getsDamage = true;
        //    }
        //}
        #endregion

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, _position, PlayerAnimation.currentAnimation.currentFrame.SourceRectangle, playerColor, 0f, new Vector2(0, 0), 1f, spriteEffect, 0f);
            lives.Draw(spriteBatch);
        }

        public override void Load()
        {
            texture = Resources.LoadFile["spritesheet-3"];
            lives.Load();
        }

        public override void Update(GameTime gameTime)
        {
            _position += velocity;
            rectangle = new Rectangle((int)_position.X, (int)_position.Y, PlayerAnimation.currentAnimation.currentFrame.SourceRectangle.Width, PlayerAnimation.currentAnimation.currentFrame.SourceRectangle.Height);

            Input(gameTime);
            remote.Update();
            lives.Update(gameTime, this._position.X, this._position.Y);

            if (this.getsDamage && !this.immune)
            {
                immune = true;
                getsDamage = false;
                Sounds.PlayAuwchSound(.8f);
                lives.Damage();
            }
            if (this.immune)
            {
                colorSwitch = !colorSwitch;
                waitSec += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (waitSec >= 1)
                {
                    waitSec = 0;
                    immune = false;
                }
            }

            if (colorSwitch)
            {
                playerColor = Color.White;
            } else { playerColor = Color.Transparent; }

            if (velocity.Y < 10)
            {
                velocity.Y += 0.4f;
            }

            if (_position.Y >= 850 || lives.DiedOfDamage())
            {
                deathAnimationPlaying = true;
                immune = false;
                playerColor = Color.White;
                waitSec += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            PlayerAnimation.currentAnimation.Update(gameTime);
        }
    }
}
