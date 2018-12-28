using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Graph;

public class UIControllerScript : MonoBehaviour
{
    public void Lattice2DButtonClicked()
    {
        new LatticeGraph2D<ColoredNode>(9, 9);
    }
}
