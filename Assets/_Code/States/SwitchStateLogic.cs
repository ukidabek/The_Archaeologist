using UnityEngine;

namespace Logic.States
{
    public abstract class SwitchStateLogic : StateLogic, IOnUpdateLogic
    {
        [SerializeField] private StateManager _manager = null;
        [SerializeField] private State _stateToEnter = null;
        protected abstract bool Condition { get; }

        public virtual void OnUpdate(float deltaTime)
        {
            if (Condition && _manager.CurrentState != _stateToEnter) 
                _manager.EnterState(_stateToEnter);
        }
    }
}