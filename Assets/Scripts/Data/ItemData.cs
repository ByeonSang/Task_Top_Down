using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemData : DataBase
{
    public string ItemID;
    public string Name;
    public string Description;
    public int UnlockLev;
    public int MaxHP;
    public float MaxHPMul;
    public int MaxMP;
    public float MaxMPMul;
    public int MaxAtk;
    public float MaxAtkMul;
    public int MaxDef;
    public float MaxDefMul;
    public int Status;

    public override string Key => ItemID;

    public override string KeyName => Name;
}
