using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateBase : EntityStateBase
{
    protected MonsterController monster;
    protected MonsterAnimData animData;

    public MonsterStateBase(StateMachine stateMachine, Animator anim, int animName, MonsterController monster, MonsterAnimData animData) : base(stateMachine, anim, animName)
    {
        this.monster = monster;
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
