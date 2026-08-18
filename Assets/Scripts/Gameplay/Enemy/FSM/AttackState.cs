using UnityEngine;

public class AttackState : EnemyState
{
    private EnemyMovement movement;
    private EnemyDamage damage;
    private EnemyHealth health;

    public AttackState(EnemyStateMachine stateMachine, EnemyMovement movement, EnemyDamage damage, EnemyHealth health) : base(stateMachine)
    {
        this.movement = movement;
        this.damage = damage;
        this.health = health;
    }
    public override void Enter()
    {
        movement.SetMovementEnabled(false);
        Debug.Log("sATTACK: Entered attack state");
        damage.DealDamage();

        Debug.Log("sRECOVERY: Entering recovery state");
        stateMachine.ChangeState(new RecoveryState(stateMachine, movement, movement.gameObject.GetComponent<EnemyHealth>()));
    }
}
