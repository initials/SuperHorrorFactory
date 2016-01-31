using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.flixel;

namespace SuperHorrorFactory
{
    public class Registry
    {
        //public static Dictionary<string, string> boxes;

        public static List<Dictionary<string, string>> boxes = new List<Dictionary<string, string>>();
        public static FlxMidi midi;

        public static FlxTilemap level;

        public Registry()
        {
            //midi = new FlxMidi();

        }

    }
}
