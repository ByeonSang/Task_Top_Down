using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReadOnlyDrawer;
using UnityEngine.InputSystem;

public class MonsterController : MonoBehaviour
{
    [SerializeField, ReadOnly] private MonsterData _monsterData;

    [SerializeField, ReadOnly] private Vector2 _targetPos;
    [SerializeField, ReadOnly] private MonsterBody _body;

    public bool IsRight { get; private set; } = true;


    public void Init(MonsterAsset monsterAsset, Vector2 spawnPoint)
    {
        _monsterData = new(monsterAsset.Data);
        transform.position = spawnPoint;

        CreateOrInitBody($"{monsterAsset.Data.Key}_Body");
    }

    private void CreateOrInitBody(string key)
    {
        if (_body == null)
        {
            Managers.Resource.LoadAssetsAsync<GameObject>(key, (prefab) =>
            {
                GameObject bodyGO = Instantiate(prefab, transform);
                bodyGO.name = $"{key}_Body";
                _body = bodyGO.GetComponent<MonsterBody>();
                _body.Init(this);
            });
        }
        else
            _body.Init(this);
    }

    public void Update()
    {
        ApplyMove();
    }

    private void ApplyMove()
    {
        _targetPos = (Managers.Game.PlayerGO == null) ? Vector2.zero : Managers.Game.PlayerGO.transform.position;

        if (Vector2.Distance(transform.position, _targetPos) < 0.001f) return;

        Vector2 dir = (_targetPos - (Vector2)transform.localPosition).normalized;

        if(dir.x != 0) IsRight = (dir.x > 0f);

        Vector2 nextPoint = ((Vector2)transform.localPosition + dir * _monsterData.MoveSpeed * Time.deltaTime);

        transform.localPosition = nextPoint;
    }
}
