﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace MapColoring_Improved
{
    public class Graph
    {
        /// <summary>
        /// Due to the four color theorem, purple and on should NEVER be used in an optimal solution
        /// </summary>
        public static List<Color> colorOrder = new List<Color>() { Color.Red, Color.Blue, Color.Green, Color.Yellow };

        public List<Node> Nodes { get; set; } = new List<Node>();
        const double UNCOMFORTABLE_DISTANCE_IN_PERCENTAGE = .03; //within 5% distance compared to top left to bottom right of image
        public List<Edge> Edges;

        public Graph validGraph;

        /// <summary>
        /// Deep copy constructor for a graph
        /// </summary>
        /// <param name="other">The graph to copy</param>
        public Graph(Graph other)
        {
            //Copy nodes over
            for (int i = 0; i < other.Nodes.Count; i++)
            {
                Nodes.Add(new Node(other.Nodes[i]));
            }

            for (int i = 0; i < other.Nodes.Count; i++)
            {
                Node curNode = other.Nodes[i];
                for (int j = 0; j < curNode.Neighbors.Count; j++)
                {
                    Node neighborNode = curNode.Neighbors[j].GetNeighbor(curNode);
                    //If we don't have the connection yet, we want to add it
                    if (!Nodes[i].Neighbors.Any(t => t.GetNeighbor(Nodes[i]) == Nodes[other.Nodes.IndexOf(neighborNode)]))
                    {
                        Edge e = new Edge(Nodes[i], Nodes[other.Nodes.IndexOf(neighborNode)]);
                        Nodes[i].Neighbors.Add(e);
                        Nodes[other.Nodes.IndexOf(neighborNode)].Neighbors.Add(e);
                    }
                }
            }
            if (other.validGraph != null)
                validGraph = new Graph(other.validGraph);
        }

        public Graph(int numNodes, double edgeDensity, int minEdgesPerNode, int maxEdgesPerNode, int width, int height, Random rand)
        {
            //Create all the nodes at random locations
            for (int i = 0; i < numNodes; i++)
            {
                Nodes.Add(new Node(rand.Next(0, width - 10), rand.Next(0, height - 10), width, height));
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
            foreach (Node node in Nodes)
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
                        foreach (Node node in toAdd)
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

                foreach (Node node in candidates)
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

        /// <summary>
        /// Constructor for the graph that doesn't use a density, instead randomly chooses a value between minEdges and maxEdges
        /// </summary>
        /// <param name="numNodes"></param>
        /// <param name="minEdgesPerNode"></param>
        /// <param name="maxEdgesPerNode"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="rand"></param>
        public Graph(int numNodes, int minEdgesPerNode, int maxEdgesPerNode, int width, int height, Random rand)
        {
            //Create all the nodes at random locations
            for (int i = 0; i < numNodes; i++)
            {
                Nodes.Add(new Node(rand.Next(0, width - 10), rand.Next(0, height - 10), width, height));
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
                int numNeighborsToAdd = rand.Next(minEdgesPerNode, maxEdgesPerNode + 1);
                List<Node> sortedByDistance = Nodes.OrderBy(t => t.Distance(Nodes[i])).ToList();
                sortedByDistance.RemoveAt(0); //Remove self
                desiredNeighbors[Nodes[i]] = sortedByDistance.Take(numNeighborsToAdd).ToList();
            }

            //Separate any agreed neighbors and non-agreed neighbors
            Dictionary<Node, List<Node>> commonDecisionNeighbors = new Dictionary<Node, List<Node>>();
            Dictionary<Node, List<Node>> disagreeNeighbors = new Dictionary<Node, List<Node>>();
            foreach (Node node in Nodes)
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
                        foreach (Node node in toAdd)
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

                foreach (Node node in candidates)
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

            //Final final check
            foreach (Node node in Nodes)
            {
                if (node.Neighbors.Count < minEdgesPerNode || node.Neighbors.Count > maxEdgesPerNode)
                    throw new Exception("Some node has too many or too few neighbors.");
            }
        }

        public List<Edge> GetAllEdges()
        {
            if (Edges == null)
            {
                List<Edge> result = Nodes.Select(t => t.Neighbors).Aggregate(new List<Edge>(), (accumulator, next) => accumulator.Concat(next).ToList()).Distinct(new EdgeReferenceComparer()).ToList();
                Edges = result;
                return Edges;
            }
            return Edges;
        }

        /// <summary>
        /// Gets the number of edges in the graph
        /// </summary>
        public int GetEdgeCount()
        {
            return Edges?.Count ?? GetAllEdges().Count;
        }

        //****************************************************************************************************
        //The following functions are used in calculating the graph heuristic.
        //The graph heuristic prioritizes the order in which we advance the graphs.
        //****************************************************************************************************

        /// <summary>
        /// Fitness algorithm for the graph.
        /// A low value is best
        /// </summary>
        public double Fitness()
        {
            return Nodes.Count - GetColoredCount();
        }

        /// <summary>
        /// This should run the algorithm to find a solution. The fitness score should be the time it takes to finish.
        /// </summary>
        public double Solve(double[] genes)
        {
            SortedList<double, Graph> toSearch = new SortedList<double, Graph>();
            toSearch.Add(this.Fitness(), new Graph(this));

            //Store the minimum and maximum degree of the nodes in this graph for future use
            double minDegreeNode = this.Nodes.Min(t => t.GetNodeDegree());
            double maxDegreeNode = this.Nodes.Max(t => t.GetNodeDegree());
            double minColoredDegreeNode;
            double maxColoredDegreeNode;

            bool foundResult = false;
            int count = 0;
            while (toSearch.Any())
            {
                count++;
                Graph curGraph = toSearch.Dequeue(); //Take the most efficient graph according to the heuristic
                                                     
                minColoredDegreeNode = curGraph.Nodes.Min(t => t.GetColoredNodeDegree());
                maxColoredDegreeNode = curGraph.Nodes.Max(t => t.GetColoredNodeDegree());

                //Find the most valuable nodes to check in curGraph
                List<Node> priorityNodes = curGraph.Nodes.Select(t => new Tuple<double, Node>(t.Fitness((double)genes[0], (double)genes[1], (double)genes[2], (double)genes[3], minColoredDegreeNode, maxColoredDegreeNode), t)).Where(t => t.Item1 != -1).OrderByDescending(t => t.Item1).Select(t => t.Item2).ToList();

                //Get the index of the priority nodes
                List<int> priorityNodeIndexes = priorityNodes.Select(t => curGraph.Nodes.IndexOf(t)).ToList();

                for (int i = 0; i < priorityNodeIndexes.Count; i++)
                {
                    Graph newGraph = new Graph(curGraph);
                    //If after the advancement we have a graph that is satisfied, we are done. Note, this result is required to use <= 4 colors.
                    bool? result = newGraph.AdvanceOneStage(priorityNodeIndexes[i]);
                    if (result == null)
                    {
                        //The result is trying to use more than 4 colors. Don't add this to the search list
                        continue;
                    }

                    if (result.Value)
                    {
                        foundResult = true;
                        //We have found a solution, so set the nodes and edges of the solution to "this" so that we can display it.
                        if (validGraph == null)
                            validGraph = new Graph(newGraph);
                        else if (validGraph.GetTotalColorCount() > newGraph.GetTotalColorCount())
                            validGraph = new Graph(newGraph);
                        break;
                    }
                    toSearch.SafeAdd(newGraph.Fitness(), newGraph);
                }
                //No sense continuing if we have found the result. Note, this result is required to use <= 4 colors.
                if (foundResult)
                {
                    break;
                }
            }

            if (!foundResult)
                throw new Exception("There is always a result.");

            return count;
        }

        /// <summary>
        /// Exhaustively solves the Graph recursively, returning the collection of every single possible outcome with the given colors
        /// </summary>
        /// <returns></returns>
        public List<Graph> ExhaustiveSolve(Color[] possibleColors)
        {
            List<Graph> results = new List<Graph>();
            foreach (var node in Nodes)
            {
                if (node.Color != Color.Black)
                    continue;
                foreach (var color in possibleColors)
                {
                    Graph newGraph = new Graph(this);
                    newGraph.Nodes[Nodes.IndexOf(node)].Color = color;
                    results.AddRange(newGraph.ExhaustiveSolve(possibleColors));
                }
            }
            return results;
        }

        /// <summary>
        /// Advances this graph one stage by altering the node at the given index.
        /// Node is colored the first available color in the colorOrder list
        /// </summary>
        /// <param name="index">Index of the node to alter</param>
        public bool? AdvanceOneStage(int index)
        {
            Color[] neighborColors = Nodes[index].Neighbors.Select(t => t.GetNeighbor(Nodes[index]).Color).ToArray();
            bool foundColor = false;
            foreach (Color c in colorOrder)
            {
                if (!neighborColors.Contains(c))
                {
                    Nodes[index].Color = c;
                    foundColor = true;
                    break;
                }
            }

            if (!foundColor)
            {
                return null;
            }

            //After coloring the node, validate to see if it satisfied the graph
            return Validate();
        }

        /// <summary>
        /// Verifies that the graph is actually solved
        /// Doing this way because this form of validation is much faster than comparing all edges. 
        /// Only compare edges if we are finished with the graph.
        /// </summary>
        /// <returns>True if it is satisfied, false otherwise</returns>
        private bool Validate()
        {
            //If no more uncolored
            if (GetColoredCount() == Nodes.Count)
            {
                //If satisfies theorem https://en.wikipedia.org/wiki/Four_color_theorem
                if (GetTotalColorCount() <= 4)
                {
                    //If no two neighbors have the same color and no node has 0 available colors
                    if (InDepthValidate())
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("Logic error. Should never pass GetUncoloredCount() == 0 and then fail InDepthValidate().");
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks each edge to make sure the graph is logically satisfied
        /// </summary>
        /// <returns>True if it is satisfied, false otherwise</returns>
        private bool InDepthValidate()
        {
            foreach (var edge in GetAllEdges())
            {
                if (edge.Nodes[0].Color == edge.Nodes[1].Color)
                    return false;
            }
            foreach (var node in Nodes)
            {
                if (node.GetPossibleColorCount() == 0)
                    return false;
            }
            return true;
        }


        /// <summary>
        /// Total number of distinct colors used. Lower is better
        /// If this is a high value compared to other branches, our heuristic should stray away from it
        /// </summary>
        public double GetTotalColorCount() => Nodes.Select(t => t.Color).Distinct().Count();

        /// <summary>
        /// Number of nodes that have been colored
        /// Low uncolored count combined with a low total color count is a respectable graph.
        /// </summary>
        public double GetColoredCount() => Nodes.Where(t => t.Color != Color.Black).Count();

        /// <summary>
        /// The number of edges that have at least one black node connection
        /// A high number here likely means total color count is going to go up for this graph.
        /// Example: all nodes but 1 are colored, but it has 8 edges connected to it. Very high chance it is going to have to be a new color.
        /// </summary>
        public double GetNumEdgesNeighboringBlack() => GetAllEdges().Where(t => t.IsNeighboringTwoBlacks()).Count();
    }

    public class Node
    {
        public Color Color { get; set; } = Color.Black;
        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; } //used for generating the map, not in the bnb algorithm
        public int Height { get; set; } //used for generating the map, not in the bnb algorithm

        public bool DoneWithNeighbors { get; set; } = false; //used for generating the map, not in the bnb algorithm

        public List<Edge> Neighbors { get; set; } = new List<Edge>();

        /// <summary>
        /// partial deep copy constructor for node
        /// Does not copy neighbors within the constructor
        /// Used for the algorithm, not generation
        /// </summary>
        public Node(Node other)
        {
            this.Color = other.Color;
            this.X = other.X;
            this.Y = other.Y;
        }

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

            X = Extensions.Clamp(X + (int)Math.Round(direction.X), 0, Width - 10);
            Y = Extensions.Clamp(Y + (int)Math.Round(direction.Y), 0, Height - 10);
        }

        /****************************************************************************************************/
        //The following functions are used in calculating the node heuristics
        //The node heuristic prioritizes which node in the graph we want to try to color first
        /****************************************************************************************************/

        /// <summary>
        /// Can use this fitness algorithm because we are using a balanced genetic algorithm
        /// </summary>
        /// <param name="targetHighDegree"></param>
        /// <param name="targetLowDegree"></param>
        /// <param name="targetHighColoredDegree"></param>
        /// <param name="targetLowColoredDegree"></param>
        /// <param name="targetHighPossibleColors"></param>
        /// <param name="targetLowPossibleColors"></param>
        /// <param name="minDegreeNode"></param>
        /// <param name="maxDegreeNode"></param>
        /// <param name="minDegreeColoredNode"></param>
        /// <param name="maxDegreeColoredNode"></param>
        /// <returns></returns>
        public double Fitness(
            double targetHighColoredDegree, double targetLowColoredDegree,
            double targetHighPossibleColors, double targetLowPossibleColors,
            double minDegreeColoredNode, double maxDegreeColoredNode) //Yolo keeping them as doubles to avoid having to cast later. Prob could make float for more efficiency but oh well
        {
            //If already colored, we don't want to consider this node
            if (Color != Color.Black || GetPossibleColorCount() == 0)
                return -1;

            double thcd = targetHighColoredDegree * ((GetColoredNodeDegree() - minDegreeColoredNode) / (maxDegreeColoredNode - minDegreeColoredNode));
            double tlcd = targetLowColoredDegree * (1 -((GetColoredNodeDegree() - minDegreeColoredNode) / (maxDegreeColoredNode - minDegreeColoredNode)));
            double thpc = targetHighPossibleColors * (GetPossibleColorCount() / 4);
            double tlpc = targetLowPossibleColors * (1 - (GetPossibleColorCount() / 4));
            return thcd + tlcd + thpc + tlpc;
        }

        /// <summary>
        /// Number of uncolored neighbors. Lower the better
        /// If this is 0, then we know exactly what colors this node cannot be
        /// </summary>
        public double GetBlackNodeDegree() => Neighbors.Where(t => t.GetNeighbor(this).Color == Color.Black).Count();

        public double GetColoredNodeDegree() => Neighbors.Where(t => t.GetNeighbor(this).Color != Color.Black).Count();

        /// <summary>
        /// The number of neighbors this node has
        /// Generally you want to color high degrees first
        /// </summary>
        public double GetNodeDegree() => Neighbors.Count();

        /// <summary>
        /// Gets the possible colors for this node
        /// </summary>
        public double GetPossibleColorCount() => Graph.colorOrder.Count(t => !Neighbors.Any(n => n.GetNeighbor(this).Color == t));
    }

    /// <summary>
    /// Edge class. Only holds nodes as we don't care about distance in this problem.
    /// </summary>
    public class Edge : IEqualityComparer<Edge>
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
            return obj.GetHashCode();
        }

        /// <summary>
        /// Returns true iff both neighbors are black
        /// </summary>
        public bool IsNeighboringTwoBlacks()
        {
            return Nodes[0].Color == Color.Black && Nodes[1].Color == Color.Black;
        }

        /// <summary>
        /// Returns true iff only one neighbor is black
        /// </summary>
        public bool IsNeighboringOneBlack()
        {
            return (Nodes[0].Color == Color.Black && Nodes[1].Color != Color.Black)
                || (Nodes[0].Color != Color.Black && Nodes[1].Color == Color.Black);
        }

        /// <summary>
        /// Returns true iff neither neighbor is black
        /// </summary>
        public bool IsNeighboringNoBlacks()
        {
            return Nodes[0].Color != Color.Black && Nodes[1].Color != Color.Black;
        }
    }

    class EdgeReferenceComparer : IEqualityComparer<Edge>
    {
        public bool Equals(Edge x, Edge y)
        {
            return x == y;
        }

        public int GetHashCode(Edge obj)
        {
            return obj.GetHashCode();
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
