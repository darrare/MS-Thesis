using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Graph
{
    public class UnitSphereGraph<T> where T : INodeifiable<T>, new()
    {
        /// <summary>
        /// Collection of nodes in this graph
        /// </summary>
        public List<Node<T>> Nodes { get; set; } = new List<Node<T>>();

        public int NumNodes { get; set; }

        public float Denseness { get; set; }

        /// <summary>
        /// Constructor for the dense graph
        /// </summary>
        /// <param name="numNodes">Number of nodes to create</param>
        /// <param name="denseness">Percentage of total conected nodes</param>
        public UnitSphereGraph(int numNodes, float denseness)
        {
            NumNodes = numNodes;
            Denseness = denseness;
            CreateGraph();
            SetNeighbors();
            SetConstraints();
        }

        /// <summary>
        /// Creates the objects in the scene and store them in a list
        /// </summary>
        void CreateGraph()
        {
            for (int i = 0; i < NumNodes; i++)
            {
                Nodes.Add(new Node<T>(new T()));
                //check position. log(x) * x^.6     https://www.desmos.com/calculator
                Nodes[Nodes.Count - 1].Obj.GameObject =
                    GameObject.Instantiate(ResourceManager.Instance.RuntimePrefabs[RuntimePrefab.SphericalObject], Random.insideUnitSphere * Mathf.Log10(NumNodes) * Mathf.Pow(NumNodes, .6f), Quaternion.identity, GameManager.Instance.SphereParent.transform);
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
                    int x = Random.Range(0, NumNodes - 1), y = Random.Range(0, NumNodes - 1);
                    if (edgeMatrix[x,y] == 1)
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
                    if (edgeMatrix[i,j] == 1)
                    {
                        Nodes[i].AddNeighbor(Nodes[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Set the constraints of the system
        /// </summary>
        void SetConstraints()
        {

        }
    }
}
