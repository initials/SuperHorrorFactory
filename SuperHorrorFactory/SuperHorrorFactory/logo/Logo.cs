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
    class Logo : FlxSprite
    {
        private Tweener t;

        public Logo(int xPos, int yPos)
            : base(xPos, yPos)
        {
            loadGraphic("flixel/initials/initialsLogo");

            centerAtX();
            centerAtY();

            t = new Tweener(0, 360, 3.0f, XNATweener.Linear.EaseInOut);
            t.PingPong = true;


            
            
        }

        override public void update()
        {

            angle = t.Position;

            t.Update(FlxG.elapsedAsGameTime);
            base.update();

        }


    }
}
