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
    class Level : Menu
    {
        public Level(GraphicsDevice _graphicsDevice) : base(_graphicsDevice)
        {
        }

        public override void Initialize()
        {
            Sounds.stopMusic();
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
