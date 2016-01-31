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
        //private static FlxMidi midi;

        override public void create()
        {
            base.create();

            FlxG.elapsedTotal = 0;

            //Registry reg = new Registry();

            //createTestObjects();

            p = FlxXMLReader.readNodesFromOelFile("Content/levels/testLevel.oel", "level/Sprites");

            //foreach (Dictionary<string, string> item in p)
            //{
            //    createSprite(item); //item["Name"], item["x"], item["y"]
            //}

            buildCave();

            //midi = new org.flixel.FlxMidi();

            //Registry.midi.inputDevice.NoteOn += new InputDevice.NoteOnHandler(NoteOnCommand);

            //n.Run();

            //input = new MidiInput();

            p = FlxXMLReader.readNodesFromOelFile("Content/levels/oryx.oel", "level/Tiles");
            //Console.WriteLine(p[0]["InnerText"]);
            tiles = new FlxTilemap();
            tiles.auto = FlxTilemap.STRING;
            tiles.loadMap(p[0]["InnerText"], FlxG.Content.Load<Texture2D>("tiles/oryx_16bit_fantasy_world_trans"), 24, 24);
            tiles.setScrollFactors(1, 1);
            //add(tiles);

        }

        void NoteOnCommand(NoteOnMessage msg)
        {
            //Console.WriteLine("YAY");
            Dictionary<string, string> x = new Dictionary<string, string>();
            x.Add("Name", "TileCrate");
            x.Add("x", ((int)(((-100 + (int)msg.Pitch * 16) / 16) * 16)).ToString());
            x.Add("y", ((int)(((-100 + (int)msg.Velocity * 4) / 16) * 16)).ToString());
            x.Add("width", ((int)((((int)msg.Velocity * 1) / 16) * 16)/1).ToString());
            x.Add("height", ((int)((((int)msg.Velocity * 1) / 16) * 16)/1).ToString());
            Registry.boxes.Add(x);

            Registry.midi.inputDevice.RemoveAllEventHandlers();
            FlxG.state = new PlayState();
            return;



        }

        private void buildCave()
        {
            // make a new cave of tiles 50x40;
            FlxCaveGenerator cav = new FlxCaveGenerator(50, 50, 0.52f, 30);

            //Create a matrix based on these parameters.
            int[,] matr = cav.generateCaveLevel(3, 0, 2, 0, 1, 1, 1, 1);

            foreach (Dictionary<string, string> item in Registry.boxes)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} ", item["Name"], item["x"], item["y"], item["width"], item["height"]);

                if (item["Name"] == "TileCrate")
                {

                    createTileblock(item);

                    matr = cav.editRectangle(matr, Convert.ToInt32(item["x"]) / 16, Convert.ToInt32(item["y"]) / 16, Convert.ToInt32(item["width"]) / 16, Convert.ToInt32(item["height"]) / 16, 0);
                }
            }
            //foreach (Dictionary<string, string> item in p)
            //{
            //    if (item["Name"]=="Crate")
            //        matr = cav.editRectangle(matr, Convert.ToInt32(item["x"]) / 16, Convert.ToInt32(item["y"]) / 16 , 4, 4, 0);
            //}

            //convert the array to a comma separated string
            string newMap = cav.convertMultiArrayToString(matr);

            //Create a tilemap and assign the cave map.
            tiles = new FlxTilemap();
            tiles.auto = FlxTilemap.REMAPALT;
            tiles.loadMap(newMap, FlxG.Content.Load<Texture2D>("tiles/oryx_16bit_fantasy_world_trans"), 24, 24);
            tiles.setScrollFactors(1, 1);
            add(tiles);

            Registry.level = tiles ;

            for (int i = 0; i < 55; i++)
            {
                int rx = FlxU.randomInt(1, 35);
                int ry = FlxU.randomInt(1, 35);
                
                int rz = tiles.getTile(rx, ry);

                if (rz == 292)
                {
                    Dictionary<string, string> x = new Dictionary<string, string>();
                    x.Add("Name", "PickUp");
                    x.Add("x", (rx*24).ToString() );
                    x.Add("y", (ry*24).ToString() );

                    createSprite(x);
                }

            }

            for (int i = 0; i < 102; i++)
            {
                int rx = FlxU.randomInt(1, 35);
                int ry = FlxU.randomInt(1, 35);

                int rz = tiles.getTile(rx, ry);

                if (rz == 292)
                {
                    Dictionary<string, string> x = new Dictionary<string, string>();
                    x.Add("Name", "Character");
                    x.Add("x", (rx * 24).ToString());
                    x.Add("y", ((ry * 24)-2).ToString());

                    createSprite(x);
                }

            }



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

        public void createTileblock(Dictionary<string, string> SpriteInfo)
        {
            string namePass = "SuperHorrorFactory." + SpriteInfo["Name"];
            var typ = Type.GetType(namePass);

            var myObject = (FlxSprite)Activator.CreateInstance(typ,
                Convert.ToInt32(SpriteInfo["x"]),
                Convert.ToInt32(SpriteInfo["y"]), 
                Convert.ToInt32(SpriteInfo["width"]), 
                Convert.ToInt32(SpriteInfo["height"]));
            add(myObject);

        }


        public void createSprite(Dictionary<string,string> SpriteInfo)
        {
            string namePass =  "SuperHorrorFactory." + SpriteInfo["Name"];
            var typ = Type.GetType(namePass);

            var myObject = (FlxSprite)Activator.CreateInstance(typ, 
                Convert.ToInt32(SpriteInfo["x"]), 
                Convert.ToInt32(SpriteInfo["y"]));
            add(myObject);

            FlxG.follow(myObject, 9);
            FlxG.followBounds(0, 0, 10000, 10000);

        }

        override public void update()
        {


            base.update();

            if (FlxG.elapsedTotal> 1.0f)
            {
                if (FlxG.keys.justPressed(Keys.Enter))
                {
                    //Registry.midi.inputDevice.RemoveAllEventHandlers();
                    FlxG.state = new PlayState();
                    return;
                }
            }


            //Registry.midi.Run();


        }

        protected bool overlapped(object Sender, FlxSpriteCollisionEvent e)
        {
            ((FlxObject)(e.Object1)).overlapped(e.Object2);
            ((FlxObject)(e.Object2)).overlapped(e.Object1);
            return true;
        }

    }
}
