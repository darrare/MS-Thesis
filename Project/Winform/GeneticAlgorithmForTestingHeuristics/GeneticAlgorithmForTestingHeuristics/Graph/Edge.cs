using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneticAlgorithmForTestingHeuristics.Utilities;

namespace GeneticAlgorithmForTestingHeuristics.Graph
{
    class Edge
    {
        /// <summary>
        /// The two nodes connected with this edge
        /// </summary>
        public Node[] Nodes { get; set; } = new Node[2];

        /// <summary>
        /// Distance between the neighboring nodes
        /// </summary>
        public float Length { get; set; } = float.PositiveInfinity;

        /// <summary>
        /// Constructor for an edge  between two nodes
        /// </summary>
        /// <param name="a">First node to connect</param>
        /// <param name="b">Second node to connect</param>
        public Edge(Node a, Node b)
        {
            Nodes[0] = a;
            Nodes[1] = b;
            Length = Vector2.Distance(a.Position, b.Position);
        }

        /// <summary>
        /// Indexer for the edge class
        /// </summary>
        /// <param name="index">Index to access</param>
        /// <returns>The node at index</returns>
        public Node this[int index]
        {
            get { return Nodes[index]; }
            set { Nodes[index] = value; }
        }

    }
}
