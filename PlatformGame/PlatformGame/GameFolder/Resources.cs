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
                "didgeridoo",
                "Dead (1)",
                "Dead (2)",
                "Dead (3)",
                "Dead (4)",
                "Dead (5)",
                "Dead (6)",
                "Dead (7)",
                "Dead (8)",
                "Dead (9)",
                "Dead (10)",
                "Idle (1)",
                "Idle (2)",
                "Idle (3)",
                "Idle (4)",
                "Idle (5)",
                "Idle (6)",
                "Idle (7)",
                "Idle (8)",
                "Idle (9)",
                "Idle (10)",
                "Jump (1)",
                "Jump (2)",
                "Jump (3)",
                "Jump (4)",
                "Jump (5)",
                "Jump (6)",
                "Jump (7)",
                "Jump (8)",
                "Jump (9)",
                "Jump (10)",
                "Run (1)",
                "Run (2)",
                "Run (3)",
                "Run (4)",
                "Run (5)",
                "Run (6)",
                "Run (7)",
                "Run (8)",
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
