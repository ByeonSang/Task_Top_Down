using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MonsterBody : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spr;
    [SerializeField] private Animator _anim;

    [SerializeField] private MonsterController _monsterCtrl;

    private MonsterAnimData _animData;

    private void OnValidate()
    {
        if (_anim == null) _anim = GetComponent<Animator>();
        if (_spr == null) _spr = GetComponent<SpriteRenderer>();
    }

    public void Init(MonsterController monsterController)
    {
        _monsterCtrl = monsterController;

        _animData = new(_anim, _monsterCtrl);
        _animData.Init();
    }

    private void Update()
    {
        ApplyFlip();
    }

    private void ApplyFlip()
    {
        _spr.flipX = !_monsterCtrl.IsRight;
    }
}
