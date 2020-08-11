using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.GameFolder
{
    static class Sounds
    {
        public static Song menuMusic;
        public static SoundEffect gameOver;

        public static void Load(ContentManager content)
        {
            menuMusic = content.Load<Song>("MenuMusic");
            gameOver = content.Load<SoundEffect>("GameOverMusic");
        }
        public static void PlayMenuMusic(float volume)
        {
            MediaPlayer.Volume = volume;
            MediaPlayer.Play(menuMusic);
            MediaPlayer.IsRepeating = true;
        }
        public static void PlayGameOver(float volume)
        {
            SoundEffect.MasterVolume = volume;
            gameOver.Play();
        }
        public static void PlayLevelMusic(float volume)
        {
            //TODO
        }
        public static void StopMusic()
        {
            MediaPlayer.Stop();
        }
    }
}
