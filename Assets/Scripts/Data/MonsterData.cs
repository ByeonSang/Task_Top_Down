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

    public MonsterData(MonsterData other)
    {
        if (other == null)
            return;

        MonsterID = other.MonsterID;
        Name = other.Name;
        Description = other.Description;
        Attack = other.Attack;
        AttackMul = other.AttackMul;
        MaxHP = other.MaxHP;
        MaxHPMul = other.MaxHPMul;
        AttackRange = other.AttackRange;
        AttackRangeMul = other.AttackRangeMul;
        AttackSpeed = other.AttackSpeed;
        MoveSpeed = other.MoveSpeed;
        MinExp = other.MinExp;
        MaxExp = other.MaxExp;

        DropItem = new int[other.DropItem.Length];
        for(int i =0; i< DropItem.Length; i++)
        {
            DropItem[i] = other.DropItem[i];
        }
    }

    public override string Key => MonsterID;

    public override string KeyName => Name;
}
