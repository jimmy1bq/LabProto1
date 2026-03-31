using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class IntialzerMap : MonoBehaviour
{
    [SerializeField] List<GameObject> gameObjectsToInitialize;

    void Awake()
    {
        foreach (GameObject go in gameObjectsToInitialize)
        {
            Instantiate(go);
        }
    }
}
