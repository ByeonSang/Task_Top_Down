using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateBase : EntityStateBase
{
    protected Player player;
    protected PlayerAnimData animData;

    public MonsterStateBase(StateMachine stateMachine, Animator anim, int animName, Player player, PlayerAnimData animData) : base(stateMachine, anim, animName)
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
