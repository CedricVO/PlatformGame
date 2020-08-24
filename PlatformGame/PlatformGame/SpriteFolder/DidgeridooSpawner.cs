using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using PlatformGame.FactoryFolder;

namespace PlatformGame.SpriteFolder
{
    public class DidgeridooSpawner
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
                    didgeridoos.Add(Factory.CreateDidgeridoo(level));
                }
            }
        }
        public void RemoveAllDidgeridoos()
        {
            int count = didgeridoos.Count;
            didgeridoos.RemoveRange(0, count);
        }
        public void RemoveOneDidgeridoo(Didgeridoo didgeridoo)
        {
            didgeridoos.Remove(didgeridoo);
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
