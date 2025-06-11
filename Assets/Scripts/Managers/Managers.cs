using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers instance;
    // Member Variable
    private static readonly ObjectPoolManager _objectPool = new();
    private static readonly ResourceManager _resource = new();
    private static readonly DataManager _data = new();

    // Property
    public static ObjectPoolManager ObjectPool => _objectPool;
    public static ResourceManager Resource => _resource;
    public static DataManager Data => _data;

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
