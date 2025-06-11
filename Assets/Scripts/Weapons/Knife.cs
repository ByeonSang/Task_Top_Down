using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private ItemData _itemData;
    [SerializeField] private float _rotateSpeed;

    private float _curPoint;

    private void FixedUpdate()
    {
        _curPoint += 10f;
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.z + _rotateSpeed * Time.fixedDeltaTime * _curPoint);
    }
}
