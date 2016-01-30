using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using org.flixel;
using System.Linq;
using System.Xml.Linq;
using Midi;

namespace SuperHorrorFactory
{
    public class PlayState : FlxState
    {
        private FlxTilemap tiles;
        List<Dictionary<string, string>> p;
        private static FlxMidi midi;

        override public void create()
        {
            base.create();

            //createTestObjects();

            p = FlxXMLReader.readNodesFromOelFile("Content/levels/testLevel.oel", "level/Sprites");

            foreach (Dictionary<string, string> item in p)
            {
                createSprite(item); //item["Name"], item["x"], item["y"]
            }

            buildCave();

            midi = new FlxMidi();
            //n.Run();

            //input = new MidiInput();
        }

        private void buildCave()
        {
            // make a new cave of tiles 50x40;
            FlxCaveGenerator cav = new FlxCaveGenerator(50, 50, 0.48f, 5);

            //Create a matrix based on these parameters.
            int[,] matr = cav.generateCaveLevel(3, 0, 2, 0, 1, 1, 1, 1);
            foreach (Dictionary<string, string> item in p)
            {
                if (item["Name"]=="Crate")
                    matr = cav.editRectangle(matr, Convert.ToInt32(item["x"]) / 16, Convert.ToInt32(item["y"]) / 16 , 4, 4, 0);
            }

            //convert the array to a comma separated string
            string newMap = cav.convertMultiArrayToString(matr);

            //Create a tilemap and assign the cave map.
            tiles = new FlxTilemap();
            tiles.auto = FlxTilemap.AUTO;
            tiles.loadMap(newMap, FlxG.Content.Load<Texture2D>("tiles/lemonade_autotiles_16x16"), 16, 16);
            tiles.setScrollFactors(1, 1);
            add(tiles);
        }

        private void createTestObjects()
        {
            Dictionary<string, string> sp = new Dictionary<string, string>();
            sp.Add("Name", "Avatar");
            sp.Add("x", "100");
            sp.Add("y", "100");

            createSprite(sp);

            sp = new Dictionary<string, string>();
            sp.Add("Name", "Avatar");
            sp.Add("x", "222");
            sp.Add("y", "222");

            createSprite(sp);

            sp = new Dictionary<string, string>();
            sp.Add("Name", "Avatar");
            sp.Add("x", "66");
            sp.Add("y", "0");

            createSprite(sp);

            sp = new Dictionary<string, string>();
            sp.Add("Name", "Avatar");
            sp.Add("x", "0");
            sp.Add("y", "55");

            createSprite(sp);
        }

        public void createSprite(Dictionary<string,string> SpriteInfo)
        {
            string namePass =  "SuperHorrorFactory." + SpriteInfo["Name"];
            var typ = Type.GetType(namePass);

            var myObject = (FlxSprite)Activator.CreateInstance(typ, 
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

            midi.Run();
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
