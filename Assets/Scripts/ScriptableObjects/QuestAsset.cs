using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create/QuestAsset", fileName ="Quest Asset")]
public class QuestAsset : DataAsset<QuestData>
{
    [SerializeField] private QuestData _questData;

    public override QuestData Data { get => _questData; set => _questData = new(value); }
}
