using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PlatformGame.GameFolder;
using PlatformGame.LevelFolder;
using PlatformGame.SpriteFolder;

namespace PlatformGame.MenuFolder
{
    class PlayState : Menu
    {
        int CurrentLevel = 1;
        Player player;
        Didgeridoo didgeridoo;

        Map map;

        Camera camera;
        Remote remote;
        GraphicsDevice graphicsDevice;

        public static int levelWidth;
        public static int levelHeigth;
        public PlayState(GraphicsDevice _graphicsDevice) : base(_graphicsDevice)
        {
            this.graphicsDevice = _graphicsDevice;
        }

        public override void Initialize()
        {
            Sounds.StopMusic();
            map = new Map();
            remote = new KeyboardClass();
            player = new Player(remote);
            this.camera = new Camera(graphicsDevice.Viewport);
            Sounds.PlayLevelMusic(.5f);
        }

        public override void LoadContent()
        {
            //TODO
            player.Load();

            background = Resources.LoadFile["background"];
            //TODO
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            player.Update(gameTime);
            
            //TODO
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Vector2(-60, 0), new Rectangle(0, 0, 1431, 750), Color.White, 0f, new Vector2(0, 0), .65f, SpriteEffects.None, 1f);
            spriteBatch.End();

            spriteBatch.Begin(); //SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform
            //TODO
            player.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
