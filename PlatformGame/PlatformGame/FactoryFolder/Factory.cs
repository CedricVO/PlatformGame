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
        public static Didgeridoo CreateDidgeridoo(int level)
        {
            int velocity = random.Next(level, level * 5);
            int positionY = random.Next(100, 1000);
            Didgeridoo didgeridoo = new Didgeridoo(positionY, new Vector2(velocity, 0));

            return didgeridoo;
        }

        public static Player CreatePlayer()
        {
            Player player = new Player(CreateKeyboard(), CreateLives());

            return player;
        }
        public static Door CreateDoor()
        {
            Door door = new Door();

            return door;
        }
        public static Lives CreateLives()
        {
            Lives lives = new Lives();

            return lives;
        }
        public static Remote CreateKeyboard()
        {
            Remote keyboard = new KeyboardClass();

            return keyboard;
        }
        public static DidgeridooSpawner CreateDidgeridooSpawner()
        {
            DidgeridooSpawner didgeridooSpawner = new DidgeridooSpawner();

            return didgeridooSpawner;
        }
        public static Map CreateMap()
        {
            Map map = new Map();
            return map;
        }
        public static Menu CreateMainMenu(GraphicsDevice graphicsDevice)
        {
            Menu mainMenu = new MainMenu(graphicsDevice);

            return mainMenu;
        }
        public static Menu CreatePlayState(GraphicsDevice graphicsDevice)
        {
            Menu playState = new PlayState(graphicsDevice);

            return playState;
        }
        public static Menu CreateGameOver(GraphicsDevice graphicsDevice)
        {
            Menu gameOver = new GameOver(graphicsDevice);

            return gameOver;
        }
        public static Menu CreateWin(GraphicsDevice graphicsDevice)
        {
            Menu win = new Win(graphicsDevice);

            return win;
        }
        public static Camera CreateCamera(Viewport viewport)
        {
            Camera camera = new Camera(viewport);

            return camera;
        }
    }
}
