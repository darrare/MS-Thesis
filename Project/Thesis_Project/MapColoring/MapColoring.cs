using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MapColoring
{
    class MapColoring
    {
        /// <summary>
        /// Due to the four color theorem, purple should NEVER be used.
        /// </summary>
        List<Color> colorOrder = new List<Color>() { Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Purple };

        public MapColoring(Graph graph)
        {
            Graph g2 = new Graph(graph);
        }

        public double Fitness(object[] genes)
        {
            throw new NotImplementedException();
        }
    }
}
