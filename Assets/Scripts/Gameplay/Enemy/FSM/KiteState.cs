using Unity.VisualScripting;
using UnityEngine;

public class KiteState : EnemyState
{
    private EnemyMovement movement;
    private EnemyRangedAttack rangedAttack;
    private EnemyHealth health;
    private float preferredRange;
    public KiteState(EnemyStateMachine stateMachine, EnemyMovement movement, EnemyRangedAttack rangedAttack, EnemyHealth health, float preferredRange) : base(stateMachine)
    {
        this.movement = movement;
        this.rangedAttack = rangedAttack;
        this.health = health;
        this.preferredRange = preferredRange;
    }
    public override void Enter()
    {
        movement.SetMovementEnabled(true);
        movement.EnableKiting(preferredRange);
    }
    public override void Update()
    {
        float distance = Vector2.Distance(movement.transform.position, movement.GetPlayerPosition());
        if(distance <= preferredRange)
        {
            stateMachine.ChangeState(new RangedAttackState(stateMachine, movement, rangedAttack, health, preferredRange));
        }
    }
    public override void Exit()
    {
        movement.DisableKiting();
    }
}
