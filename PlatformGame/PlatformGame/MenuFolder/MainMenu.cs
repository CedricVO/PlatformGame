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
    class MainMenu : Menu
    {
        private float _rotation1 = 0f;
        private int positionX1 = 0;

        private float _rotation2 = 0f;
        private int _positionX2 = 1;
        private int _positionY2 = 1;
        private bool _substractX2 = true;
        private bool _substractY2 = true;

        public MainMenu(GraphicsDevice _graphicsDevice) : base(_graphicsDevice) { }

        public override void Initialize()
        {
            Sounds.StopMusic();
            Sounds.PlayMenuMusic(.5f);
        }

        public override void LoadContent()
        {
            _background = Resources.LoadFile["background"];
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                game.StateChange(Game1.GameState.PlayState);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                game.StateChange(Game1.GameState.Win);
            }

            _rotation1 += .15f;
            _rotation2 += .1f;

            if (positionX1 >= 870)
            {
                positionX1 = -70;
            }  else positionX1 += 3;

            if (_positionX2 >= 800 || _positionX2 <= 0)
                _substractX2 = !_substractX2;

            if (_positionY2 >= 500 || _positionY2 <= 0)
                _substractY2 = !_substractY2;

            if (_substractX2)
                _positionX2 += 4;
            else _positionX2 -= 4;

            if (_substractY2)
                _positionY2 += 2;
            else _positionY2 -= 2;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(_background, new Vector2(-60, 0), new Rectangle(0, 0, 1431, 750), Color.White, 0f, new Vector2(0,0), .65f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(Resources.font, "Dodge The Didgeridoo", new Vector2(50, 50), Color.Black, 0, new Vector2(0, 0), 1.3f, SpriteEffects.None, 1.0f);
            spriteBatch.DrawString(Resources.font, "Press Enter to start", new Vector2(190, 360), Color.Black, 0, new Vector2(0, 0), .8f, SpriteEffects.None, 1.0f);
            spriteBatch.DrawString(Resources.font, "Esc to Quit", new Vector2(5, 460), Color.Red, 0, new Vector2(0, 0), .4f, SpriteEffects.None, 1.0f);
            spriteBatch.Draw(Resources.LoadFile["didgeridoo"], new Vector2(positionX1, 250), new Rectangle(0, 0, 545, 60), Color.White, _rotation1, new Vector2(545 / 2, 60 / 2), .4f, SpriteEffects.None, 0f);
            spriteBatch.Draw(Resources.LoadFile["didgeridoo"], new Vector2(_positionX2, _positionY2), new Rectangle(0, 0, 545, 60), Color.White, _rotation2, new Vector2(545 / 2, 60 / 2), .4f, SpriteEffects.None, 0f);

            spriteBatch.End();
        }
    }
}
