using Microsoft.Xna.Framework;
using PlatformGame.GameFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.LevelFolder
{
    class CollitionTiles : Tiles
    {
        public CollitionTiles(int i, Rectangle newRectangle)
        {
            _texture = Resources.LoadFile["Tile" + i];
            this.Rectangle = newRectangle;
        }
    }
}
