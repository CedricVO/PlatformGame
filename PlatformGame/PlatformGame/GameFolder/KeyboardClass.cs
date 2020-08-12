using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.GameFolder
{
    class KeyboardClass : Remote
    {
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyDown(Keys.Left))
            {
                Left = true;
                Idle = false;
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                Left = false;
                Idle = false;
            }

            if (stateKey.IsKeyDown(Keys.Right))
            {
                Right = true;
                Idle = false;
            }
            if (stateKey.IsKeyUp(Keys.Right))
            {
                Right = false;
                Idle = false;
            }
            if (stateKey.GetPressedKeys().Length == 0)
            {
                Idle = true;
            }
            if (stateKey.IsKeyDown(Keys.Up))
            {
                Jump = true;
            }
            if (stateKey.IsKeyUp(Keys.Up))
            {
                Jump = false;
            }

            //TESTING

            if (stateKey.IsKeyDown(Keys.Down))
            {
                Death = true;
            }
            if (stateKey.IsKeyUp(Keys.Down))
            {
                Death = false;
            }
        }
    }
}
