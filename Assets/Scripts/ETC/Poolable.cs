using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    public void SetParent(Transform parentTrans)
    {
        transform.parent = parentTrans;
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
