using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class IntializerMenu : MonoBehaviour
{
    [SerializeField] List<GameObject> gameObjectsToInitialize;
   
    void Awake()
    {
        Time.timeScale = 1;
        foreach (GameObject go in gameObjectsToInitialize)
        {
            Instantiate(go);
        }
    }
}
