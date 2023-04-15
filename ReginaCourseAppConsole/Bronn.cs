using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReginaCourseAppConsole
{
    internal class Bronn
    {

        public static void BronKerboschAlg(HashSet<int> r, List<int> p, List<int> x, int[,] graph)
        {
            string fileName = "output.txt";
            HashSet<int> myset = new(r.Select(x => x + 1));
            if (p.Count == 0 && x.Count == 0) // maximal clique found
            {

                
                using (StreamWriter writer = File.AppendText(fileName))
                {

                    writer.Write("Maximal clique: [" + string.Join(", ", myset) + "]\n" );

                }

                //Console.WriteLine("Maximal clique: [" + string.Join(", ", myset) + "]");
                return;
            }

            foreach (int v in new List<int>(p)) // make a copy for iteration
            {
                HashSet<int> vNeighbors = new HashSet<int>();
                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[v, i] == 1)
                        vNeighbors.Add(i);
                }

                HashSet<int> subgraph = new HashSet<int>(r.Union(vNeighbors));

                if (subgraph.IsSupersetOf(r) && subgraph.IsSupersetOf(vNeighbors))
                {
                    HashSet<int> newR = new HashSet<int>(r);
                    newR.Add(v);

                    List<int> newP = new List<int>(p);
                    newP.RemoveAll(w => graph[v, w] == 0);

                    List<int> newX = new List<int>(x);
                    newX.RemoveAll(w => graph[v, w] == 0);

                    BronKerboschAlg(newR, newP, newX, graph);
                    p.Remove(v);
                    x.Add(v);
                }
            }
        }
    }
}
