using UnityEngine;

public class RecoveryState : EnemyState
{
    private EnemyMovement movement;
    private float recoveryDuration = 1f;
    private float timer;
    
    public RecoveryState(EnemyStateMachine stateMachine, EnemyMovement movement) : base(stateMachine)
    {
        this.movement = movement;
    }
    public override void Enter()
    {
        timer = 0f;
        movement.SetMovementEnabled(false);
    }
    public override void Update()
    {
        timer += Time.deltaTime;
        if(timer >= recoveryDuration)
        {
            stateMachine.ChangeState(new ChaseState(stateMachine, movement));
        }
    }
}
