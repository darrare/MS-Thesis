using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Graph
{
    public interface INodeifiable<T> where T : new()
    {
        /// <summary>
        /// Unity GameObject that represents this node in Unity space
        /// </summary>
        GameObject GameObject { get; set; }

        /// <summary>
        /// List of Constraint delegates used to determine satisfiability
        /// </summary>
        List<Constraint<T>> Constraints { get; set; }
    }
}
