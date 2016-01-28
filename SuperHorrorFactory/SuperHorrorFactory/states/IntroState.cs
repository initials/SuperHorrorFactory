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
        private FlxSprite logo2;

        override public void create()
        {
            FlxG.backColor = new Color(0.15f, 0.15f, 0.15f);
            base.create();

            logo2 = new FlxSprite(0, 0);
            logo2.loadGraphic("logo/logo", true, false, 114, 58);
            logo2.addAnimationsFromGraphicsGaleCSV("content/logo/logo.csv", null, null, false );
            //logo2.play("drip");
            logo2.visible = false;
            add(logo2);

            logo2.scale = 2;

            logo2.atScreenPercent(0.5f, 0.35f);

            avatar = new Avatar(100, 100);
            avatar.scale = 2;
            avatar.atScreenPercent(0.5f, 0.7f);
            avatar.visible = false;
            add(avatar);


        }

        override public void update()
        {
            if (FlxG.elapsedFrames == 5)
            {
                FlxG.flash.start(Color.White, 0.5f, endFlash, true);
                FlxG.play("sfx/thunder", 0.5f);
            }

            if (FlxG.elapsedFrames > 45)
            {
                if (FlxG.elapsedFrames % 250 == 0)
                {
                    FlxG.flash.start(Color.White, 2.05f, endFlash2, true);

                    //avatar.play("eyeroll", true);
                    FlxG.play("sfx/thunder", 0.5f);

                }
            }



            if (FlxG.keys.F1)
            {
                FlxG.state = new MorseCodeState();
                return;
            }

            base.update();

            if (FlxG.keys.justPressed(Keys.Enter))
            {
                FlxG.state = new PlayState();
                return;
            }
        }

        private void endFlash(object Sender, FlxEffectCompletedEvent e) 
        {
            logo2.visible = true;
            logo2.play("drip");

            FlxG.flash.start(Color.White, 0.5f, endFlash2, true);

        }

        private void endFlash2(object Sender, FlxEffectCompletedEvent e)
        {
            avatar.visible = true;
            //avatar.play("eyeroll", true);
            FlxG.play("sfx/thunder", 0.5f);
        }


        public override void render(SpriteBatch spriteBatch)
        {
            
            base.render(spriteBatch);
        }


    }
}
