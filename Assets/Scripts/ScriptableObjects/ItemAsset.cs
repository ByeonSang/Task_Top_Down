using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create/ItemAsset", fileName ="Item Asset")]
public class ItemAsset : ScriptableObject
{
    [SerializeField] private ItemData _itemData;
    public ItemData Data => _itemData;
}
