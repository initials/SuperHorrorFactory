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
    class TimeKeeper : FlxSprite
    {

        public TimeKeeper(int xPos, int yPos)
            : base(xPos, yPos)
        {
            createGraphic(50, 2, Color.Red);
        }

        override public void update()
        {


            base.update();

        }


    }
}
