using Unity.VisualScripting;
using UnityEngine;

public class DashRecoveryState : EnemyState
{
    private EnemyMovement movement;
    private EnemyHealth health;
    private float timer;
    public DashRecoveryState(EnemyStateMachine stateMachine, EnemyMovement movement, EnemyHealth health) : base(stateMachine)
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
            stateMachine.ChangeState(new DashState(stateMachine, movement, movement.GetComponent<EnemyDamage>(), health));
        }
    }
}
