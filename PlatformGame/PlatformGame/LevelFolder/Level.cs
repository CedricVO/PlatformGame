using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlatformGame.SpriteFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.LevelFolder
{
    class Level
    {
        private List<CollitionTiles> _collitionTiles = new List<CollitionTiles>();
        private int _width, _height;

        public List<CollitionTiles> CollitionTiles
        {
            get { return _collitionTiles; }
        }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }

        public void Generate(int[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];
                    if (number >= 1 && number <= 12)
                    {
                        _collitionTiles.Add(new CollitionTiles(number, new Rectangle(x * size, y * size, size, size)));
                    }

                    _width = (x + 1) * size;
                    _height = (y + 1) * size;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollitionTiles item in _collitionTiles)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
