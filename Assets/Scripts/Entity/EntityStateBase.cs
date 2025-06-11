using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityStateBase
{
    protected StateMachine stateMachine;
    protected Animator anim;

    protected int animHash;

    public EntityStateBase(StateMachine stateMachine, Animator anim, int animHash)
    {
        this.stateMachine = stateMachine;
        this.anim = anim;
        this.animHash = animHash;
    }

    public virtual void Enter()
    {
        anim.SetBool(animHash, true);
    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {
        anim.SetBool(animHash, false);
    }

}
