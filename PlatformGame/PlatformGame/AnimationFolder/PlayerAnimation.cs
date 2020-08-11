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
            idleAnimation = new Animation(50);
            idleAnimation.AddFrame(new Rectangle(0, 186, 213, 186));
            idleAnimation.AddFrame(new Rectangle(214, 186, 213, 186));
            idleAnimation.AddFrame(new Rectangle(428, 186, 213, 186));
            idleAnimation.AddFrame(new Rectangle(642, 186, 213, 186));
            idleAnimation.AddFrame(new Rectangle(856, 186, 213, 186));
            idleAnimation.AddFrame(new Rectangle(1070, 186, 213, 186));
            idleAnimation.AddFrame(new Rectangle(1284, 186, 213, 186));
            idleAnimation.AddFrame(new Rectangle(1498, 186, 213, 186));
            idleAnimation.AddFrame(new Rectangle(1712, 186, 213, 186));
            idleAnimation.AddFrame(new Rectangle(1926, 186, 213, 186));

            currentAnimation = idleAnimation;
        }
        public static void CreateAnimationRun()
        {
            runAnimation = new Animation(50);
            runAnimation.AddFrame(new Rectangle(0, 558, 213, 168));
            runAnimation.AddFrame(new Rectangle(214, 558, 213, 168));
            runAnimation.AddFrame(new Rectangle(428, 558, 213, 168));
            runAnimation.AddFrame(new Rectangle(642, 558, 213, 168));
            runAnimation.AddFrame(new Rectangle(856, 558, 213, 168));
            runAnimation.AddFrame(new Rectangle(1070, 558, 213, 168));
            runAnimation.AddFrame(new Rectangle(1284, 558, 213, 168));
            runAnimation.AddFrame(new Rectangle(1498, 558, 213, 168));

            currentAnimation = runAnimation;
        }
        public static void CreateAnimationJump()
        {
            jumpAnimation = new Animation(50);
            jumpAnimation.AddFrame(new Rectangle(0, 372, 213, 372));
            jumpAnimation.AddFrame(new Rectangle(214, 372, 213, 372));
            jumpAnimation.AddFrame(new Rectangle(428, 372, 213, 372));
            jumpAnimation.AddFrame(new Rectangle(642, 372, 213, 372));
            jumpAnimation.AddFrame(new Rectangle(856, 372, 213, 372));
            jumpAnimation.AddFrame(new Rectangle(1070, 372, 213, 372));
            jumpAnimation.AddFrame(new Rectangle(1284, 372, 213, 372));
            jumpAnimation.AddFrame(new Rectangle(1498, 372, 213, 372));
            jumpAnimation.AddFrame(new Rectangle(1712, 372, 213, 372));
            jumpAnimation.AddFrame(new Rectangle(1926, 372, 213, 372));

            currentAnimation = jumpAnimation;
        }
        public static void CreateAnimationDeath()
        {
            deathAnimation = new Animation(50);
            deathAnimation.AddFrame(new Rectangle(0, 0, 200, 186));
            deathAnimation.AddFrame(new Rectangle(200, 0, 200, 186));
            deathAnimation.AddFrame(new Rectangle(400, 0, 200, 186));
            deathAnimation.AddFrame(new Rectangle(600, 0, 200, 186));
            deathAnimation.AddFrame(new Rectangle(800, 0, 200, 186));
            deathAnimation.AddFrame(new Rectangle(1000, 0, 200, 186));
            deathAnimation.AddFrame(new Rectangle(1200, 0, 200, 186));
            deathAnimation.AddFrame(new Rectangle(1400, 0, 200, 186));
            deathAnimation.AddFrame(new Rectangle(1600, 0, 200, 186));
            deathAnimation.AddFrame(new Rectangle(1800, 0, 200, 186));
            deathAnimation.AddFrame(new Rectangle(2000, 0, 200, 186));

            currentAnimation = deathAnimation;
        }
    }
}
