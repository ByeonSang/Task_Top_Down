using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimData
{
    private StateMachine _stateMachine;
    private MonsterRunState _runState;
    private MonsterHitState _hitState;

    private string _runName = "Run";
    private string _hitName = "Hit";

    public MonsterRunState IdleState => _runState;
    public MonsterHitState RunState => _hitState;
    private int ConvertHash(string name) => Animator.StringToHash(name);

    public MonsterAnimData(Animator anim, MonsterController monster)
    {
        _stateMachine = new();

        _runState = new(_stateMachine, anim, ConvertHash(_runName), monster, this);
        _hitState = new(_stateMachine, anim, ConvertHash(_hitName), monster, this);
        Init();
    }
    
    public void Init()
    {
        _stateMachine.Init(_runState);
    }

    public void Update()
    {
        _stateMachine.CurrentState.Update();
    }
}
