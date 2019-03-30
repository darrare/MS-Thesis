using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Graph;
using UnityEngine.UI;
using System;

public class UIControllerScript : MonoBehaviour
{
    public static UIControllerScript Instance;

    [SerializeField]
    InputField numNodesInput;

    [SerializeField]
    InputField percentDensityInput;

    [SerializeField]
    public InputField numColorsInput;

    [SerializeField]
    Text arrowKeyText;

    [SerializeField]
    public Toggle stopOnFirstSolution;

    GraphClass graph;

    int index = 1;

    List<ColorState> validSolutions;
    public List<ColorState> ValidSolutions
    {
        set
        {
            index = 1;
            validSolutions = value;
            arrowKeyText.text = index + " / " + validSolutions.Count;
        }
    }

    public void Awake()
    {
        Instance = this;
    }


    public void PreviousClicked()
    {
        if (index != 1)
        {
            index--;
            foreach (NodeColorPair v in validSolutions[index - 1])
            {
                v.Node.Obj.Color = v.Color;
                v.Node.Obj.ApplyColorToGameObject();
            }
            arrowKeyText.text = index + " / " + validSolutions.Count;
        }
    }

    public void NextClicked()
    {
        if (index != validSolutions.Count)
        {
            index++;
            foreach (NodeColorPair v in validSolutions[index - 1])
            {
                v.Node.Obj.Color = v.Color;
                v.Node.Obj.ApplyColorToGameObject();
            }
            arrowKeyText.text = index + " / " + validSolutions.Count;
        }
    }

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
