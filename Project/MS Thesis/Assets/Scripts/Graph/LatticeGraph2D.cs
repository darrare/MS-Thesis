using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Graph
{
    public class LatticeGraph2D<T> where T : INodeifiable<T>, new()
    {
        /// <summary>
        /// Collection of nodes in this graph
        /// </summary>
        public Node<T>[,] Nodes { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        /// <summary>
        /// Constructor for a lattice graph
        /// </summary>
        /// <param name="width">Width of the graph</param>
        /// <param name="height">Height of the graph</param>
        public LatticeGraph2D(int width, int height)
        {
            Nodes = new Node<T>[width, height];
            Width = width;
            Height = height;
            CreateLattice();
            SetNeighbors();
            SetConstraints();
        }

        /// <summary>
        /// Creates the objects in the scene and store them in a 2D array
        /// </summary>
        void CreateLattice()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Nodes[x, y] = new Node<T>(new T());
                    Nodes[x, y].Obj.GameObject =
                        GameObject.Instantiate(ResourceManager.Instance.RuntimePrefabs[RuntimePrefab.SphericalObject], new Vector3(x * 1.5f, y * 1.5f, 0), Quaternion.identity, GameManager.Instance.SphereParent.transform);
                }
            }
        }

        /// <summary>
        /// Sets the neighbors of the array.
        /// Optimized by only considering the "X" nodes similarly to below
        /// X O X O X
        /// O X O X O
        /// X O X O X
        /// </summary>
        void SetNeighbors()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    //if x is divisible by 2, only work when y is also divisible by 2.
                    //if x is not divisible by 2, only work when y is also not divisible by 2
                    if ((-(x % 2) + (y % 2)) == 0)
                    {
                        AddNeighbor(x, y, 1, 0); //right
                        AddNeighbor(x, y, -1, 0); //left
                        AddNeighbor(x, y, 0, 1); //up
                        AddNeighbor(x, y, 0, -1); //down
                    }
                }
            }
        }

        /// <summary>
        /// Add a neighbor to the node[x,y] object relative to xOffset and yOffset
        /// </summary>
        /// <param name="x">X position of node to add neighbor to</param>
        /// <param name="y">Y position of node to add neighbor to</param>
        /// <param name="xOffset">amount to offset X</param>
        /// <param name="yOffset">amount to offset Y</param>
        void AddNeighbor(int x, int y, int xOffset, int yOffset)
        {
            //Are we in bounds?
            if ((x + xOffset >= 0) && (x + xOffset <= Width - 1) && (y + yOffset >= 0) && (y + yOffset <= Height - 1))
            {
                Nodes[x, y].AddNeighbor(Nodes[x + xOffset, y + yOffset]);
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
