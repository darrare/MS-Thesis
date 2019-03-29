using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Graph;
using UnityEngine.UI;
using System;

public class UIControllerScript : MonoBehaviour
{
    [SerializeField]
    InputField numNodesInput;

    [SerializeField]
    InputField percentDensityInput;

    GraphClass graph;

    public void Lattice2DButtonClicked()
    {
        if (graph != null)
            graph.Deconstruct();
        graph = new LatticeGraph2D<ColoredNode>(100, 100);
    }

    public void UnitSphereGraphButtonClicked()
    {
        if (graph != null)
            graph.Deconstruct();
        graph = new UnitSphereGraph<ColoredNode>(int.Parse(numNodesInput.text), float.Parse(percentDensityInput.text) / 100);  
    }

    public void CheckSatisfiability()
    {
        bool somethingReturned = graph.CheckSatisfiability();
    }

    public void RandalBrownGraphButtonClicked()
    {
        if (graph != null)
            graph.Deconstruct();
        graph = new RandallBrownGraph(int.Parse(numNodesInput.text), float.Parse(percentDensityInput.text) / 100);
    }
}
