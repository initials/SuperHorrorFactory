using System;
using Midi;
using System.Threading;
using System.Collections.Generic;

namespace SuperHorrorFactory
{
    class MidiInput : InputManager
    {
        private InputDevice inputDevice;

        //List<Melody.Note> pressedNotes = new List<Melody.Note>();

        static List<NoteOnMessage> record = new List<NoteOnMessage>();



        public static void playRecord()
        {
          /*  if (OutputDevice.InstalledDevices.Count > 0)
            {
                OutputDevice.InstalledDevices[OutputDevice.InstalledDevices.Count-1].Open();
                new Thread(delegate()
                {
                    while (record.Count > 0)
                    {
                        OutputDevice.InstalledDevices[OutputDevice.InstalledDevices.Count - 1].SendNoteOn(record[0].Channel, record[0].Pitch, record[0].Velocity);
                        System.Threading.Thread.Sleep(200);
                        OutputDevice.InstalledDevices[OutputDevice.InstalledDevices.Count - 1].SendNoteOff(record[0].Channel, record[0].Pitch, record[0].Velocity);
                        System.Threading.Thread.Sleep(400);
                        record.RemoveAt(0);
                    }
                }).Start();
            } */
        }

        public MidiInput()
        {
            inputDevice = InputDevice.InstalledDevices[1];
            inputDevice.Open();
            inputDevice.StartReceiving(null);
            inputDevice.NoteOn += new InputDevice.NoteOnHandler(this.NoteOn);
            inputDevice.NoteOff += new InputDevice.NoteOffHandler(this.NoteOff);
        }

        public void NoteOn(NoteOnMessage msg)
        {
            lock (this)
            {
                //Melody.Note note = (Melody.Note)msg.Pitch.PositionInOctave();
                //if (!pressedNotes.Contains(note))
                //{
                //    pressedNotes.Add(note);
                //    record.Add(msg);
                //}
            }
        }

        public void NoteOff(NoteOffMessage msg)
        {
            lock (this)
            {
                //Melody.Note note = (Melody.Note)msg.Pitch.PositionInOctave();
                //pressedNotes.RemoveAll(x => x == note);
            }
        }

        //public List<Melody.Note> GetPressedNotes()
        //{
        //    lock (this)
        //    {
        //        return new List<Melody.Note>(pressedNotes);
        //    }
        //}
    }
}
