using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.LevelFolder
{
    class Level
    {
        private List<CollitionTiles> collitionTiles = new List<CollitionTiles>();
        public List<CollitionTiles> CollitionTiles
        {
            get { return collitionTiles; }
        }

        private int width, height;
        public int Width { get { return width; } }
        public int Height { get { return height; } }

        public void Generate(int[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];
                    if (number >= 1 && number <= 12)
                    {
                        collitionTiles.Add(new CollitionTiles(number, new Rectangle(x * size, y * size, size, size)));
                    }

                    width = (x + 1) * size;
                    height = (y + 1) * size;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollitionTiles item in collitionTiles)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
