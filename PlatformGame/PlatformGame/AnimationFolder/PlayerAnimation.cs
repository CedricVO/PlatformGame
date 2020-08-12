using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformGame.AnimationFolder
{
    class PlayerAnimation
    {

        public static Animation runAnimation, jumpAnimation, idleAnimation, deathAnimation, currentAnimation;
        public static void CreateAnimationIdle()
        {
            idleAnimation = new Animation(100); //Higher is slower
            int offset = 30;
            idleAnimation.AddFrame(new Rectangle(0 + offset, 5, 80, 125));
            idleAnimation.AddFrame(new Rectangle(160 + offset, 5, 80, 125));
            idleAnimation.AddFrame(new Rectangle(321 + offset, 5, 80, 125));
            idleAnimation.AddFrame(new Rectangle(481 + offset, 5, 80, 125));
            idleAnimation.AddFrame(new Rectangle(641 + offset, 5, 80, 125));
            idleAnimation.AddFrame(new Rectangle(801 + offset, 5, 80, 125));
            idleAnimation.AddFrame(new Rectangle(962 + offset, 5, 80, 125));
            idleAnimation.AddFrame(new Rectangle(1122 + offset, 5, 80, 125));
            idleAnimation.AddFrame(new Rectangle(1282 + offset, 5, 80, 125));
            idleAnimation.AddFrame(new Rectangle(1443 + offset, 5, 80, 125));

            currentAnimation = idleAnimation;
        }
        public static void CreateAnimationRun()
        {
            runAnimation = new Animation(70);
            int offset = 35;
            runAnimation.AddFrame(new Rectangle(0 + offset, 145, 90, 125));
            runAnimation.AddFrame(new Rectangle(160 + offset, 145, 90, 125));
            runAnimation.AddFrame(new Rectangle(321 + offset, 145, 90, 125));
            runAnimation.AddFrame(new Rectangle(481 + offset, 145, 90, 125));
            runAnimation.AddFrame(new Rectangle(641 + offset, 145, 90, 125));
            runAnimation.AddFrame(new Rectangle(801 + offset, 145, 90, 125));
            runAnimation.AddFrame(new Rectangle(962 + offset, 145, 90, 125));
            runAnimation.AddFrame(new Rectangle(1122 + offset, 145, 90, 125));

            currentAnimation = runAnimation;
        }
        public static void CreateAnimationJump()
        {
            jumpAnimation = new Animation(30);
            int offset = 30;
            jumpAnimation.AddFrame(new Rectangle(0 + offset, 430, 100, 125));
            jumpAnimation.AddFrame(new Rectangle(160 + offset, 430, 100, 125));
            jumpAnimation.AddFrame(new Rectangle(321 + offset, 430, 100, 125));
            jumpAnimation.AddFrame(new Rectangle(481 + offset, 430, 100, 125));
            jumpAnimation.AddFrame(new Rectangle(641 + offset, 430, 100, 125));
            jumpAnimation.AddFrame(new Rectangle(801 + offset, 430, 100, 125));
            jumpAnimation.AddFrame(new Rectangle(962 + offset, 430, 100, 125));
            jumpAnimation.AddFrame(new Rectangle(1122 + offset, 430, 100, 125));
            jumpAnimation.AddFrame(new Rectangle(1282 + offset, 430, 100, 125));

            currentAnimation = jumpAnimation;
        }
        public static void CreateAnimationDeath()
        {
            deathAnimation = new Animation(150);
            deathAnimation.AddFrame(new Rectangle(0, 275, 150, 135));
            deathAnimation.AddFrame(new Rectangle(150, 275, 150, 135));
            deathAnimation.AddFrame(new Rectangle(300, 275, 150, 135));
            deathAnimation.AddFrame(new Rectangle(450, 275, 150, 135));
            deathAnimation.AddFrame(new Rectangle(600, 275, 150, 135));
            deathAnimation.AddFrame(new Rectangle(750, 275, 150, 135));
            deathAnimation.AddFrame(new Rectangle(900, 275, 150, 135));
            deathAnimation.AddFrame(new Rectangle(1050, 275, 150, 135));
            deathAnimation.AddFrame(new Rectangle(1200, 275, 150, 135));

            currentAnimation = deathAnimation;
        }
    }
}
