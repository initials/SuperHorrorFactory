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
        private FlxTilemap tiles;

        override public void create()
        {
            base.create();

            createTestObjects();

            buildCave();

        }

        private void buildCave()
        {
            // make a new cave of tiles 50x40;
            FlxCaveGenerator cav = new FlxCaveGenerator(50, 40, 0.52f, 5);

            //Create a matrix based on these parameters.
            int[,] matr = cav.generateCaveLevel(3, 0, 2, 0, 1, 1, 1, 1);
            matr = cav.editRectangle(matr, 2, 2, 4, 4, 0);
            matr = cav.editRectangle(matr, 10, 10, 4, 4, 1);

            matr = cav.editRectangle(matr, 4, 4, 2, 2, 0);
            matr = cav.editRectangle(matr, 8, 8, 2, 2, 0);

            //convert the array to a comma separated string
            string newMap = cav.convertMultiArrayToString(matr);

            //Create a tilemap and assign the cave map.
            tiles = new FlxTilemap();
            tiles.auto = FlxTilemap.AUTO;
            tiles.loadMap(newMap, FlxG.Content.Load<Texture2D>("flixel/autotiles_16x16"), 16, 16);
            tiles.setScrollFactors(1, 1);
            add(tiles);
        }

        private void createTestObjects()
        {
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
            sp.Add("x", "66");
            sp.Add("y", "0");

            createSprite(sp);

            sp = new Dictionary<string, string>();
            sp.Add("Sprite", "SuperHorrorFactory.Avatar");
            sp.Add("x", "0");
            sp.Add("y", "55");

            createSprite(sp);
        }

        public void createSprite(Dictionary<string,string> SpriteInfo)
        {
            var type = Type.GetType(SpriteInfo["Sprite"]);

            var myObject = (FlxSprite)Activator.CreateInstance(type, 
                Convert.ToInt32(SpriteInfo["x"]), 
                Convert.ToInt32(SpriteInfo["y"]));
            add(myObject);

        }

        override public void update()
        {
            if (FlxG.keys.ENTER)
            {
                FlxG.state = new PlayState();
                return;
            }
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
