using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Graph
{
    public class RandallBrownGraph : GraphClass
    {
        /// <summary>
        /// Collection of nodes in this graph
        /// </summary>
        public List<Node<ColoredNode>> Nodes { get; set; } = new List<Node<ColoredNode>>();

        public int NumNodes { get; set; }

        public float Denseness { get; set; }

        /// <summary>
        /// Constructor for the graph generated using the Randall Brown algorithm
        /// </summary>
        /// <param name="numNodes">Number of nodes to create</param>
        /// <param name="denseness">Percentage of total conected nodes</param>
        public RandallBrownGraph(int numNodes, float denseness)
        {
            NumNodes = numNodes;
            Denseness = denseness;
            CreateGraph();
            SetNeighbors();

            RandallBrownColoringAlgorithm(new List<Color>() { Color.red, Color.blue, Color.yellow});
        }

        public void RandallBrownColoringAlgorithm(List<Color> colors)
        {
            List<ColorState> validSolutions = new List<ColorState>();
            PriorityQueue<ColorState> queue = new PriorityQueue<ColorState>();
            queue.Enqueue(new ColorState(Nodes, Color.white), 0);

            while(queue.Count() > 0)
            {
                ColorState current = queue.Dequeue();
                if (!current.Any(t => t.Color == Color.white))
                {
                    current.ApplyColorState();
                    if (CheckSatisfiability())
                        validSolutions.Add(current);
                    continue;
                }

                NodeColorPair nextWhite = current.FirstOrDefault(t => t.Color == Color.white);
                foreach (Color c in colors)
                {
                    nextWhite.Color = c;
                    current.ApplyColorState();
                    if (nextWhite.Node.CheckSatisfiability())
                        queue.Enqueue(new ColorState(current), 1); //TODO: HEURISTIC HERE
                }
            }

            //do something to color tree?
            Nodes = validSolutions[0].Select(t => t.Node).ToList();
            DrawColors();
            CheckSatisfiability();
        }

        void DrawColors()
        {
            foreach (Node<ColoredNode> n in Nodes)
            {
                n.Obj.GameObject.GetComponent<MeshRenderer>().material.color = n.Obj.Color;
            }
        }

        /// <summary>
        /// Creates the objects in the scene and store them in a list
        /// </summary>
        void CreateGraph()
        {
            for (int i = 0; i < NumNodes; i++)
            {
                Nodes.Add(new Node<ColoredNode>(new ColoredNode()));
                //check position. log(x) * x^.6     https://www.desmos.com/calculator
                Nodes[Nodes.Count - 1].Obj.GameObject = GameObject.Instantiate(ResourceManager.Instance.RuntimePrefabs[RuntimePrefab.SphericalObject], Random.insideUnitSphere * Mathf.Log10(NumNodes) * Mathf.Pow(NumNodes, .6f), Quaternion.identity, GameManager.Instance.SphereParent.transform);

                //Custom for specific problems, will need to move later
                #region Custom, remove later

                //Nodes[Nodes.Count - 1].Obj.GameObject.GetComponent<MeshRenderer>().material.color = r > .66f ? Color.red : r > .33f ? Color.blue : Color.green;
                Nodes[Nodes.Count - 1].Obj.Constraints.Add(new Constraint<ColoredNode>((a, b) =>
                {
                    if (a.Color == b.Color && a.Color != Color.white && b.Color != Color.white)
                        return false;
                    else
                        return true;
                }));
                Nodes[Nodes.Count - 1].IsSatisfied = new CheckSatisfiability<ColoredNode>((a) =>
                {
                    bool isValid = true;
                    foreach (Constraint<ColoredNode> c in a.Obj.Constraints)
                    {
                        foreach (Edge<ColoredNode> e in a.Edges)
                        {
                            if (!c(e[0].Obj, e[1].Obj))
                            {
                                e.Line.GetComponent<LineRenderer>().startColor = Color.yellow;
                                e.Line.GetComponent<LineRenderer>().endColor = Color.yellow;
                                isValid = false;
                            }
                            else
                            {
                                e.Line.GetComponent<LineRenderer>().startColor = Color.white;
                                e.Line.GetComponent<LineRenderer>().endColor = Color.white;
                            }
                        }
                    }
                    return isValid;
                });

                #endregion
            }

        }

        /// <summary>
        /// Sets the neighbors of the graph
        /// </summary>
        void SetNeighbors()
        {
            //Builds a matrix like so
            // 00000
            // 10000
            // 11000
            // 11100
            // 11110
            short[,] edgeMatrix = new short[NumNodes, NumNodes];
            int total = 0;
            for (int i = 0; i < NumNodes; i++)
            {
                for (int j = 0; j < NumNodes; j++)
                {
                    if (j > i)
                    {
                        edgeMatrix[i, j] = 1;
                        total++;
                    }
                    else
                        edgeMatrix[i, j] = 0;
                }
            }

            //Awful..... Potentially incredibly expensive but it works. Yolo
            //Will remove connections from the edge matrix to meet the density requirements
            for (int i = 0; i < (total - (total * Denseness)); i++)
            {
                do
                {
                    int x = Random.Range(0, NumNodes), y = Random.Range(0, NumNodes);
                    if (edgeMatrix[x, y] == 1)
                    {
                        edgeMatrix[x, y] = 0;
                        break;
                    }
                } while (true);
            }

            //Create edges based on edge matrix
            for (int i = 0; i < NumNodes - 1; i++)
            {
                for (int j = i + 1; j < NumNodes; j++)
                {
                    if (edgeMatrix[i, j] == 1)
                    {
                        Nodes[i].AddNeighbor(Nodes[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Checks whether or not every constraint on this graph is satisfied
        /// </summary>
        public override bool CheckSatisfiability()
        {
            bool? isValid = null;
            foreach (Node<ColoredNode> n in Nodes)
            {
                if (!n.CheckSatisfiability())
                    isValid = false;
            }
            return (isValid == null) ? false : (isValid == true);
        }

        public override void Deconstruct()
        {
            for (int i = NumNodes - 1; i >= 0; i--)
            {
                for (int j = Nodes[i].Edges.Count - 1; j >= 0; j--)
                {
                    if (Nodes[i].Edges[j].Line != null)
                    {
                        GameObject.Destroy(Nodes[i].Edges[j].Line);
                    }
                }
                GameObject.Destroy(Nodes[i].Obj.GameObject);
            }
        }
    }
}


