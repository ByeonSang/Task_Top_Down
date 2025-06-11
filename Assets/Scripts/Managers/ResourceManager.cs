using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

using Object = UnityEngine.Object;

public class ResourceManager
{
    private Dictionary<string, AsyncOperationHandle> _operations = new();
    private Dictionary<string, Stack<string>> _keys = new();
    public AsyncOperationHandle LoadAssetsAsync<T>(string key, Action<T> onComplete = null) where T : Object
    {
        if(_operations.TryGetValue(key, out var operation))
        {
            onComplete?.Invoke(operation.Result as T);
            return operation;
        }

        operation = Addressables.LoadAssetAsync<T>(key);
        operation.Completed += op => onComplete?.Invoke(op.Result as T);
        _operations.TryAdd(key, operation);
        return operation;
    }

    public void Instantiate(string key, Action<GameObject> onComplete = null)
    {
        PoolGroup group = Managers.ObjectPool.GetGroup(key);

        if (group != null)
        {
            if(group.IsFull == false)
            {
                GameObject poolGO = group.Get(key);

                if (poolGO == null)
                {
                    var operation = LoadAssetsAsync<GameObject>(key);
                    GameObject prefab = operation.Result as GameObject;
                    poolGO = Instantiate(prefab);
                    poolGO.transform.parent = group.Transform;
                }
                
                onComplete?.Invoke(poolGO);
            }
            else
            {
                Utils.Log("Failed to add group because it is full");
            }
        }

        
    }

    private GameObject Instantiate(GameObject prefab)
    {
        GameObject go = Object.Instantiate(prefab);
        go.name = prefab.name;
        return go;
    }

    public void Destroy(GameObject go)
    {
        if(go.TryGetComponent<Poolable>(out var poolable))
        {
            Managers.ObjectPool.Release(poolable);
        }
        else
        {
            Object.Destroy(go);
        }
    }

    public void Release(string key) // 메모리 해제
    {
        if(_keys.TryGetValue(key, out var keyStack)) // 그룹 해제
        {
            while(keyStack.TryPop(out var pop))
            {
                if (_operations.ContainsKey(pop))
                    _operations.Remove(pop);
            }

            _keys.Remove(key);
        }
        else // 단일 해제
        {
            if (_operations.ContainsKey(key))
                _operations.Remove(key);
        }
    }
}
