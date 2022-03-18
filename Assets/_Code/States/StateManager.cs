using System;
using System.Collections.Generic;
using UnityEngine;

namespace Logic.States
{
    public class StateMachine : IStateMachine
    {
        public event Action OnStateChange; 
        private readonly IEnumerable<IStateLogicExecutor> _stateLogicExecutor = null;
        
        private IState _currentState;
        public IState CurrentState => _currentState;

        public StateMachine(IEnumerable<IStateLogicExecutor> stateLogicExecutor)
        {
            _stateLogicExecutor = stateLogicExecutor;
        }

        public void EnterState(IState statToEnter)
        {
            if(_currentState == statToEnter) return;
            
            foreach (var stateLogicExecutor in _stateLogicExecutor) 
                stateLogicExecutor.ClearLogicToExecute();

            _currentState?.Exit();
            _currentState = statToEnter;
            _currentState?.Enter();
            
            foreach (var stateLogicExecutor in _stateLogicExecutor) 
                stateLogicExecutor.SetLogicToExecute(_currentState);
            OnStateChange?.Invoke();
        }
    }
    
    public class StateManager : MonoBehaviour, IStateMachine
    {
        [SerializeField] private State m_currentState = null;
        public IState CurrentState => m_currentState;

        [SerializeField] private StateLogicExecutor[] m_logicExecutor;
        private StateMachine _stateMachine = null;

        private void Awake()
        {
            _stateMachine = new StateMachine(m_logicExecutor);
            _stateMachine.OnStateChange += OnStateChange;
        }

        private void OnStateChange() => m_currentState = _stateMachine.CurrentState as State;

        public void EnterState(IState statToEnter) => _stateMachine.EnterState(statToEnter);
    }
}
