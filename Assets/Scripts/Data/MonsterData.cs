using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class MonsterData : DataBase
{
    public string MonsterID;
    public string Name;
    public string Description;
    public int Attack;
    public float AttackMul;
    public int MaxHP;
    public float MaxHPMul;
    public int AttackRange;
    public float AttackRangeMul;
    public float AttackSpeed;
    public float MoveSpeed;
    public int MinExp;
    public int MaxExp;
    public int[] DropItem;

    public MonsterData() { }

    public MonsterData(MonsterData data)
    {
        MonsterID = data.MonsterID;
        Name = data.Name;
        Description = data.Description;
        Attack = data.Attack;
        AttackMul = data.AttackMul;
        MaxHP = data.MaxHP;
        MaxHPMul = data.MaxHPMul;
        AttackRange = data.AttackRange;
        AttackRangeMul = data.AttackRangeMul;
        AttackSpeed = data.AttackSpeed;
        MoveSpeed = data.MoveSpeed;
        MinExp = data.MinExp;
        MaxExp = data.MaxExp;

        DropItem = new int[data.DropItem.Length];
        for(int i =0; i< DropItem.Length; i++)
        {
            DropItem[i] = data.DropItem[i];
        }
    }

    public override string Key => MonsterID;

    public override string KeyName => Name;
}
