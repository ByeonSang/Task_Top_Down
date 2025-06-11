using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create/MonsterAsset", fileName = "Monster Asset")]
public class MonsterAsset : ScriptableObject
{
    [SerializeField] private MonsterData _monsterData;

    public MonsterData Data {
        get => _monsterData;  
        set
        {
            _monsterData = new(value);
        }
    }
}
