using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RangedAttackState : EnemyState
{
    private EnemyMovement movement;
    private EnemyRangedAttack rangedAttack;
    private EnemyHealth health;
    private float preferredRange;
    public RangedAttackState(EnemyStateMachine stateMachine, EnemyMovement movement, EnemyRangedAttack rangedAttack, EnemyHealth health, float preferredRange) : base(stateMachine)
    {
        this.movement = movement;
        this.rangedAttack = rangedAttack;
        this.health = health;
        this.preferredRange = preferredRange;
    }
    public override void Enter()
    {
        movement.SetMovementEnabled(false);
        rangedAttack.FireProjectile();
        stateMachine.ChangeState(new RecoveryState(stateMachine, movement, health, new KiteState(stateMachine, movement, rangedAttack, health, preferredRange)));
    }
}
