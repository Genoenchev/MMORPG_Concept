using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine stateMachine;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected bool IsInChaseRange()
    {
        if(stateMachine.Player.IsDead) return false;

        float toPlayerDistanceSquare = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;

        return toPlayerDistanceSquare <= stateMachine.PlayerChasingRange * stateMachine.PlayerChasingRange;
    }
    protected void Move(Vector3 motion, float deltaTime)
    {
        stateMachine.Controller.Move((motion + stateMachine.ForceReceiver.Movement) * deltaTime);
    }

    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }

    protected void FacePlayer()
    {
        if (stateMachine.Player == null) { return; }

        Vector3 lookPosition = stateMachine.Player.transform.position - stateMachine.transform.position;
        lookPosition.y = 0f;

        stateMachine.transform.rotation = Quaternion.LookRotation(lookPosition);
    }

}
