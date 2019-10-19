using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MapColoring
{
    class Graph
    {
        public List<Node> Nodes { get; set; } = new List<Node>();
        const double UNCOMFORTABLE_DISTANCE_IN_PERCENTAGE = .05; //within 5% distance compared to top left to bottom right of image

        public Graph(int numNodes, double edgeDensity, int minEdgesPerNode, int maxEdgesPerNode, int width, int height, Random rand)
        {
            //Create all the nodes at random locations
            for (int i = 0; i < numNodes; i++)
            {
                Nodes.Add(new Node(rand.Next(0, width - 1), rand.Next(0, height - 1), width, height));
            }

            double uncomfortableDistance = Math.Sqrt(Math.Pow(width, 2) + Math.Pow(height, 2)) * UNCOMFORTABLE_DISTANCE_IN_PERCENTAGE;
            double distanceToMove = uncomfortableDistance * .5; //half of the uncomfortable distance for now
            bool isComfortable = true;
            do
            {
                isComfortable = true;
                for (int i = 0; i < Nodes.Count - 1; i++)
                {
                    for (int j = i + 1; j < Nodes.Count; j++)
                    {
                        if (Nodes[i].Distance(Nodes[j]) <= uncomfortableDistance)
                        {
                            isComfortable = false;
                            Nodes[i].MoveAwayFrom(Nodes[j], distanceToMove);
                            Nodes[j].MoveAwayFrom(Nodes[i], distanceToMove);
                        }
                    }
                }
            } while (!isComfortable);

            //At this point the graph has all the nodes that are spaced nicely. Time to add neighbors.

            //Find out all the neighbors each node wants (for itself)
            Dictionary<Node, List<Node>> desiredNeighbors = new Dictionary<Node, List<Node>>();
            for (int i = 0; i < Nodes.Count; i++)
            {
                int numNeighborsToAdd = Extensions.Clamp((int)Math.Round((numNodes - 1) * edgeDensity), minEdgesPerNode, maxEdgesPerNode);
                List<Node> sortedByDistance = Nodes.OrderBy(t => t.Distance(Nodes[i])).ToList();
                sortedByDistance.RemoveAt(0);
                desiredNeighbors[Nodes[i]] = sortedByDistance.Take(numNeighborsToAdd).ToList();
            }

            //Separate any agreed neighbors and non-agreed neighbors
            Dictionary<Node, List<Node>> commonDecisionNeighbors = new Dictionary<Node, List<Node>>();
            Dictionary<Node, List<Node>> disagreeNeighbors = new Dictionary<Node, List<Node>>();
            foreach(Node node in Nodes)
            {
                commonDecisionNeighbors.Add(node, new List<Node>());
                disagreeNeighbors.Add(node, new List<Node>());
            }

            foreach (var top in desiredNeighbors)
            {
                foreach (var other in top.Value)
                {
                    if (desiredNeighbors[other].Contains(top.Key))
                    {
                        if (!commonDecisionNeighbors[top.Key].Contains(other))
                            commonDecisionNeighbors[top.Key].Add(other);
                        if (!commonDecisionNeighbors[other].Contains(top.Key))
                            commonDecisionNeighbors[other].Add(top.Key);
                    }
                    else
                        disagreeNeighbors[top.Key].Add(other);
                }
            }

            //unhappy nodes are nodes that cannot be valid with neighbors they want to be, so they have to be neighbors with others.
            List<Node> unhappyNodes = new List<Node>();
            //if any node is invalid, go through disagree neighbors and force it to make it valid.
            foreach (var top in disagreeNeighbors)
            {
                //Invalid node, lets take some of the disagree neighbors to fix.
                if (commonDecisionNeighbors[top.Key].Count < minEdgesPerNode)
                {
                    int countNeededToFix = minEdgesPerNode - commonDecisionNeighbors[top.Key].Count;
                    List<Node> canAdd = disagreeNeighbors[top.Key].Where(t => commonDecisionNeighbors[t].Count < maxEdgesPerNode).ToList();
                    if (canAdd.Count >= countNeededToFix)
                    {
                        List<Node> toAdd = canAdd.Take(countNeededToFix).ToList();
                        commonDecisionNeighbors[top.Key].AddRange(toAdd);
                        foreach(Node node in toAdd)
                            commonDecisionNeighbors[node].Add(top.Key);
                    }
                    else
                    {
                        unhappyNodes.Add(top.Key);
                    }
                }
            }

            for (int i = 0; i < unhappyNodes.Count; i++)
            {
                int countNeededToFix = minEdgesPerNode - commonDecisionNeighbors[unhappyNodes[i]].Count;
                if (countNeededToFix <= 0)
                    continue; //Possibly fixed from a previous iteration of i

                //Cant add neighbors that are already added.
                List<Node> candidates = Nodes.Where(t => !commonDecisionNeighbors[unhappyNodes[i]].Contains(t) && commonDecisionNeighbors[t].Count < maxEdgesPerNode).ToList();

                if (candidates.Count < countNeededToFix)
                    throw new Exception("Impossible graph setup. Try different variables.");

                //Sort candiates by distance and takes the number needed to fix the unhappy node
                candidates = candidates.OrderBy(t => t.Distance(unhappyNodes[i])).Take(countNeededToFix).ToList();

                foreach(Node node in candidates)
                {
                    commonDecisionNeighbors[unhappyNodes[i]].Add(node);
                    commonDecisionNeighbors[node].Add(unhappyNodes[i]);
                }
            }

            //Last double check to make sure they agree
            foreach (var top in commonDecisionNeighbors)
            {
                if (top.Value.Count < minEdgesPerNode || top.Value.Count > maxEdgesPerNode)
                    throw new Exception("Some node has too many or too few neighbors.");
                foreach (var other in top.Value)
                {
                    if (!commonDecisionNeighbors[other].Contains(top.Key))
                        throw new Exception("commonDecisionNeighbors doesn't agree with itself... Something bad in the algorithm");
                }
            }

            //Build edges between nodes based on commonDecisionNeighbors
            List<Node> alreadyHandled = new List<Node>();
            foreach (var top in commonDecisionNeighbors)
            {
                alreadyHandled.Add(top.Key);
                foreach (var other in top.Value)
                {
                    if (!alreadyHandled.Contains(other))
                    {
                        Edge edge = new Edge(top.Key, other);
                        top.Key.Neighbors.Add(edge);
                        other.Neighbors.Add(edge);
                    }
                }
            }
        }
    }

    class Node
    {
        public Color Color { get; set; } = Color.Black;
        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public bool DoneWithNeighbors { get; set; } = false;

        public List<Edge> Neighbors { get; set; } = new List<Edge>();

        public Node(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public double Distance(Node other)
        {
            return Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
        }

        public double Distance(Point point)
        {
            return Math.Sqrt(Math.Pow(point.X - X, 2) + Math.Pow(point.Y - Y, 2));
        }

        public void MoveAwayFrom(Node other, double distance)
        {
            Vector2 direction = new Vector2(X - other.X, Y - other.Y);
            direction.Normalize();
            direction.X *= distance;
            direction.Y *= distance;

            X = Extensions.Clamp(X + (int)Math.Round(direction.X), 0, Width - 1);
            Y = Extensions.Clamp(Y + (int)Math.Round(direction.Y), 0, Height - 1);
        }
    }

    /// <summary>
    /// Edge class. Only holds nodes as we don't care about distance in this problem.
    /// </summary>
    class Edge : IEqualityComparer<Edge>
    {
        public Node[] Nodes { get; set; } = new Node[2];
        
        public Edge(Node first, Node second)
        {
            Nodes[0] = first;
            Nodes[1] = second;
        }

        public Node GetNeighbor(Node self)
        {
            if (Nodes[0] == self)
                return Nodes[1];
            return Nodes[0];
        }

        public bool Equals(Edge x, Edge y)
        {
            if (x.Nodes[0] == y.Nodes[0] && x.Nodes[1] == y.Nodes[1])
                return true;
            if (x.Nodes[0] == y.Nodes[1] && x.Nodes[1] == y.Nodes[0])
                return true;
            return false;
        }

        public int GetHashCode(Edge obj)
        {
            throw new NotImplementedException();
        }
    }

    class Vector2
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void Normalize()
        {
            double magnitude = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            X /= magnitude;
            Y /= magnitude;
        }
    }

}
