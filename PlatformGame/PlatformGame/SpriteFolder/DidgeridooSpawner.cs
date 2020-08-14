using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PlatformGame.SpriteFolder
{
    class DidgeridooSpawner
    {
        private float _spawn = 0;

        public List<Didgeridoo> didgeridoos = new List<Didgeridoo>();
        Random random = new Random();

        public void SpawnDidgeridoos(int level)
        {
            if (_spawn >= 1)
            {
                _spawn = 0;
                if (didgeridoos.Count < (level * 5))
                {
                    int velocity = random.Next(level, level * 5);
                    int positionY = random.Next(100, 1000);
                    didgeridoos.Add(new Didgeridoo(positionY, new Vector2(velocity, 0)));
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in didgeridoos)
            {
                item.Draw(spriteBatch);
            }
        }
        public void Load()
        {
            foreach (var item in didgeridoos)
            {
                item.Load();
            }
        }
        public void Update(GameTime gameTime)
        {
            _spawn += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (didgeridoos.Count > 0)
            {
                foreach (var item in didgeridoos)
                {
                    item.Update(gameTime);
                }
                for (int i = 0; i < didgeridoos.Count; i++)
                {
                    if (didgeridoos.ElementAt(i).Position.X < 0)
                    {
                        didgeridoos.RemoveAt(i);
                    }
                }
            }
        }
    }
}
