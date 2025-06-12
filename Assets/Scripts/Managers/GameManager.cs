using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameManager
{
    private const string playerKey = "Player";

    private PlayerController _playerController;
    private GameObject _playerGO;

    public PlayerController PlayerController => _playerController;
    public GameObject PlayerGO => _playerGO;

    public void Init()
    {
        Managers.Resource.LoadAssetsAsync<GameObject>(playerKey, prefab => 
        {
            GameObject newGO = Object.Instantiate(prefab);
            PlayerController playerCtrl = newGO.GetComponent<PlayerController>();
            playerCtrl.Init();

            _playerController = playerCtrl;
            _playerGO = newGO;
        });
    }
}
