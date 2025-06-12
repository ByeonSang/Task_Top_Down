using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DataAsset<T> : ScriptableObject where T : DataBase
{
    public abstract T Data { get; set; }
}
