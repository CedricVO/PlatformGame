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
    public class Player : Sprite
    {
        private Texture2D _texture;
        private Vector2 _position = new Vector2(50, 750);
        private SpriteEffects _spriteEffect;
        private bool _hasJumped = false;
        private bool _getsDamage = false;
        private bool _immune = false;
        private bool _deathAnimationPlaying = false;
        private Color _playerColor = Color.White;
        private bool _colorSwitch = true;
        private float _waitSec = 0;

        private Vector2 _velocity;

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }
        public Rectangle Rectangle;
        public bool isDead = false;


        Remote Remote;
        Lives Lives;
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Player(Remote remote, Lives lives)
        {
            Lives = lives;
            Remote = remote;
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
            if (Remote.Right)
            {
                _velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;

                PlayerAnimation.currentAnimation = PlayerAnimation.runAnimation;
                _spriteEffect = SpriteEffects.None;
            }
            else if (Remote.Left)
            {
                _velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;

                PlayerAnimation.currentAnimation = PlayerAnimation.runAnimation;
                _spriteEffect = SpriteEffects.FlipHorizontally;
            }
            else _velocity.X = 0f;

            if (Remote.Jump && _hasJumped == false)
            {
                PlayerAnimation.currentAnimation = PlayerAnimation.jumpAnimation;
                _position.Y -= 5f;
                _velocity.Y = -10f;
                _hasJumped = true;
            }

            if (Remote.Idle && _deathAnimationPlaying == false)
            {
                PlayerAnimation.currentAnimation = PlayerAnimation.idleAnimation;
            }

            if (_deathAnimationPlaying)
            {
                PlayerAnimation.currentAnimation = PlayerAnimation.deathAnimation;
                if (_waitSec >= 1.5)
                {
                    isDead = true;
                    _waitSec = 0;
                }
            }
        }
        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (Rectangle.TouchTopOf(newRectangle))
            {
                Rectangle.Y = newRectangle.Y - Rectangle.Height;
                _velocity.Y = 0f;
                _hasJumped = false;
            }
            if (Rectangle.TouchLeftOf(newRectangle))
            {
                _position.X = newRectangle.X - Rectangle.Width - 2;
            }
            if (Rectangle.TouchRightOf(newRectangle))
            {
                _position.X = newRectangle.X + newRectangle.Width + 2;
            }
            if (Rectangle.TouchBottomOf(newRectangle))
            {
                _velocity.Y = 1f;
            }
            if (_position.X < 0)
            {
                _position.X = 0;
            }
            if (_position.Y < 0)
            {
                _velocity.Y = 1f;
            }
            if (_position.Y > yOffset - Rectangle.Height)
            {
                _position.Y = yOffset - Rectangle.Height;
            }
            if (_position.X > xOffset - Rectangle.Width)
            {
                _position.X = xOffset - Rectangle.Width;
            }
        }

        public bool DidgeridooCollision(IDidgeridoo didgeridoo)
        {
            if (IsTouchingBottom(didgeridoo) || IsTouchingLeft(didgeridoo) || IsTouchingRight(didgeridoo) || IsTouchingTop(didgeridoo))
            {
                _getsDamage = true;
                return true;
            } else
            {
                return false;
            }
        }

        public bool IsTouchingLeft(IDidgeridoo didgeridoo)
        {
            return this.Rectangle.Right + this.Velocity.X > didgeridoo.Rectangle.Left &&
                    this.Rectangle.Left < didgeridoo.Rectangle.Left &&
                    this.Rectangle.Bottom > didgeridoo.Rectangle.Top &&
                    this.Rectangle.Top < didgeridoo.Rectangle.Bottom;
        }
        public bool IsTouchingRight(IDidgeridoo didgeridoo)
        {
            return this.Rectangle.Left + this.Velocity.X < didgeridoo.Rectangle.Right &&
                    this.Rectangle.Right > didgeridoo.Rectangle.Right &&
                    this.Rectangle.Bottom > didgeridoo.Rectangle.Top &&
                    this.Rectangle.Top < didgeridoo.Rectangle.Bottom;
        }
        public bool IsTouchingTop(IDidgeridoo didgeridoo)
        {
            return this.Rectangle.Bottom + this.Velocity.Y > didgeridoo.Rectangle.Top &&
                    this.Rectangle.Top < didgeridoo.Rectangle.Top &&
                    this.Rectangle.Right > didgeridoo.Rectangle.Left &&
                    this.Rectangle.Left < didgeridoo.Rectangle.Right;
        }
        public bool IsTouchingBottom(IDidgeridoo didgeridoo)
        {
            return this.Rectangle.Top + this.Velocity.Y < didgeridoo.Rectangle.Bottom &&
                    this.Rectangle.Bottom > didgeridoo.Rectangle.Bottom &&
                    this.Rectangle.Right > didgeridoo.Rectangle.Left &&
                    this.Rectangle.Left < didgeridoo.Rectangle.Right;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, PlayerAnimation.currentAnimation.CurrentFrame.SourceRectangle, _playerColor, 0f, new Vector2(0, 0), 1f, _spriteEffect, 0f);
            Lives.Draw(spriteBatch);
        }

        public override void Load()
        {
            _texture = Resources.LoadFile["spritesheet-3"];
            Lives.Load();
        }

        public override void Update(GameTime gameTime)
        {
            _position += _velocity;
            Rectangle = new Rectangle((int)_position.X, (int)_position.Y, PlayerAnimation.currentAnimation.CurrentFrame.SourceRectangle.Width, PlayerAnimation.currentAnimation.CurrentFrame.SourceRectangle.Height);

            Input(gameTime);
            Remote.Update();
            Lives.Update(gameTime, this._position.X, this._position.Y);

            if (_getsDamage && !_immune)
            {
                _getsDamage = false;
                _immune = true;
                Sounds.PlayAuwchSound(.8f);
                Lives.Damage();
            }
            if (_immune)
            {
                _colorSwitch = !_colorSwitch;
                _waitSec += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_waitSec >= .3)
                {
                    _waitSec = 0;
                    _immune = false;
                }
            }

            if (_colorSwitch)
            {
                _playerColor = Color.White;
            }
            else { _playerColor = Color.Transparent; }

            if (_velocity.Y < 10)
            {
                _velocity.Y += 0.4f;
            }

            if (_position.Y >= 850 || Lives.DiedOfDamage())
            {
                _deathAnimationPlaying = true;
                _immune = false;
                _playerColor = Color.White;
                _waitSec += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            PlayerAnimation.currentAnimation.Update(gameTime);
        }
    }
}
