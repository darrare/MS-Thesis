using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Graph
{
    public class LatticeGraph3D<T> : GraphClass where T : INodeifiable<T>, new()
    {
        /// <summary>
        /// Collection of nodes in this graph
        /// </summary>
        public Node<T>[,,] Nodes { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }

        /// <summary>
        /// Constructor for a lattice graph
        /// </summary>
        /// <param name="width">Width of the graph</param>
        /// <param name="height">Height of the graph</param>
        public LatticeGraph3D(int width, int height, int depth)
        {
            Nodes = new Node<T>[width, height, depth];
            Width = width;
            Height = height;
            Depth = depth;
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
                    for (int z = 0; z < Depth; z++)
                    {
                        Nodes[x, y, z] = new Node<T>(new T());
                        Nodes[x, y, z].Obj.GameObject =
                            GameObject.Instantiate(ResourceManager.Instance.RuntimePrefabs[RuntimePrefab.SphericalObject], new Vector3(x * 1.5f, y * 1.5f, z * 1.5f), Quaternion.identity, GameManager.Instance.SphereParent.transform);
                    }
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
                    for (int z = 0; z < Depth; z++)
                    {
                        //if x is divisible by 2, only work when y is also divisible by 2.
                        //if x is not divisible by 2, only work when y is also not divisible by 2
                        if ((-(x % 2) + (y % 2)) == 0)
                        {
                            AddNeighbor(x, y, z, 1, 0, 0); //right
                            AddNeighbor(x, y, z, -1, 0, 0); //left
                            AddNeighbor(x, y, z, 0, 1, 0); //up
                            AddNeighbor(x, y, z, 0, -1, 0); //down
                        }

                        //Add depthwise neighbor
                        AddNeighbor(x, y, z, 0, 0, -1);
                    }
                }
            }
        }

        /// <summary>
        /// Add a neighbor to the node[x,y] object relative to xOffset and yOffset
        /// </summary>
        /// <param name="x">X position of node to add neighbor to</param>
        /// <param name="y">Y position of node to add neighbor to</param>
        /// <param name="z">Z position of node to add neighbor to</param>
        /// <param name="xOffset">amount to offset X</param>
        /// <param name="yOffset">amount to offset Y</param>
        /// <param name="zOffset">amount to offset Z</param>
        void AddNeighbor(int x, int y, int z, int xOffset, int yOffset, int zOffset)
        {
            //Check bounds and add X & Y neighbors
            if ((x + xOffset >= 0) && (x + xOffset <= Width - 1) && (y + yOffset >= 0) && (y + yOffset <= Height - 1))
            {
                Nodes[x, y, z].AddNeighbor(Nodes[x + xOffset, y + yOffset, z]);
            }

            if (z - zOffset <= Depth - 1)
            {
                Nodes[x, y, z].AddNeighbor(Nodes[x + xOffset, y + yOffset, z + zOffset]);
            }
        }

        /// <summary>
        /// Set the constraints of the system
        /// </summary>
        void SetConstraints()
        {

        }

        public override bool CheckSatisfiability()
        {
            throw new System.NotImplementedException();
        }

        public override void Deconstruct()
        {
            throw new System.NotImplementedException();
        }
    }
}