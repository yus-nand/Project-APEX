using UnityEngine;

public class RecoveryState : EnemyState
{
    private EnemyMovement movement;
    private EnemyHealth health;
    private float recoveryDuration = 1f;
    private float timer;
    
    public RecoveryState(EnemyStateMachine stateMachine, EnemyMovement movement, EnemyHealth health) : base(stateMachine)
    {
        this.movement = movement;
        this.health = health;
    }
    public override void Enter()
    {
        timer = 0f;
        movement.SetMovementEnabled(false);
    }
    public override void Update()
    {
        timer += Time.deltaTime;
        if(timer >= health.RecoveryDuration)
        {
            stateMachine.ChangeState(new ChaseState(stateMachine, movement));
        }
    }
}
