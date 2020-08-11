using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.GameFolder
{
    class Resources
    {
        public static Dictionary<string, Texture2D> LoadFile;
        public static SpriteFont font;

        public static void LoadImages(ContentManager content)
        {
            LoadFile = new Dictionary<string, Texture2D>();

            List<string> graphics = new List<string>()
            {
                "background",
                "didgeridoo"
            };

            foreach (string item in graphics)
            {
                LoadFile.Add(item, content.Load<Texture2D>(item));
            }
        }

        public static void LoadFont(ContentManager content)
        {
            font = content.Load<SpriteFont>("File");
        }
    }
}
