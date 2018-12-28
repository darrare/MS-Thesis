using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    #region singleton and constructor

    static GameManager instance;

    /// <summary>
    /// singleton for the game manager class
    /// </summary>
    public static GameManager Instance
    { get { return instance ?? (instance = new GameManager()); } }

    /// <summary>
    /// Constructor for the gamemanager class
    /// </summary>
    private GameManager()
    {
        Object.DontDestroyOnLoad(new GameObject("Updater", typeof(Updater)));
        SphereParent = GameObject.Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);
        LineParent = GameObject.Instantiate(new GameObject(), Vector3.zero, Quaternion.identity);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Parent holder for the spheres. Only useful for cleaning up hierarchy.
    /// </summary>
    public GameObject SphereParent { get; set; }

    /// <summary>
    /// Parent holder for the lines. Only useful for cleaning up hierarchy.
    /// </summary>
    public GameObject LineParent { get; set; }

    #endregion

    /// <summary>
    /// Updates the gamemanager
    /// </summary>
    void Update()
    {

    }

    #region internal updater class

    /// <summary>
    /// Updates the game manager class
    /// </summary>
    class Updater : MonoBehaviour
    {
        void Update()
        {
            instance.Update();
        }
    }

    #endregion
}
