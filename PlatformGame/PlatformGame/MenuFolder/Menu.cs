using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.MenuFolder
{
    public abstract class Menu
    {
        protected Texture2D _background;
        protected Menu(GraphicsDevice _graphicsDevice) { }

        public abstract void Initialize();

        public abstract void LoadContent();

        public abstract void Update(GameTime gameTime, Game1 game);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
