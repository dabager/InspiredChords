using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InspiredChords.Lib
{
    public static class DegreeTraverser
    {
        private static List<int> harmonicOrder = new List<int> { 1, 6, 4, 2, 7, 5 };

        public static List<Degree> Traverse(Degree from)
        {
            var to = new List<Degree>();

            //Forward
            if (from != Degree.d3_Mediant)
            {
                int fromValue = (int)from;

                var orderIndex = harmonicOrder.IndexOf(fromValue);

                for (int i = orderIndex + 1; i < harmonicOrder.Count(); i++)
                {
                    to.Add((Degree)harmonicOrder[i]);
                }
            }

            //Backwards
            
            if (from == Degree.d5_Dominant)
            {
                to.Add(Degree.d6_Submediant);
                to.Add(Degree.d4_Subdominant);
                to.Add(Degree.d1_Tonic);
            }
            else if (from == Degree.d6_Submediant)
            {
                to.Add(Degree.d1_Tonic);
            }
            else if (from == Degree.d7_Subtonic)
            {
                to.Add(Degree.d1_Tonic);
            }

            //Non-functional stuff

            if (from == Degree.d3_Mediant)
            {
                to.Add(Degree.d6_Submediant);
                to.Add(Degree.d4_Subdominant);
            }
            else if (from == Degree.d7_Subtonic)
            {
                to.Add(Degree.d3_Mediant);
            }
            else if (from == Degree.d1_Tonic)
            {
                to.Add(Degree.d3_Mediant);
            }


            return to;
        }

        public static Degree Next(Degree from)
        {
            var list = Traverse(from);

            list.RemoveAll(f => f == from);

            Thread.Sleep(15);
            var rand = new Random();
            var randInd = rand.Next(0, list.Count());

            return list[randInd];
        }
    }
}
