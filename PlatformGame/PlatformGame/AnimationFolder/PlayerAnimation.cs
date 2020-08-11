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
            idleAnimation.AddFrame(new Rectangle(6086, 0, 641, 604));
            idleAnimation.AddFrame(new Rectangle(6727, 0, 641, 604));
            idleAnimation.AddFrame(new Rectangle(7368, 0, 641, 604));
            idleAnimation.AddFrame(new Rectangle(8009, 0, 641, 604));
            idleAnimation.AddFrame(new Rectangle(8650, 0, 641, 604));
            idleAnimation.AddFrame(new Rectangle(9291, 0, 641, 604));
            idleAnimation.AddFrame(new Rectangle(9932, 0, 641, 604));
            idleAnimation.AddFrame(new Rectangle(10573, 0, 641, 604));
            idleAnimation.AddFrame(new Rectangle(11214, 0, 641, 604));
            idleAnimation.AddFrame(new Rectangle(11855, 0, 641, 604));

            currentAnimation = idleAnimation;
        }
        public static void CreateAnimationRun()
        {
            runAnimation = new Animation(50);
            runAnimation.AddFrame(new Rectangle(18906, 0, 641, 604));
            runAnimation.AddFrame(new Rectangle(19547, 0, 641, 604));
            runAnimation.AddFrame(new Rectangle(20188, 0, 641, 604));
            runAnimation.AddFrame(new Rectangle(20829, 0, 641, 604));
            runAnimation.AddFrame(new Rectangle(21470, 0, 641, 604));
            runAnimation.AddFrame(new Rectangle(22111, 0, 641, 604));
            runAnimation.AddFrame(new Rectangle(22752, 0, 641, 604));
            runAnimation.AddFrame(new Rectangle(23393, 0, 641, 604));

            currentAnimation = runAnimation;
        }
        public static void CreateAnimationJump()
        {
            jumpAnimation = new Animation(50);
            jumpAnimation.AddFrame(new Rectangle(12496, 0, 641, 604));
            jumpAnimation.AddFrame(new Rectangle(13137, 0, 641, 604));
            jumpAnimation.AddFrame(new Rectangle(13778, 0, 641, 604));
            jumpAnimation.AddFrame(new Rectangle(14419, 0, 641, 604));
            jumpAnimation.AddFrame(new Rectangle(15060, 0, 641, 604));
            jumpAnimation.AddFrame(new Rectangle(15701, 0, 641, 604));
            jumpAnimation.AddFrame(new Rectangle(16342, 0, 641, 604));
            jumpAnimation.AddFrame(new Rectangle(16983, 0, 641, 604));
            jumpAnimation.AddFrame(new Rectangle(17624, 0, 641, 604));
            jumpAnimation.AddFrame(new Rectangle(18265, 0, 641, 604));

            currentAnimation = jumpAnimation;
        }
        public static void CreateAnimationDeath()
        {
            deathAnimation = new Animation(50);
            deathAnimation.AddFrame(new Rectangle(0, 0, 605, 604));
            deathAnimation.AddFrame(new Rectangle(605, 0, 605, 604));
            deathAnimation.AddFrame(new Rectangle(1210, 0, 605, 604));
            deathAnimation.AddFrame(new Rectangle(1815, 0, 605, 604));
            deathAnimation.AddFrame(new Rectangle(2420, 0, 605, 604));
            deathAnimation.AddFrame(new Rectangle(3025, 0, 605, 604));
            deathAnimation.AddFrame(new Rectangle(3630, 0, 605, 604));
            deathAnimation.AddFrame(new Rectangle(4235, 0, 605, 604));
            deathAnimation.AddFrame(new Rectangle(4840, 0, 605, 604));
            deathAnimation.AddFrame(new Rectangle(5445, 0, 605, 604));

            currentAnimation = deathAnimation;
        }
    }
}
