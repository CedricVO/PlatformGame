using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.GameFolder;

namespace PlatformGame.MenuFolder
{
    class GameOver : Menu
    {
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

        }

        public override void Update(GameTime gameTime, Game1 game)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
