using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Scripts.Graph
{
    public struct NodeColorPair
    {
        public Node<ColoredNode> Node;
        public Color Color;
    }

    public class ColorState : IEnumerable<NodeColorPair>
    {
        List<NodeColorPair> State = new List<NodeColorPair>();

        public ColorState(List<Node<ColoredNode>> nodes, Color defaultColor)
        {
            foreach (Node<ColoredNode> n in nodes)
            {
                State.Add(new NodeColorPair { Node = n, Color = defaultColor });
            }
        }

        public ColorState(ColorState other)
        {
            State = other.State;
        }

        public void ApplyColorState()
        {
            foreach (NodeColorPair v in State)
            {
                v.Node.Obj.Color = v.Color;
            }
        }

        public IEnumerator<NodeColorPair> GetEnumerator()
        {
            return ((IEnumerable<NodeColorPair>)State).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<NodeColorPair>)State).GetEnumerator();
        }
    }
}
