using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Create/ItemAsset", fileName ="Item Asset")]
public class ItemAsset : DataAsset<ItemData>
{
    [SerializeField] private ItemData _itemData;

    public override ItemData Data { get => _itemData; set => _itemData = new(value); }
}
