using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class ItemData : DataBase
{
    public int ItemID;
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

    public override string Key => ItemID.ToString();

    public override string KeyName => Name;

    public ItemData(ItemData other)
    {
        if (other == null)
            return;

        ItemID = other.ItemID;
        Name = other.Name;
        Description = other.Description;
        UnlockLev = other.UnlockLev;
        MaxHP = other.MaxHP;
        MaxHPMul = other.MaxHPMul;
        MaxMP = other.MaxMP;
        MaxMPMul = other.MaxMPMul;
        MaxAtk = other.MaxAtk;
        MaxAtkMul = other.MaxAtkMul;
        MaxDef = other.MaxDef;
        MaxDefMul = other.MaxDefMul;
        Status = other.Status;
    }
}
