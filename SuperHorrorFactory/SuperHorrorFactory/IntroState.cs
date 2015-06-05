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
    public class IntroState : FlxState
    {
        private Avatar avatar;

        override public void create()
        {
            FlxG.backColor = Color.Purple;
            base.create();

            FlxSprite testPattern = new FlxSprite(0, 0);
            testPattern.loadGraphic("flixel/diagnostic/checkerboard");
            add(testPattern);

            Logo logo = new Logo(0, 0);
            add(logo);

            avatar = new Avatar(100, 100);
            add(avatar);

            FlxSprite logo2 = new FlxSprite(0, 0);
            logo2.loadGraphic("logo/logo", true, false, 114, 58);
            logo2.addAnimationsFromGraphicsGaleCSV("content/logo/logo.csv", null, null, false );
            logo2.play("drip");
            add(logo2);

        }

        override public void update()
        {

            base.update();
        }

        public override void render(SpriteBatch spriteBatch)
        {
            
            base.render(spriteBatch);
        }


    }
}
