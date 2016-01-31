﻿/*
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

namespace SuperHorrorFactory
{
    class PickUp : FlxSprite
    {
        /// <summary>
        /// A temporary bool to determine if the sprite is ready.
        /// </summary>
        private bool _ready;

        /// <summary>
        /// Sprite Constructor
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        public PickUp(int xPos, int yPos)
            : base(xPos, yPos)
        {
            //createGraphic(24, 24, Color.Green);
            //tiles.loadMap(newMap, FlxG.Content.Load<Texture2D>("tiles/oryx_16bit_fantasy_world_trans"), 24, 24);
            loadGraphic("tiles/oryx_16bit_fantasy_world_trans", false, false, 24, 24);
            //436,437,438,439,440,441

            string choices = "257,258,259,260,261,262,263,264,265,266,267,268,269,270,314,315,316,317,318,319,320,321,322,323,324,325,326,327,371,372,373,374,375,376,377,378,379,380,381,382,383,384,428,429,430,431,432,433,434,435,436,437,438,439,440,441,485,486,487,488,489,490,491,492,493,494,495,496,497,498,542,543,544,545,546,547,548,549,550,551,552,553,554,555,599,600,601,602,603,604,605,606,607,608,609,610,611,612";
            string[] c = choices.Split(',');
            //
            frame = Convert.ToInt32(c[Convert.ToInt32(FlxU.randomInt(0, c.Length))]);

        }

        /// <summary>
        /// The Update Cycle. Called once every cycle.
        /// </summary>
        override public void update()
        {
            base.update();
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
