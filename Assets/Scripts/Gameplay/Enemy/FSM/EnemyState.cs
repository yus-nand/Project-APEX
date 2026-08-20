public abstract class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected EnemyState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    public virtual void Enter()
    {
        
    }
    public virtual void Exit()
    {
        
    }
    public virtual void OnPlayerContact()
    {
        
    }
    public virtual void Update()
    {
        
    }
}
