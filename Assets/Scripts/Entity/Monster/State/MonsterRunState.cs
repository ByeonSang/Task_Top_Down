using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRunState : MonsterStateBase
{
    public MonsterRunState(StateMachine stateMachine, Animator anim, int animName, Player player, PlayerAnimData animData) : base(stateMachine, anim, animName, player, animData)
    {
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
