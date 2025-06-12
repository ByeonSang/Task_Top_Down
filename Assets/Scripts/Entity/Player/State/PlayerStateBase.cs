using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBase : EntityStateBase
{
    protected PlayerController player;
    protected PlayerAnimData animData;

    public PlayerStateBase(StateMachine stateMachine, Animator anim, int animName, PlayerController player, PlayerAnimData animData) : base(stateMachine, anim, animName)
    {
        this.player = player;
        this.animData = animData;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {

    }
}
