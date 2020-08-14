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
        private static Song _menuMusic;
        private static Song _gameOver;
        private static Song _levelMusic;
        private static SoundEffect _auwch;
        private static Song _winMusic;
        private static SoundEffect _level1;
        private static SoundEffect _level2;
        public static void Load(ContentManager content)
        {
            _menuMusic = content.Load<Song>("MenuMusic");
            _gameOver = content.Load<Song>("GameOverMusic");
            _levelMusic = content.Load<Song>("LevelMusic");
            _auwch = content.Load<SoundEffect>("auwch");
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
            _auwch.Play(volume, 0, 0);
        }
        public static void PlayMenuMusic(float volume)
        {
            MediaPlayer.Volume = volume;
            MediaPlayer.Play(_menuMusic);
            MediaPlayer.IsRepeating = true;
        }
        public static void PlayGameOver(float volume)
        {
            MediaPlayer.Volume = volume;
            MediaPlayer.Play(_gameOver);
        }
        public static void PlayLevelMusic(float volume)
        {
            MediaPlayer.Volume = volume;
            MediaPlayer.Play(_levelMusic);
            MediaPlayer.IsRepeating = true;
        }
        public static void StopMusic()
        {
            MediaPlayer.Stop();
        }
    }
}
