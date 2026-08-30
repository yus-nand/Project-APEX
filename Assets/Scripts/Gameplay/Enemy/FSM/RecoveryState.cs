using UnityEngine;

public class RecoveryState : EnemyState
{
    private EnemyMovement movement;
    private EnemyHealth health;
    private EnemyState nextState;
    private float recoveryDuration = 1f;
    private float timer;
    
    public RecoveryState(EnemyStateMachine stateMachine, EnemyMovement movement, EnemyHealth health, EnemyState nextState) : base(stateMachine)
    {
        this.movement = movement;
        this.health = health;
        this.nextState = nextState;
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
            stateMachine.ChangeState(nextState);
        }
    }
}
