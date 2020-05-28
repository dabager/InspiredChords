using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspiredChords.Lib
{
    public class Chord
    {
        public Note Root { get; set; }
        public ChordType Type { get; set; }
        public Degree Degree { get; set; }
        public Polygon Polygon { get; set; }
        public List<Note> Notes { get; set; }
    }
}
