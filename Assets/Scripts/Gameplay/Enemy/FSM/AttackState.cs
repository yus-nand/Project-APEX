using UnityEngine;

public class AttackState : EnemyState
{
    private EnemyMovement movement;
    private EnemyDamage damage;

    public AttackState(EnemyStateMachine stateMachine, EnemyMovement movement, EnemyDamage damage) : base(stateMachine)
    {
        this.movement = movement;
        this.damage = damage;
    }
    public override void Enter()
    {
        movement.SetMovementEnabled(false);
        Debug.Log("sATTACK: Entered attack state");
        damage.DealDamage();

        Debug.Log("sRECOVERY: Entering recovery state");
        stateMachine.ChangeState(new RecoveryState(stateMachine, movement));
    }
}
