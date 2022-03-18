using UnityEngine;

namespace Logic.States
{
    public abstract class SwitchStateLogic : StateLogic, IOnUpdateLogic
    {
        [SerializeField] private GameObject _stateMachineObject = null;

        private IStateMachine _stateMachine = null;
        
        [SerializeField] private State _stateToEnter = null;
        private IState StateToEnter => _stateToEnter;
        
        protected abstract bool Condition { get; }

        private void Awake()
        {
            _stateMachine = _stateMachineObject.GetComponent<IStateMachine>();
        }

        public virtual void OnUpdate(float deltaTime)
        {
            if (Condition && _stateMachine.CurrentState != StateToEnter) 
                _stateMachine.EnterState(StateToEnter);
        }
    }
}