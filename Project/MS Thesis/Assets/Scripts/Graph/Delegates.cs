using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Graph
{
    /// <summary>
    /// Delegate to allow the use of very custom constraints among different types of INodeifiables.
    /// </summary>
    /// <typeparam name="T">The type of object this constraint will be held on. Must implement INodeifiable.</typeparam>
    /// <param name="a">The first object</param>
    /// <param name="b">The second object</param>
    /// <returns>
    /// True: If the constraint has been met
    /// False: The constraint has not, and/or cannot be met
    /// </returns>
    public delegate bool Constraint<T>(T a, T b);

    /// <summary>
    /// Will be declared on every graph delcaration. 
    /// Provides instruction on how to call list of constraints from specific problem.
    /// </summary>
    public delegate bool CheckSatisfiability<T>(Node<T> node) where T : INodeifiable<T>, new();
}
