using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Scripts.Graph
{
    public class NodeColorPair
    {
        public Node<ColoredNode> Node;
        public Color Color;

        public NodeColorPair() { }
        public NodeColorPair(NodeColorPair other)
        {
            Node = other.Node;
            Color = new Color(other.Color.r, other.Color.g, other.Color.b, 1);
        }
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
            foreach(NodeColorPair p in other.State)
            {
                State.Add(new NodeColorPair(p));
            }
        }

        public void ApplyColorState()
        {
            foreach (NodeColorPair v in State)
            {
                v.Node.Obj.ApplyColorToGameObject();
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
