using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Graph;
using UnityEngine.UI;
using System;

public class UIControllerScript : MonoBehaviour
{
    [SerializeField]
    InputField unitSphereNumNodes;

    [SerializeField]
    InputField unitSpherePercentDensity;

    public void Lattice2DButtonClicked()
    {
        new LatticeGraph2D<ColoredNode>(100, 100);
    }

    public void UnitSphereGraphButtonClicked()
    {
        try
        {
            new UnitSphereGraph<ColoredNode>(int.Parse(unitSphereNumNodes.text), float.Parse(unitSpherePercentDensity.text) / 100);
        }
        catch (Exception e)
        {
            throw new NotImplementedException("TODO: give a warning message somewhere on the interface that they entered invalid input.");
        }
        
    }
}
