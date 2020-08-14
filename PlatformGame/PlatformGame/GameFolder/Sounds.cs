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
        private static Song menuMusic;
        private static Song gameOver;
        private static Song levelMusic;
        private static SoundEffect auwch;
        private static Song _winMusic;
        private static SoundEffect _level1;
        private static SoundEffect _level2;
        public static void Load(ContentManager content)
        {
            menuMusic = content.Load<Song>("MenuMusic");
            gameOver = content.Load<Song>("GameOverMusic");
            levelMusic = content.Load<Song>("LevelMusic");
            auwch = content.Load<SoundEffect>("auwch");
            _winMusic = content.Load<Song>("WinMusic");
            _level1 = content.Load<SoundEffect>("level1Sound");
            _level2 = content.Load<SoundEffect>("level2Sound");
        }

        public static void PlayLevel1(float volume)
        {
            _level1.Play(volume, 0, 0);
        }
        public static void PlayLevel2(float volume)
        {
            _level2.Play(volume, 0, 0);
        }
        public static void PlayWinMusic(float volume)
        {
            MediaPlayer.Volume = volume;
            MediaPlayer.Play(_winMusic);
            MediaPlayer.IsRepeating = false;
        }
        public static void PlayAuwchSound(float volume)
        {
            auwch.Play(volume, 0, 0);
        }
        public static void PlayMenuMusic(float volume)
        {
            MediaPlayer.Volume = volume;
            MediaPlayer.Play(menuMusic);
            MediaPlayer.IsRepeating = true;
        }
        public static void PlayGameOver(float volume)
        {
            MediaPlayer.Volume = volume;
            MediaPlayer.Play(gameOver);
        }
        public static void PlayLevelMusic(float volume)
        {
            MediaPlayer.Volume = volume;
            MediaPlayer.Play(levelMusic);
            MediaPlayer.IsRepeating = true;
        }
        public static void StopMusic()
        {
            MediaPlayer.Stop();
        }
    }
}
