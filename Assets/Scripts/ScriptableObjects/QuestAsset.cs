using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create/QuestAsset", fileName ="Quest Asset")]
public class QuestAsset : ScriptableObject
{
    [SerializeField] QuestData _questData;

    public QuestData Data => _questData;
}
