using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.GameFolder;
using PlatformGame.LevelFolder;
using PlatformGame.MenuFolder;
using PlatformGame.SpriteFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.FactoryFolder
{
    public static class Factory
    {
        static Random random = new Random();
        public static IDidgeridoo CreateDidgeridoo(int level)
        {
            int velocity = random.Next(level, level * 5);
            int positionY = random.Next(100, 1000);
            return new Didgeridoo(positionY, new Vector2(velocity, 0));
        }

        public static Player CreatePlayer()
        {
            return new Player(CreateKeyboard(), CreateLives());
        }
        public static Door CreateDoor()
        {
            return new Door();
        }
        public static Lives CreateLives()
        {
            return new Lives();
        }
        public static Remote CreateKeyboard()
        {
            return new KeyboardClass();
        }
        public static DidgeridooSpawner CreateDidgeridooSpawner()
        {
            return new DidgeridooSpawner();
        }
        public static Map CreateMap()
        {
            return new Map();
        }
        public static Menu CreateMainMenu(GraphicsDevice graphicsDevice)
        {
            return new MainMenu(graphicsDevice);
        }
        public static Menu CreatePlayState(GraphicsDevice graphicsDevice)
        {
            return new PlayState(graphicsDevice);
        }
        public static Menu CreateGameOver(GraphicsDevice graphicsDevice)
        {
            return new GameOver(graphicsDevice);
        }
        public static Menu CreateWin(GraphicsDevice graphicsDevice)
        {
            return new Win(graphicsDevice);
        }
        public static Camera CreateCamera(Viewport viewport)
        {
            return new Camera(viewport);
        }
    }
}
