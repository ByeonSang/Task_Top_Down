using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHitState : MonsterStateBase
{
    public MonsterHitState(StateMachine stateMachine, Animator anim, int animName, MonsterController monster, MonsterAnimData animData) : base(stateMachine, anim, animName, monster, animData)
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
