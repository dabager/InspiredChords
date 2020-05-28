using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspiredChords.Lib
{
    public class Progression
    {
        public Note Root { get; set; }
        public Scale Scale { get; set; }
        public List<Chord> Chords { get; set; }

        public Progression(Note root, ScaleType scale)
        {
            Root = root;
            Scale = new Scale
            {
                Type = scale
            };
            Chords = GenerateChords();
        }

        private List<Chord> GenerateChords()
        {
            var list = new List<Chord>();

            Chord root = GetChord(null);

            list.Add(root);

            while (list.Count() < 16)
            {
                Chord next = GetChord(list.Last());
                list.Add(next);
            }

            return list;
        }

        private Chord GetChord(Chord previous)
        {
            Chord chord = new Chord();
            if (previous == null)
            {
                chord.Degree = Degree.d1_Tonic;
            }
            else
            {
                chord.Degree = DegreeTraverser.Next(previous.Degree);
            }
            
            chord.Polygon = PolygonSelector.Select();
            chord.Notes = new List<Note>();

            for (int i = 0; i < (int)chord.Polygon; i++)
            {
                var degreeIndex = (int)chord.Degree - 1;

                var interval = Scale.Intervals[(degreeIndex + (i * 2)) % 7];

                chord.Notes.Add(AddIntervalToPitch(Root, interval));
            }

            var chordType = ChordType.Major;

            chord.Root = chord.Notes[0];

            var firstNote = (int)chord.Notes[0];
            var secondNote = (int)chord.Notes[1];
            var thirdNote = (int)chord.Notes[2];

            if (firstNote > secondNote)
            {
                secondNote = secondNote + 12;
            }

            if (firstNote > thirdNote)
            {
                thirdNote = thirdNote + 12;
            }

            var thirdDistance = secondNote - firstNote;

            switch (thirdDistance)
            {
                case 2:
                    chordType = ChordType.Sus2;
                    break;
                case 3:
                    chordType = ChordType.Minor;
                    break;
                case 4:
                    chordType = ChordType.Major;
                    break;
                case 5:
                    chordType = ChordType.Sus4;
                    break;
            }

            var fifthDistance = thirdNote - firstNote;

            switch (fifthDistance)
            {
                case 6:
                    chordType = ChordType.Diminished;
                    break;
                case 8:
                    chordType = ChordType.Augmented;
                    break;
            }

            chord.Type = chordType;

            return chord;
        }

        private Note AddIntervalToPitch(Note root, Interval interval)
        {
            var note = Note.A;
            var rootIndex = (int)root;
            var intervalIndex = (int)interval;

            note = (Note)((rootIndex + intervalIndex) % 12);

            return note;
        }
    }
}
