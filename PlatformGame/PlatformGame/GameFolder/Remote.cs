using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.GameFolder
{
    public abstract class Remote
    {
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Idle { get; set; }
        public bool Jump { get; set; }
        public abstract void Update();
    }
}
