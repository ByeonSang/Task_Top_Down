using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PoolGroup
{
    private const int _maxLength = 10;

    private Queue<Poolable> _pool = new();

    public Transform Transform { get; }

    public bool IsFull => (Transform.transform.childCount == _maxLength);

    public PoolGroup(GameObject groupGo)
    {
        Transform = groupGo.transform;
    }

    public void Add(Poolable pool)
    {
        if(_pool.Count < _maxLength)
        {
            _pool.Enqueue(pool);
            pool.SetActive(false);
        }
        else
        {
            UnityEngine.Object.Destroy(pool.gameObject);
        }
    }

    public GameObject Get(string key)
    {
        if (_pool.TryDequeue(out var poolable))
        {
            poolable.SetActive(true);
            return poolable.gameObject;
        }

        return null;
    }
}
