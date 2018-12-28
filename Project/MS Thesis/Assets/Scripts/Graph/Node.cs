using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Graph
{
    public class Node<T> where T : INodeifiable<T>, new()
    {
        /// <summary>
        /// The object contained within this node
        /// </summary>
        public T Obj { get; set; }

        /// <summary>
        /// Position of this node
        /// </summary>
        public Vector3 Position { get { return Obj.GameObject.transform.position; } }

        /// <summary>
        /// Any edges connected to this node
        /// </summary>
        public List<Edge<T>> Edges { get; set; } = new List<Edge<T>>();

        /// <summary>
        /// Constructor for a node object
        /// </summary>
        /// <param name="obj">The object this node will contain</param>
        public Node(T obj)
        {
            Obj = obj;
        }

        /// <summary>
        /// Checks to see if this node's constraints have been satisfied
        /// </summary>
        /// <returns>
        /// True: If every constraint has been satisfied
        /// False: If one or more constraint has not been satisfied
        /// </returns>
        public bool CheckSatisfiability()
        {
            return true;
        }

        /// <summary>
        /// Add a neighboring edge to this node
        /// </summary>
        /// <param name="neighbor">The neighbor to connect to via an edge</param>
        public void AddNeighbor(Node<T> neighbor)
        {
            Edges.Add(new Edge<T>(this, neighbor));
        }
    }
}
