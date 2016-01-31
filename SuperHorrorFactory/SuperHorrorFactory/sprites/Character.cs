/*
 * Add these to Visual Studio to quickly create new FlxSprites
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.flixel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNATweener;

namespace SuperHorrorFactory
{
    class Character : FlxSprite
    {
        /// <summary>
        /// A temporary bool to determine if the sprite is ready.
        /// </summary>
        private bool _ready;

        private Vector2Tweener tween;

        /// <summary>
        /// Sprite Constructor
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        public Character(int xPos, int yPos)
            : base(xPos, yPos)
        {
            loadGraphic("characters/oryx_16bit_fantasy_creatures_trans", true, false, 24, 24);


            int c = FlxU.randomInt(21, 29);

            //c *= 2;

            //c += 1;

            addAnimation("idle", new int[] { c, (c+20) }, FlxU.randomInt(2,6), true);

            play("idle");

            tween = new Vector2Tweener(new Vector2(x,y), new Vector2(x,y), 0.3f, XNATweener.Cubic.EaseOut);

            tween.Ended +=new EndHandler(endTween);

            tween.Pause();
            
        }



        public void endTween()
        {
            tween.Pause();
            //tween.Stop();
        }

        /// <summary>
        /// The Update Cycle. Called once every cycle.
        /// </summary>
        override public void update()
        {
            if (!tween.Playing)
            {
                if (FlxG.keys.justPressed(Keys.S) || FlxU.random() < 0.015f)
                {
                    moveDown();
                }
                if (FlxG.keys.justPressed(Keys.W) || FlxU.random() < 0.015f)
                {
                    moveUp();
                }
                if (FlxG.keys.justPressed(Keys.A) || FlxU.random() < 0.015f)
                {
                    moveLeft();
                }
                if (FlxG.keys.justPressed(Keys.D) || FlxU.random() < 0.015f)
                {
                    moveRight();
                }
            }



            x = tween.Position.X;
            y = tween.Position.Y;

            tween.Update(FlxG.elapsedAsGameTime);

            base.update();
        }

        private void moveRight()
        {
            tween = new Vector2Tweener(new Vector2(x, y), new Vector2(x + 24, y), 0.3f, XNATweener.Cubic.EaseOut);
            tween.Ended += new EndHandler(endTween);
        }

        private void moveLeft()
        {
            tween = new Vector2Tweener(new Vector2(x, y), new Vector2(x - 24, y), 0.3f, XNATweener.Cubic.EaseOut);
            tween.Ended += new EndHandler(endTween);
        }

        private void moveUp()
        {
            tween = new Vector2Tweener(new Vector2(x, y), new Vector2(x, y - 24), 0.3f, XNATweener.Cubic.EaseOut);
            tween.Ended += new EndHandler(endTween);
        }

        private void moveDown()
        {
            tween = new Vector2Tweener(new Vector2(x, y), new Vector2(x, y + 24), 0.3f, XNATweener.Cubic.EaseOut);
            tween.Ended += new EndHandler(endTween);
        }

        /// <summary>
        /// The render code. Add any additional render code here.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void render(SpriteBatch spriteBatch)
        {
            base.render(spriteBatch);
        }

        /// <summary>
        /// Called when the sprite hit something on its bottom edge.
        /// </summary>
        /// <param name="Contact">The Object that it collided with.</param>
        /// <param name="Velocity">The Velocity that is will now have???</param>
        public override void hitBottom(FlxObject Contact, float Velocity)
        {
            base.hitBottom(Contact, Velocity);
        }

        /// <summary>
        /// Called when the sprite hits something on its left side.
        /// </summary>
        /// <param name="Contact">The Object that it collided with.</param>
        /// <param name="Velocity"></param>
        public override void hitLeft(FlxObject Contact, float Velocity)
        {
            base.hitLeft(Contact, Velocity);
        }

        /// <summary>
        /// Called when the sprite hits something on its right side
        /// </summary>
        /// <param name="Contact"></param>
        /// <param name="Velocity"></param>
        public override void hitRight(FlxObject Contact, float Velocity)
        {
            base.hitRight(Contact, Velocity);
        }

        /// <summary>
        /// Called when the sprite hits something on its side, either left or right.
        /// </summary>
        /// <param name="Contact"></param>
        /// <param name="Velocity"></param>
        public override void hitSide(FlxObject Contact, float Velocity)
        {
            base.hitSide(Contact, Velocity);
        }

        /// <summary>
        /// Called when the sprite hits something on its top
        /// </summary>
        /// <param name="Contact"></param>
        /// <param name="Velocity"></param>
        public override void hitTop(FlxObject Contact, float Velocity)
        {
            base.hitTop(Contact, Velocity);
        }

        /// <summary>
        /// Used when the sprite is damaged or hurt. Takes points off "Health".
        /// </summary>
        /// <param name="Damage">Amount of damage to take away.</param>
        public override void hurt(float Damage)
        {
            base.hurt(Damage);
        }

        /// <summary>
        /// Kill the sprite.
        /// </summary>
        public override void kill()
        {
            base.kill();
        }
    }
}
