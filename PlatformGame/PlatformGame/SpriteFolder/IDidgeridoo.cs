using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlatformGame.SpriteFolder
{
    public interface IDidgeridoo
    {
        Vector2 Position { get; set; }
        Rectangle Rectangle { get; set; }
        Vector2 Velocity { get; set; }

        void Draw(SpriteBatch spriteBatch);
        void Load();
        void Update(GameTime gameTime);
    }
}