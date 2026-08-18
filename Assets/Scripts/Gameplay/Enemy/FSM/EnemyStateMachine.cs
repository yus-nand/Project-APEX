using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public EnemyState CurrentState{get;  private set;}
    public void Initialize(EnemyState startingState)
    {
        CurrentState = startingState;
        CurrentState?.Enter();
    }
    private void Update()
    {
        CurrentState?.Update();
    }
    public void ChangeState(EnemyState newState)
    {
        if(newState == null)
            return;

        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
    public void OnPlayerContact()
    {
        if(CurrentState is ChaseState)
        {
            ChangeState(new AttackState(this, GetComponent<EnemyMovement>(), GetComponent<EnemyDamage>()));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnPlayerContact();
    }
}
