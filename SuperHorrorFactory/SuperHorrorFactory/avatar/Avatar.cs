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
    class Avatar : FlxSprite
    {

        public Avatar(int xPos, int yPos)
            : base(xPos, yPos)
        {
            loadGraphic("avatar/andre", true, false, 67, 100);

            addAnimationsFromGraphicsGaleCSV("content/avatar/andre.csv", null, null, false);

            play("idle");

            addAnimationCallback(check);
        }

        public void check(string Name, uint Frame, int FrameIndex)
        {

        }

        override public void update()
        {

            if (FlxG.keys.ONE)
                play("idle");
            if (FlxG.keys.TWO)
                play("talk");
            if (FlxG.keys.THREE)
                play("blink");
            if (FlxG.keys.FOUR)
                play("LWink");
            if (FlxG.keys.FIVE)
                play("RWink");
            if (FlxG.keys.SIX)
                play("eyeroll");


            base.update();
        }

        public override void render(SpriteBatch spriteBatch)
        {
            base.render(spriteBatch);
        }

        public override void hitBottom(FlxObject Contact, float Velocity)
        {
            base.hitBottom(Contact, Velocity);
        }

        public override void hitLeft(FlxObject Contact, float Velocity)
        {
            base.hitLeft(Contact, Velocity);
        }

        public override void hitRight(FlxObject Contact, float Velocity)
        {
            base.hitRight(Contact, Velocity);
        }

        public override void hitSide(FlxObject Contact, float Velocity)
        {
            base.hitSide(Contact, Velocity);
        }

        public override void hitTop(FlxObject Contact, float Velocity)
        {
            base.hitTop(Contact, Velocity);
        }

        public override void hurt(float Damage)
        {
            base.hurt(Damage);
        }

        public override void kill()
        {
            base.kill();
        }
    }
}
