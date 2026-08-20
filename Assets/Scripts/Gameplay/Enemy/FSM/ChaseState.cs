public class ChaseState : EnemyState
{
    private EnemyMovement movement;
    public ChaseState(EnemyStateMachine stateMachine, EnemyMovement movement) : base(stateMachine)
    {
        this.movement = movement;
    }
    public override void Enter()
    {
        movement.SetMovementEnabled(true);
    }
    public override void Update()
    {
       
    }
    public override void OnPlayerContact()
    {
        stateMachine.ChangeState(new AttackState(stateMachine, movement, movement.GetComponent<EnemyDamage>(), movement.GetComponent<EnemyHealth>()));
    }
    public override void Exit()
    {
        movement.SetMovementEnabled(false);
    }
}
