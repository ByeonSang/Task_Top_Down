using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager
{
    private Dictionary<string, PoolGroup> _poolGroups = new();

    public void Release(Poolable poolable)
    {
        if (_poolGroups.TryGetValue(poolable.name, out var group))
        {
            group.Add(poolable);
        }
        else
        {
            CreateGroup(poolable.name).Add(poolable);
        }
    }

    public PoolGroup GetGroup(string key)
    {
        if(_poolGroups.TryGetValue(key, out var group))
        {
            return group;
        }

        return null;
    }

    private PoolGroup CreateGroup(string name)
    {
        PoolGroup newGroup = new PoolGroup(new GameObject($"{name}_Group"));
        _poolGroups.TryAdd(name, newGroup);
        return newGroup;
    }
}
