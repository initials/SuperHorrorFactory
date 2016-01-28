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
    public class PlayState : FlxState
    {
        override public void create()
        {
            base.create();

            Dictionary<string, string> sp = new Dictionary<string, string>();
            sp.Add("Sprite", "SuperHorrorFactory.Avatar");
            sp.Add("x", "100");
            sp.Add("y", "100");

            createSprite(sp);

            sp = new Dictionary<string, string>();
            sp.Add("Sprite", "SuperHorrorFactory.Avatar");
            sp.Add("x", "222");
            sp.Add("y", "222");

            createSprite(sp);

            sp = new Dictionary<string, string>();
            sp.Add("Sprite", "SuperHorrorFactory.Avatar");
            sp.Add("x", "333");
            sp.Add("y", "0");

            createSprite(sp);

            sp = new Dictionary<string, string>();
            sp.Add("Sprite", "SuperHorrorFactory.Avatar");
            sp.Add("x", "0");
            sp.Add("y", "333");

            createSprite(sp);

        }

        public void createSprite(Dictionary<string,string> SpriteInfo)
        {
            var type = Type.GetType(SpriteInfo["Sprite"]);
            Console.WriteLine(type);

            var myObject = (FlxSprite)Activator.CreateInstance(type, 
                Convert.ToInt32(SpriteInfo["x"]), 
                Convert.ToInt32(SpriteInfo["y"]));
            add(myObject);


        }

        override public void update()
        {
            base.update();
        }

        protected bool overlapped(object Sender, FlxSpriteCollisionEvent e)
        {
            ((FlxObject)(e.Object1)).overlapped(e.Object2);
            ((FlxObject)(e.Object2)).overlapped(e.Object1);
            return true;
        }

    }
}
