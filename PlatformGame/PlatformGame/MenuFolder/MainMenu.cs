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
        public MainMenu(GraphicsDevice _graphicsDevice) : base(_graphicsDevice) { }

        public override void Initialize()
        {

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
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Vector2(-60, 0), new Rectangle(0, 0, 1431, 750), Color.White, 0f, new Vector2(0,0), .65f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(Resources.font, "Dodge The Didgeridoo", new Vector2(50, 50), Color.DeepPink, 0, new Vector2(0, 0), 1.3f, SpriteEffects.None, 1.0f);
            spriteBatch.DrawString(Resources.font, "Press Enter to start", new Vector2(190, 180), Color.Black, 0, new Vector2(0, 0), .8f, SpriteEffects.None, 1.0f);
            spriteBatch.DrawString(Resources.font, "Esc to Quit", new Vector2(20, 450), Color.Red, 0, new Vector2(0, 0), .4f, SpriteEffects.None, 1.0f);
            spriteBatch.Draw(Resources.LoadFile["didgeridoo"], new Vector2(400, 250), new Rectangle(0, 0, 545, 60), Color.White, 0, new Vector2(0, 0), .6f, SpriteEffects.None, 0f);
            //base.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
