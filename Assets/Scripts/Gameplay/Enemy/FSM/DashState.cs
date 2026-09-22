using UnityEngine;

public class DashState : EnemyState
{
    private EnemyMovement movement;
    private EnemyDamage damage;
    private EnemyHealth health;

    private float timer;
    private Vector2 dashDirection;
    private bool damageDealt;
    private bool dieAfterDash;

    public DashState(EnemyStateMachine stateMachine, EnemyMovement movement, EnemyDamage damage, EnemyHealth health, bool dieAfterDash = false) : base(stateMachine)
    {
        this.movement = movement;
        this.damage = damage;
        this.health = health;
        this.dieAfterDash = dieAfterDash;
    }
    public override void Enter()
    {
        timer = 0f;
        damageDealt = false;    

        Vector2 playerPosition = movement.GetPlayerPosition();

        dashDirection = (playerPosition - (Vector2)movement.transform.position).normalized;

        movement.StartDash(dashDirection);
    }
    public override void Update()
    {
        timer += Time.deltaTime;
        if(timer >= movement.DashDuration)
        {
            movement.EndDash();
            if(dieAfterDash)
            {
                health.TakeDamage(100);
                return;
            }
            stateMachine.ChangeState(new RecoveryState(stateMachine, movement, health, new DashState(stateMachine, movement, damage, health)));
        }
    }
    public override void OnPlayerContact()
    {
        if(damageDealt)
            return;

        damage.DealDamage();
        damageDealt = true;
        if(dieAfterDash)
        {
            health.TakeDamage(100);
        }
    }
}
