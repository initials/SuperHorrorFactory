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
    class MorseCodeGraphic : FlxSprite
    {
        public bool allowedToIncrease;

        public FlxSprite backgroundMarker;


        public MorseCodeGraphic(int xPos, int yPos)
            : base(xPos, yPos)
        {
            //loadGraphic(FlxG.Content.Load<Texture2D>("flixel/pixel"), true, false, 1, 1);
            createGraphic(10, 10, Color.CadetBlue);

            color = Color.CadetBlue;

            width = 10;
            height = 10;

            allowedToIncrease = false;

            //backgroundMarker = new FlxSprite(xPos, yPos);
            //createGraphic(10 + ( false=1 ? 2), 10, Color.White);

        }


        override public void update()
        {
            //active = true;
            if (FlxControl.ACTION && allowedToIncrease)
            {
                width += 10;
            }
            

            base.update();


            allowedToIncrease = false;
        }
        public override void render(SpriteBatch spriteBatch)
        {
            //backgroundMarker.render(spriteBatch);

            base.render(spriteBatch);
        }


    }
}
