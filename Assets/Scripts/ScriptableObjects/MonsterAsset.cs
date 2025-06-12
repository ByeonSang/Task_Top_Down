using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create/MonsterAsset", fileName = "Monster Asset")]
public class MonsterAsset : DataAsset<MonsterData>
{
    [SerializeField] private MonsterData _monsterData;

    public override MonsterData Data { get => _monsterData; set => _monsterData = new(value); }
}
