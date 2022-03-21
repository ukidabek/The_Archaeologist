namespace Logic.States
{
    public interface IStateTransition
    {
        void Cancel();
        void Perform(IState from, IState to);
    }
}