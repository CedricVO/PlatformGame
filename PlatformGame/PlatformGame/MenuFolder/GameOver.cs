using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformGame.GameFolder;

namespace PlatformGame.MenuFolder
{
    class GameOver : Menu
    {
        private float _waitSec = 0;
        private bool _flag = false;
        public GameOver(GraphicsDevice _graphicsDevice) : base(_graphicsDevice)
        {
        }

        public override void Initialize()
        {
            Sounds.StopMusic();
            Sounds.PlayGameOver(.5f);
        }

        public override void LoadContent()
        {
            _background = Resources.LoadFile["gameover"];
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                _flag = true;
            }
            if (_flag)
            {
                _waitSec += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (_waitSec >= 0.2)
            {
                _waitSec = 0;
                game.StateChange(Game1.GameState.PlayState);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(_background, new Vector2(-30, 0), new Rectangle(0, 0, 852, 480), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(Resources.Font, "Press Enter to play again", new Vector2(200, 330), Color.White, 0, new Vector2(0, 0), .6f, SpriteEffects.None, 1.0f);
            spriteBatch.DrawString(Resources.Font, "Press Esc to Quit", new Vector2(280, 430), Color.White, 0, new Vector2(0, 0), .5f, SpriteEffects.None, 1.0f);

            spriteBatch.End();
        }
    }
}
