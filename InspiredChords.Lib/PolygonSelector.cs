using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InspiredChords.Lib
{
    public static class PolygonSelector
    {
        public const int TRIAD_PROB = 85;
        public const int TETRAD_PROB = 11;
        public const int PENTAD_PROB = 100 - (TRIAD_PROB + TETRAD_PROB);
        public static Polygon Select()
        {
            Polygon poly = Polygon.Triad;

            Thread.Sleep(15);
            Random rand = new Random();
            var val = rand.Next(0, 99);

            if (val < TRIAD_PROB)
            {
                poly = Polygon.Triad;
            }
            else if (val >= TRIAD_PROB && val <= 100 - PENTAD_PROB)
            {
                poly = Polygon.Tetrad;
            }
            else
            {
                poly = Polygon.Pentad;
            }

            return poly;
        }
    }
}
