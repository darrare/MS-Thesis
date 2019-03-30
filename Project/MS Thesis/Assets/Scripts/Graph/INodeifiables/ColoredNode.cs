using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Graph
{
    public class ColoredNode : INodeifiable<ColoredNode>
    {
        /// <summary>
        /// Unity GameObject that represents this node in Unity space
        /// </summary>
        public GameObject GameObject { get; set; }

        /// <summary>
        /// List of Constraint delegates used to determine satisfiability
        /// </summary>
        public List<Constraint<ColoredNode>> Constraints { get; set; } = new List<Constraint<ColoredNode>>();

        /// <summary>
        /// Color of the given node
        /// </summary>
        public Color Color { get; set; }

        public void ApplyColorToGameObject()
        {
            GameObject.GetComponent<MeshRenderer>().material.color = Color;
        }

        /// <summary>
        /// Constructor for a Colored Node
        /// </summary>
        public ColoredNode() { }
    }
}
