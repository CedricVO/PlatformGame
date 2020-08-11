using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.GameFolder
{
    class Sounds
    {
        public static Song menuMusic;

        public static void Load(ContentManager content)
        {
            menuMusic = content.Load<Song>("MenuMusic");
        }
        public static void playMenuMusic(float volume)
        {
            MediaPlayer.Volume = volume;
            MediaPlayer.Play(menuMusic);
            MediaPlayer.IsRepeating = true;
        }
        public static void stopMusic()
        {
            MediaPlayer.Stop();
        }
    }
}
