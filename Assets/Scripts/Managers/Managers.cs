using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers instance;
    // Member Variable
    private static readonly ObjectPoolManager _objectPool = new();

    // Property
    public static ObjectPoolManager ObjectPool => _objectPool;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        } 
    }
}
