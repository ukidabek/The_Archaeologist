using System;
using UnityEngine;

namespace Logic.States
{
    public class StateManager : MonoBehaviour, IStateMachine
    {
        [SerializeField] private State m_currentState = null;
        public IState CurrentState => m_currentState;

        [SerializeField] private StateLogicExecutor[] m_logicExecutor;
        private StateMachine _stateMachine = null;

        private void Awake()
        {
            _stateMachine = new StateMachine(m_logicExecutor, Array.Empty<IStateTransitionLogic>());
            _stateMachine.OnStateChange += OnStateChange;
        }

        private void OnStateChange() => m_currentState = _stateMachine.CurrentState as State;

        public void EnterState(IState statToEnter) => _stateMachine.EnterState(statToEnter);
    }
}
