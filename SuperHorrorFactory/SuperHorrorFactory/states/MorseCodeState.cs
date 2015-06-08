using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using org.flixel;

using System.Linq;
using System.Xml.Linq;

namespace SuperHorrorFactory
{
    public class MorseCodeState : FlxState
    {
        private MorseCodeGraphic morseCodeGraphic;
        private TimeKeeper timeKeeper;

        public FlxGroup morseCodeGraphicGroup;


        override public void create()
        {
            base.create();


            morseCodeGraphicGroup = new FlxGroup();

            for (int i = 0; i < 20; i++)
            {
                morseCodeGraphic = new MorseCodeGraphic(40, 15 * i);
                morseCodeGraphicGroup.add(morseCodeGraphic);
            }

            add(morseCodeGraphicGroup);

            timeKeeper = new TimeKeeper(0, 0);

            add(timeKeeper);

            timeKeeper.velocity.Y = 30;

            

        }

        override public void update()
        {

            if (FlxU.overlap(morseCodeGraphicGroup, timeKeeper, overlapped))
            {

            }
            if (FlxControl.CANCELJUSTPRESSED)
            {
                FlxG.state = new MorseCodeState();
                return;
            }

            base.update();
        }

        protected bool overlapped(object Sender, FlxSpriteCollisionEvent e)
        {
            ((MorseCodeGraphic)(e.Object1)).allowedToIncrease = true;


            return true;
        }

    }
}
