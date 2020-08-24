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
using System.Diagnostics;

namespace PlatformGame.MenuFolder
{
    class PlayState : Menu
    {
        private int _currentLevel = 1;
        private float _waitSec = 0;
        private bool _damageflag = true;

        Player player;
        DidgeridooSpawner didgeridooSpawner;
        Door door;
        Map map;
        Camera camera;
        Remote remote;
        GraphicsDevice graphicsDevice;
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
            didgeridooSpawner = new DidgeridooSpawner();
            door = new Door();
            camera = new Camera(graphicsDevice.Viewport);
            Sounds.PlayLevel1(1f);
            Sounds.PlayLevelMusic(.2f);
        }

        public override void LoadContent()
        {
            map.SetLevel(_currentLevel);
            map.GenerateLevel();
            player.Load();
            didgeridooSpawner.Load();
            door.Load();

            _background = Resources.LoadFile["background"];
        }

        public override void Update(GameTime gameTime, Game1 game)
        {
            player.Update(gameTime);
            didgeridooSpawner.SpawnDidgeridoos(_currentLevel);
            didgeridooSpawner.Update(gameTime);
            door.Update(gameTime);

            //Collision with the map
            foreach (CollitionTiles item in map.LevelCurrent.CollitionTiles)
            {
                player.Collision(item.Rectangle, map.LevelCurrent.Width, map.LevelCurrent.Height);
                camera.Update(player.Position, map.LevelCurrent.Width, map.LevelCurrent.Height);
            }

            //Collision with Didgeridoos
            if (_damageflag)
            {
                foreach (var item in didgeridooSpawner.didgeridoos)
                {
                    if (player.DidgeridooCollision(item.Rectangle))
                    {
                        RemoveOneDidgeridoo(item);
                        break;
                    }
                }
            }

            //Collision with Door
            if (player.Rectangle.Intersects(door.Rectangle) && _currentLevel == 2)
            {
                _damageflag = false;
                _waitSec += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_waitSec >= 2)
                {
                    _waitSec = 0;
                    game.StateChange(Game1.GameState.Win);
                }
            }

            if (player.Rectangle.Intersects(door.Rectangle) && _currentLevel == 1)
            {
                _damageflag = false;
                _waitSec += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_waitSec >= 2)
                {
                    _waitSec = 0;
                    RemoveAllDidgeridoos();
                    _damageflag = !_damageflag;
                    _currentLevel++;
                    Sounds.PlayLevel2(1f);
                    map.SetLevel(_currentLevel);
                    map.GenerateLevel();
                    door.Position = new Vector2(1167, 866); //1167, 866
                    player.Position = new Vector2(50, 800);
                }
            }

            if (player.isDead)
            {
                game.StateChange(Game1.GameState.GameOver);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_background, new Vector2(-60, 0), new Rectangle(0, 0, 1431, 750), Color.White, 0f, new Vector2(0, 0), .65f, SpriteEffects.None, 1f);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);

            //FOR DEBUGGING COLLISION
            //spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque, null, null, null, null, camera.Transform);
            //RasterizerState state = new RasterizerState();
            //state.FillMode = FillMode.WireFrame;
            //END DEBUGGING COLLISION

            map.DrawLevel(spriteBatch);
            player.Draw(spriteBatch);
            door.Draw(spriteBatch);
            didgeridooSpawner.Draw(spriteBatch);

            spriteBatch.End();
        }

        private void RemoveAllDidgeridoos()
        {
            int count = didgeridooSpawner.didgeridoos.Count;
            didgeridooSpawner.didgeridoos.RemoveRange(0, count);
        }

        private void RemoveOneDidgeridoo(Didgeridoo didgeridoo)
        {
            didgeridooSpawner.didgeridoos.Remove(didgeridoo);
        }
    }
}
