using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Graph
{
    public class Edge<T> where T : INodeifiable<T>, new()
    {
        /// <summary>
        /// The two nodes connected with this edge
        /// </summary>
        public Node<T>[] Nodes { get; set; } = new Node<T>[2];

        /// <summary>
        /// Distance between the neighboring nodes
        /// </summary>
        public float Length { get; set; } = float.PositiveInfinity;

        /// <summary>
        /// The line associated with this edge
        /// </summary>
        public GameObject Line { get; set; }

        /// <summary>
        /// Create an edge for the graph system
        /// </summary>
        /// <param name="a">First connected node</param>
        /// <param name="b">Second connected node</param>
        public Edge(Node<T> a, Node<T> b)
        {
            Nodes[0] = a;
            Nodes[1] = b;
            Length = Vector3.Distance(a.Obj.GameObject.transform.position, b.Obj.GameObject.transform.position);
            Line = GameObject.Instantiate(ResourceManager.Instance.RuntimePrefabs[RuntimePrefab.Line], GameManager.Instance.LineParent.transform);
            Line.GetComponent<LineRenderer>().SetPositions(new Vector3[] { a.Position, b.Position });
        }
    }
}
