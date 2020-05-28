using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspiredChords.Lib
{
    public class Scale
    {
        public ScaleType Type { get; set; }
        public List<Interval> Intervals
        {
            get
            {
                var list = new List<Interval>();

                list.Add(Interval.s00_Unison);

                if (Type == ScaleType.Major)
                {
                    list.Add(Interval.s02_Major2);
                    list.Add(Interval.s04_Major3);
                    list.Add(Interval.s05_Perfect4);
                    list.Add(Interval.s07_Perfect5);
                    list.Add(Interval.s09_Major6);
                    list.Add(Interval.s11_Major7);
                }
                else if (Type == ScaleType.Minor)
                {
                    list.Add(Interval.s02_Major2);
                    list.Add(Interval.s03_Minor3);
                    list.Add(Interval.s05_Perfect4);
                    list.Add(Interval.s07_Perfect5);
                    list.Add(Interval.s08_Minor6);
                    list.Add(Interval.s10_Minor7);
                }

                return list;
            }
        }

        public ChordType GetFirstChordType()
        {
            ChordType type = ChordType.Major;

            switch (Type)
            {
                case ScaleType.Major:
                case ScaleType.Lydian:
                case ScaleType.Mixolydian:
                    type = ChordType.Major;
                    break;
                case ScaleType.Minor:
                case ScaleType.Dorian:
                case ScaleType.Phyrigian:
                    type = ChordType.Minor;
                    break;
                case ScaleType.Locrian:
                    type = ChordType.Diminished;
                    break;
            }

            return type;
        }
    }
}
