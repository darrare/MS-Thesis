using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

//----------------------------------------------------------------------
//Bottom of this script has Resource enumerations
//----------------------------------------------------------------------

public class ResourceManager
{
    #region Singleton & Constructor
    static ResourceManager instance;

    /// <summary>
    /// Singleton accessor for this manager
    /// </summary>
    public static ResourceManager Instance
    { get { return instance ?? (instance = new ResourceManager()); } }

    /// <summary>
    /// On creation, we want to start loading the resources that we want to use
    /// </summary>
    private ResourceManager()
    {
        //If error falls on this line, check RuntimePrefab enumeration. Enum options must match Constants.RUNTIME_PREFABS_LOCATION
        RuntimePrefabs = Resources.LoadAll<GameObject>(Constants.RUNTIME_PREFABS_LOCATION)
            .ToDictionary(t => (RuntimePrefab)Enum.Parse(typeof(RuntimePrefab), t.name, true), t => t);
    }
    #endregion

    #region Properties

    /// <summary>
    /// Runtime prefabs loaded in at start so they can be 
    /// loaded much more efficiently when creating large graphs
    /// </summary>
    public Dictionary<RuntimePrefab, GameObject> RuntimePrefabs { get; set; }

    #endregion
}

/// <summary>
/// Coordinate these filenames with Constants.RUNTIME_PREFABS_LOCATION
/// </summary>
public enum RuntimePrefab
{
    Line,
    SphericalObject,
}
