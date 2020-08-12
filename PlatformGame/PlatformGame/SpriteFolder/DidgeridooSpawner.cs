using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.SpriteFolder
{
    class DidgeridooSpawner
    {
        private float spawn = 0;

        List<Didgeridoo> didgeridoos = new List<Didgeridoo>();
        Random random = new Random();

        public void SpawnDidgeridoos(int level)
        {
            if (spawn >= 1)
            {
                spawn = 0;
                if (didgeridoos.Count() <= 5)
                {
                    int velocity = random.Next(1, level * 10);
                    int positionY = random.Next(100, 1000);
                    didgeridoos.Add(new Didgeridoo(positionY, velocity));
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
            spawn += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (didgeridoos.Count > 0)
            {
                //foreach (var item in didgeridoos)
                //{
                //    item.Update(gameTime);
                //}
                for (int i = didgeridoos.Count - 1; i < 0; i--)
                {
                    didgeridoos.ElementAt(i).Update(gameTime);
                    if (didgeridoos.ElementAt(i).position.X < 0)
                        didgeridoos.RemoveAt(i);
                }
            }
        }
    }
}
