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

        public Vector2 velocity;
        public Rectangle Rectangle;
        public bool isDead = false;

        Remote Remote;
        Lives lives;
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Player(Remote remote)
        {
            lives = new Lives();
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
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;

                PlayerAnimation.currentAnimation = PlayerAnimation.runAnimation;
                _spriteEffect = SpriteEffects.None;
            }
            else if (Remote.Left)
            {
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;

                PlayerAnimation.currentAnimation = PlayerAnimation.runAnimation;
                _spriteEffect = SpriteEffects.FlipHorizontally;
            }
            else velocity.X = 0f;

            if (Remote.Jump && _hasJumped == false)
            {
                PlayerAnimation.currentAnimation = PlayerAnimation.jumpAnimation;
                _position.Y -= 5f;
                velocity.Y = -10f;
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
                velocity.Y = 0f;
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
            if (_position.Y > yOffset - Rectangle.Height)
            {
                _position.Y = yOffset - Rectangle.Height;
            }
            if (_position.X > xOffset - Rectangle.Width)
            {
                _position.X = xOffset - Rectangle.Width;
            }
        }

        #region Didgeridoo Collision
        public bool DidgeridooCollision(Rectangle newRectangle)
        {
            if (Rectangle.Intersects(newRectangle))
            {
                _getsDamage = true;
                return true;
            }
            return false;
        }
        #endregion

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, PlayerAnimation.currentAnimation.CurrentFrame.SourceRectangle, _playerColor, 0f, new Vector2(0, 0), 1f, _spriteEffect, 0f);
            lives.Draw(spriteBatch);
        }

        public override void Load()
        {
            _texture = Resources.LoadFile["spritesheet-3"];
            lives.Load();
        }

        public override void Update(GameTime gameTime)
        {
            _position += velocity;
            Rectangle = new Rectangle((int)_position.X, (int)_position.Y, PlayerAnimation.currentAnimation.CurrentFrame.SourceRectangle.Width, PlayerAnimation.currentAnimation.CurrentFrame.SourceRectangle.Height);

            Input(gameTime);
            Remote.Update();
            lives.Update(gameTime, this._position.X, this._position.Y);

            if (_getsDamage && !_immune)
            {
                _getsDamage = false;
                _immune = true;
                Sounds.PlayAuwchSound(.8f);
                lives.Damage();
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

            if (velocity.Y < 10)
            {
                velocity.Y += 0.4f;
            }

            if (_position.Y >= 850 || lives.DiedOfDamage())
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
