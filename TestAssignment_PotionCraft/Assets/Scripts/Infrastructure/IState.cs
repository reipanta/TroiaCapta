namespace Infrastructure
{
    // Interface methods for a state machine
    public interface IState
    {
        void Enter();
        void Exit();
    }
}