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
        /// Solve the graph with the given genes.
        /// Used for testing individual gene sets
        /// </summary>
        /// <returns>Fitness score of the given graph</returns>
        public static double Solve(Graph graph, int numBranchesToSplit,
            double getTotalColorCountWeight,
            double getUncoloredCountWeight,
            double getNumEdgesNeighboringBlackWeight,
            double getUncoloredNeighborCountWeight,
            double getNodeDegreeWeight)
        {
            object[] genes = new object[] { numBranchesToSplit, getTotalColorCountWeight, getUncoloredCountWeight, getNumEdgesNeighboringBlackWeight, getUncoloredNeighborCountWeight, getNodeDegreeWeight };

            return graph.Solve(genes);
        }

        /// <summary>
        /// Solve the graph with the given genes.
        /// Used for testing individual gene sets
        /// </summary>
        /// <returns>Fitness score of the given graph</returns>
        public static double Solve(Graph graph, object[] genes)
        {
            if (genes.Length != 6)
                throw new Exception("Map coloring algorithm uses 6 genes.");
            return graph.Solve(genes);
        }
    }
}
