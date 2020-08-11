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
        private float rotation1 = 0f;
        private int positionX1 = 0;

        private float rotation2 = 0f;
        private int positionX2 = 1;
        private int positionY2 = 1;
        private bool substractX2 = true;
        private bool substractY2 = true;

        public MainMenu(GraphicsDevice _graphicsDevice) : base(_graphicsDevice) { }

        public override void Initialize()
        {
            Sounds.playMenuMusic(.5f);
        }

        public override void LoadContent()
        {
            background = Resources.LoadFile["background"];
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                game.StateChange(Game1.GameState.Level);
            }

            rotation1 += .15f;
            rotation2 += .1f;

            if (positionX1 >= 870)
            {
                positionX1 = -70;
            }  else positionX1 += 3;

            if (positionX2 >= 800 || positionX2 <= 0)
                substractX2 = !substractX2;

            if (positionY2 >= 500 || positionY2 <= 0)
                substractY2 = !substractY2;

            if (substractX2)
                positionX2 += 2;
            else positionX2 -= 2;

            if (substractY2)
                positionY2 += 4;
            else positionY2 -= 4;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Vector2(-60, 0), new Rectangle(0, 0, 1431, 750), Color.White, 0f, new Vector2(0,0), .65f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(Resources.font, "Dodge The Didgeridoo", new Vector2(50, 50), Color.Black, 0, new Vector2(0, 0), 1.3f, SpriteEffects.None, 1.0f);
            spriteBatch.DrawString(Resources.font, "Press Enter to start", new Vector2(190, 360), Color.Black, 0, new Vector2(0, 0), .8f, SpriteEffects.None, 1.0f);
            spriteBatch.DrawString(Resources.font, "Esc to Quit", new Vector2(5, 460), Color.Red, 0, new Vector2(0, 0), .4f, SpriteEffects.None, 1.0f);
            spriteBatch.Draw(Resources.LoadFile["didgeridoo"], new Vector2(positionX1, 250), new Rectangle(0, 0, 545, 60), Color.White, rotation1, new Vector2(545 / 2, 60 / 2), .4f, SpriteEffects.None, 0f);
            spriteBatch.Draw(Resources.LoadFile["didgeridoo"], new Vector2(positionX2, positionY2), new Rectangle(0, 0, 545, 60), Color.White, rotation2, new Vector2(545 / 2, 60 / 2), .4f, SpriteEffects.None, 0f);
            //base.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
