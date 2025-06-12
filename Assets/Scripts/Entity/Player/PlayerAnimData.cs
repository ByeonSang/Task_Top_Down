using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimData
{
    private StateMachine _stateMachine;
    private PlayerIdleState _idleState;
    private PlayerRunState _runState;

    private string _idleName = "Idle";
    private string _runName = "Run";

    public PlayerIdleState IdleState => _idleState;
    public PlayerRunState RunState => _runState;
    private int ConvertHash(string name) => Animator.StringToHash(name);

    public PlayerAnimData(Animator anim, PlayerController player)
    {
        _stateMachine = new();

        _idleState = new(_stateMachine, anim, ConvertHash(_idleName), player, this);
        _runState = new(_stateMachine, anim, ConvertHash(_runName), player, this);

        _stateMachine.Init(_idleState);
    }

    public void Update()
    {
        _stateMachine.CurrentState.Update();
    }
}
