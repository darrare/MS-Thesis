using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Graph
{
    public abstract class GraphClass
    {
        /// <summary>
        /// Checks the graph to see if it is satisfied
        /// </summary>
        public abstract bool CheckSatisfiability();

        /// <summary>
        /// Destroy the entirety of the graph. All objects included
        /// </summary>
        public abstract void Deconstruct();
    }
}
