using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private int _initCreate; // 처음 생성할 몬스터 수
    [SerializeField] private bool _nowSpawn; // 게임 시작하고 바로 스폰할지 아니면 직접 호출할지

    // 콜라이더 길이에 따라서 스폰
    [SerializeField, Range(1f,40f)] private float _randomRangeX;
    [SerializeField, Range(1f,40f)] private float _randomRangeY;

    [SerializeField] private float _spawnDuration; // 스폰 간격
    [SerializeField] private List<MonsterAsset> _monsterAssets;

    private float time;

    public bool NowSpawn { get; set; }

    private void Start()
    {
        StartCoroutine(CreateMonster(10));
    }

    private IEnumerator CreateMonster(int initSpawnCount = 1)
    {
        int count = 0;
        while(count++ < initSpawnCount)
        {
            foreach (var asset in _monsterAssets)
            {
                Managers.Resource.LoadAssetsAsync<GameObject>("MonsterBrain", prefab =>
                {
                    GameObject newMonsterBrain = InstantiateBrain(prefab, asset.Data.Key);

                    if(newMonsterBrain != null && newMonsterBrain.TryGetComponent<MonsterController>(out var monsterCtrl))
                    {
                        monsterCtrl.Init(asset, GetRandomPos());
                        newMonsterBrain.SetActive(false);
                    } 
                });
            }

            yield return null;
        }
    }

    private GameObject InstantiateBrain(GameObject prefab, string key)
    {
        key = $"{key}_Brain";
        if(prefab.GetComponent<Poolable>())
        {
            PoolGroup group = Managers.ObjectPool.GetGroup(key);
            
            if(group.IsFull == false)
            {
                GameObject newMonster = Instantiate(prefab);
                newMonster.name = key;

                newMonster.transform.SetParent(group.Transform);
                return newMonster;
            }
        }

        return null;
    }

    private Vector2 GetRandomPos()
    {
        float halfX = _randomRangeX / 2f;
        float halfY = _randomRangeY / 2f;

        float randX = Random.Range(-halfX, halfX);
        float randY = Random.Range(-halfY, halfY);

        Vector2 spawnerPos = transform.position;

        return new Vector2(spawnerPos.x + randX, spawnerPos.y + randY);
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (_nowSpawn == false) return;

        if (time > 0f) return;

        time = _spawnDuration;

        CreateMonster();
    }

    public GameObject GetMonster()
    {
        if (_monsterAssets.Count == 0) return null; // 데이터가 없으면 무시 

        int rand = Random.Range(0, _monsterAssets.Count);

        MonsterAsset monsterAsset = _monsterAssets[rand];

        // 그룹에 없으면 무시
        string key = $"{monsterAsset.Data.Key}_Brain";
        PoolGroup group = Managers.ObjectPool.GetGroup(key);
        if (group.Count == 0) return null;

        GameObject poolGO = group.Get(key);
        return poolGO;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(transform.position, new Vector2(_randomRangeX, _randomRangeY));
    }

}
